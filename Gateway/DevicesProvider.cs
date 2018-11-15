using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FlespiSharp.Http;

namespace FlespiSharp.Gateway
{
    public class DevicesProvider : RestProvider
    {
        public DevicesProvider(HttpClient client, PathBuilder builder)
            : base(client, builder.AppendPath("devices"))
        {
        }

        public Task<RestResult<Device>> Create(Device[] devices, string parameters = null){
            return Post<Device, Device[]>(devices, parameters);
        }

        public Task<RestResult<Device>> Create(Device device, string parameters = null){
            return Create( new [] { device }, parameters );
        }

        public DevicesService Ident(string value) => Selector($"ident={value}");

        public DevicesService All => Selector("all");
        public DevicesService Ids(int[] values)
            => Selector(string.Join(",", values.Select(v => v.ToString())));
        public DevicesService Id(int value) => Selector(value.ToString());
        public DevicesService Name(string name) => Selector($"name={name}");

        public DevicesService Selector(string selector)
            => new DevicesService(client, builder.AppendPath(selector));
    }
}