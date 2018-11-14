using Newtonsoft.Json;

namespace FlespiSharp{
    public sealed class RestResult<T>{
        [JsonProperty("result")]
        public T Value;
    }
}