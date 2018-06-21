using System.Threading.Tasks;

namespace HttpClientLogic
{
    public interface IHttpClient
    {
        Task<T> GetAsync<T>(string path) where T : class;
    }
}