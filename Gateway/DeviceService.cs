using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FlespiSharp.Http;

namespace FlespiSharp.Gateway
{
    public class DeviceService : RestProvider
    {
        public DeviceService(Connection connection) : base(connection) { }

        private const string basePath = "gw/devices";

        public Task<RestResult<Device>> Get(string selector = "all", string parameters = null)
            => Get<Device>($"{basePath}/{selector}{(parameters == null ? null : $"?{parameters}")}");

        public Task<RestResult<Device>> Get(int[] ids, string parameters = null){
            var selector = string.Join(",", ids.Select(id => id.ToString()));
            return Get<Device>($"{basePath}/{selector}{(parameters == null ? null : $"?{parameters}")}");
        }

        public Task<RestResult<Device>> Get(int id, string parameters = null)
            => Get( new [] { id }, parameters );

        public Task<RestResult<Device>> Create(Device[] devices, string parameters = null){
            return Post<Device, Device[]>(devices,
                parameters == null ? basePath : $"{basePath}?{parameters}");
        }

        public Task<RestResult<Device>> Create(Device device, string parameters = null)
            => Create(new [] { device }, parameters);

        public Task<RestResult<Device>> Delete(string selector, string parameters = null){
            if (string.IsNullOrWhiteSpace(selector))
            {
                throw new ArgumentException("message", nameof(selector));
            }

            return Delete<Device>($"{basePath}/{selector}{(parameters == null ? null : $"?{parameters}")}");
        }

        public Task<RestResult<Device>> Delete(int[] ids, string parameters = null){
            var selector = string.Join(",", ids.Select(id => id.ToString()));
            return Delete(selector, parameters);
        }

        public Task<RestResult<Device>> Delete(int id, string parameters = null) => Delete(new [] { id }, parameters);
    }
}