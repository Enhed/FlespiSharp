using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace FlespiSharp.Http{
    public abstract class RestProvider{
        private readonly Connection connection;

        protected RestProvider(Connection connection) =>
            this.connection = connection ?? throw new System.ArgumentNullException(nameof(connection));

        protected Task<RestResult<T>> Get<T>(string uri){
            return GetRestResult<T>( x => x.GetAsync(uri) );
        }

        protected Task<RestResult<T>> Post<T, TInput>(TInput data, string uri){
            var content = CreateContent(data);
            return GetRestResult<T>( x => x.PostAsync(uri, content) );
        }

        protected Task<RestResult<T>> Put<T, TInput>(TInput data, string uri){
            var content = CreateContent(data);
            return GetRestResult<T>( x => x.PutAsync(uri, content) );
        }

        protected Task<RestResult<T>> Delete<T>(string uri){
            return GetRestResult<T>( x => x.DeleteAsync(uri) );
        }

        private HttpContent CreateContent<T>(T data){
            var json = JsonConvert.SerializeObject(data);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private async Task<RestResult<T>> GetRestResult<T>(Func<HttpClient, Task<HttpResponseMessage>> getter){
            using(var response = (await getter(connection.GetAuthenticatedHttpClient())).EnsureSuccessStatusCode())
                    return JsonConvert.DeserializeObject<RestResult<T>>(await response.Content.ReadAsStringAsync());
        }
    }
}