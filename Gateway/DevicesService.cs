using System.Net.Http;
using System.Threading.Tasks;
using FlespiSharp.Http;

namespace FlespiSharp.Gateway
{
    public sealed class DevicesService : RestProvider
    {
        public DevicesService(HttpClient client, PathBuilder builder)
            : base(client, builder)
        {
        }

        public Task<RestResult<Device>> Get(string parameters = null){
            return Get<Device>(parameters);
        }

        public Task<RestResult<int>> Delete(string parameters = null){
            return Delete<int>(parameters);
        }
    }
}