using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace FlespiSharp
{
    public sealed class Connection : IDisposable
    {
        private const string headerName = "FlespiToken";
        private const string baseAddress = "https://flespi.io";
        private readonly string token;
        private readonly HttpClient httpClient;

        public Connection(string token){

            if (string.IsNullOrWhiteSpace(token))
            {
                throw new ArgumentException("message", nameof(token));
            }

            this.token = token;

            httpClient = new HttpClient{
                BaseAddress = new Uri(baseAddress)
            };

            var header = new AuthenticationHeaderValue(headerName, token);
            httpClient.DefaultRequestHeaders.Authorization = header;
        }

        public HttpClient GetAuthenticatedHttpClient() => httpClient;

        public void Dispose()
        {
            httpClient.Dispose();
        }
    }
}