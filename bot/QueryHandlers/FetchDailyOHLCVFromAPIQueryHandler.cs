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
            var fetchDailyOHLCVResponse = HttpClient.GetAsync<FetchDailyOHLCVResponse>("/data/histoday?fsym=BTC&tsym=USD&allData=true").Result;

            return fetchDailyOHLCVResponse.Data.Select(x => new DailyOHLCV
                {
                    BaseCurrency = "BTC", // todo
                    QuoteCurrency = "USD", // todo
                    Time = ConversionUtils.UnixTimeStampToDateTime(x.Time),
                    Open = x.Open,
                    Close = x.Close,
                    High = x.High,
                    VolumeFrom = x.VolumeFrom,
                    VolumeTo = x.VolumeTo
                });
        }
    }
}