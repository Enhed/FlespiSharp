using Newtonsoft.Json;

namespace FlespiSharp{
    public sealed class RestResult<T>{
        [JsonProperty("result")]
        public T[] Values;

        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public RestError[] Errors;

        [JsonIgnore]
        public bool HasErrors => Errors?.Length > 0;
    }

    public sealed class RestError
    {
        [JsonProperty("code")]
        public int Code;

        [JsonProperty("id")]
        public int Id;

        [JsonProperty("reason")]
        public string Reason;
    }
}