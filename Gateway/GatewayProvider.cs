using System.Net.Http;
using FlespiSharp.Http;

namespace FlespiSharp.Gateway
{
    public class GatewayProvider : PathProvider
    {
        public GatewayProvider(HttpClient client)
            : base(client, PathBuilder.Create("gw"))
        {
        }

        public DevicesProvider Devices => new DevicesProvider(client, builder);
    }

    public static class GatewayExtension{
        public static GatewayProvider CreateGateway(this Connection connection)
            => new GatewayProvider(connection.GetAuthenticatedHttpClient());
    }
}