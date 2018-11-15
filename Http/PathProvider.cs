using System.Net.Http;

namespace FlespiSharp.Http{
    public abstract class PathProvider{
        protected readonly PathBuilder builder;
        protected readonly HttpClient client;

        protected PathProvider(HttpClient client, PathBuilder builder){
            this.builder = builder;
            this.client = client;
        }

        public string GetCurrentPath() => builder.ToString();
    }
}