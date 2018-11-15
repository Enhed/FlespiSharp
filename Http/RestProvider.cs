using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Net;

namespace FlespiSharp.Http{
    public abstract class RestProvider : PathProvider
    {
        private string uri => builder.ToString();

        protected RestProvider(HttpClient client, PathBuilder builder)
            : base(client, builder)
        {
        }

        protected Task<RestResult<T>> Get<T>(string parameters = null){
            return GetRestResult<T>( x => x.GetAsync(CreateUri(parameters)) );
        }

        protected Task<RestResult<T>> Post<T, TInput>(TInput data, string parameters = null){
            var content = CreateContent(data);
            return GetRestResult<T>( x => x.PostAsync(CreateUri(parameters), content) );
        }

        protected Task<RestResult<T>> Put<T, TInput>(TInput data, string parameters = null){
            var content = CreateContent(data);
            return GetRestResult<T>( x => x.PutAsync(CreateUri(parameters), content) );
        }

        protected Task<RestResult<T>> Delete<T>(string parameters = null){
            return GetRestResult<T>( x => x.DeleteAsync(CreateUri(parameters)) );
        }

        private HttpContent CreateContent<T>(T data){
            var json = JsonConvert.SerializeObject(data);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private string CreateUri(string parameters = null){

            var uri = string.IsNullOrWhiteSpace(parameters) ? builder.ToString()
                : $"{builder.ToString()}?{WebUtility.UrlEncode(parameters)}";

            Console.WriteLine($"Create Uri: {uri}");

            return uri;
        }

        private async Task<RestResult<T>> GetRestResult<T>(Func<HttpClient, Task<HttpResponseMessage>> getter){
            using(var response = (await getter(client)).EnsureSuccessStatusCode())
                    return JsonConvert.DeserializeObject<RestResult<T>>(await response.Content.ReadAsStringAsync());
        }
    }
}