using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading;
using System.Threading.Tasks;
using bot.DataModel;
using HttpClientLogic;
using Paramore.Darker;
using bot.Queries;
using System;
using System.Linq;

namespace bot.QueryHandlers
{
    public class FetchDailyOHLCVFromAPIQueryHandler : QueryHandler<FetchDailyOHLCVFromAPIQuery, IEnumerable<DailyOHLCV>>
    {
        private IHttpClient HttpClient { get; }
        public FetchDailyOHLCVFromAPIQueryHandler(IHttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        private class FetchDailyOHLCVResponse
        {
            public string Response { get; set; }
            public string Type { get; set; }
            public string Aggregated { get; set; }
            public IEnumerable<DailyOHLCVResponse> Data { get; set; }
        }

        private class DailyOHLCVResponse
        {
            public int Time { get; set; }
            public Decimal Open { get; set; }
            public Decimal Close { get; set; }
            public Decimal High { get; set; }
            public double VolumeFrom { get; set; }
            public double VolumeTo { get; set; }
        }

        // [QueryLogging(1)]
        // [FallbackPolicy(2)]
        // [RetryableQuery(3)]
        public override IEnumerable<DailyOHLCV> Execute(FetchDailyOHLCVFromAPIQuery query)
        {
            var daysToFetch = int.MaxValue;
            var path = $"/data/histoday?fsym={query.BaseCurrency}&tsym={query.QuoteCurrency}";
            if (query.LastTime == null) // fech all data
            {
                path += "&allData=true";
            }
            else 
            {
                var lastAvailable = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 
                    query.LastTime.Value.Hour, query.LastTime.Value.Minute, query.LastTime.Value.Second);
                if (lastAvailable > DateTime.Now) {
                    lastAvailable.AddDays(-1);
                }

                daysToFetch = (lastAvailable.Subtract(query.LastTime.Value)).Days;             
                if (daysToFetch <= 0)
                {
                    return Enumerable.Empty<DailyOHLCV>();
                }

                path += $"&limit={daysToFetch}";
            }

            var fetchDailyOHLCVResponse = HttpClient.GetAsync<FetchDailyOHLCVResponse>(path).Result;
            var dailyOHLCVs = fetchDailyOHLCVResponse.Data.Select(x => new DailyOHLCV
                {
                    BaseCurrency = query.BaseCurrency,
                    QuoteCurrency = query.QuoteCurrency,
                    Time = ConversionUtils.UnixTimeStampToDateTime(x.Time),
                    Open = x.Open,
                    Close = x.Close,
                    High = x.High,
                    VolumeFrom = x.VolumeFrom,
                    VolumeTo = x.VolumeTo
                });
            return dailyOHLCVs.OrderByDescending(x => x.Time).Take(daysToFetch); // doing Take because sometimes the limit param doesn't work
        }
    }
}