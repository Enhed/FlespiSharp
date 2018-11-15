using System.Net;

namespace FlespiSharp.Http{
    public sealed class PathBuilder{

        private readonly string path;

        public PathBuilder(string path){
            this.path = path;
        }

        public PathBuilder AppendPath(string value){
            return new PathBuilder( $"{path}/{WebUtility.UrlEncode(value)}" );
        }

        public override string ToString()
            => path;

        public static PathBuilder Create(string path){
            if(!path.StartsWith("/")) path = $"/{path}";
            return new PathBuilder(path);
        }
    }
}