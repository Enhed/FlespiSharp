using System;
using Newtonsoft.Json;

namespace FlespiSharp.Gateway
{
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

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int? Id;

        [JsonProperty("messages_size", NullValueHandling = NullValueHandling.Ignore)]
        public int? MessagesSize;

        [JsonProperty("settings", NullValueHandling = NullValueHandling.Ignore)]
        public object Settings;
    }
}