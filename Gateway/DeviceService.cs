using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FlespiSharp.Http;
using Newtonsoft.Json;

namespace FlespiSharp.Gateway{
    public class DeviceService : RestProvider
    {
        public DeviceService(Connection connection) : base(connection) { }

        private const string basePath = "gw/devices";

        public Task<RestResult<Device>> Get(string selector = "all", string parameters = null){
            return Get<Device>($"{basePath}/{selector}{(parameters == null ? null : $"?{parameters}")}");
        }

        public Task<RestResult<Device>> Create(Device[] devices, string parameters = null){
            return Post<Device, Device[]>(devices,
                parameters == null ? basePath : $"{basePath}?{parameters}");
        }

        public Task<RestResult<Device>> Create(Device device, string parameters = null){
            return Create(new [] { device }, parameters);
        }
    }

    public class Device
    {
        [JsonProperty("device_type_id", NullValueHandling = NullValueHandling.Ignore)]
        public int? TypeId;

        [JsonProperty("ident", NullValueHandling = NullValueHandling.Ignore)]
        public string Ident;

        [JsonProperty("messages_ttl", NullValueHandling = NullValueHandling.Ignore)]
        public int? MessagesSecondsTTL;

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name;

        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        public string Phone;

        [JsonIgnore]
        public TimeSpan? MessagesTTL{
            get{
                return MessagesSecondsTTL == null
                    ? (TimeSpan?) null
                    : TimeSpan.FromSeconds(MessagesSecondsTTL.Value);
            }
            set{
                MessagesSecondsTTL = (int) value?.TotalSeconds;
            }
        }
    }
}