// See https://aka.ms/new-console-template for more information

using IdentityModel.Client;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();

            var discoveryDocument = await client.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = "http://localhost:7269",
                Policy =
                {
                    ValidateIssuerName = false,
                    RequireHttps = false,
                    RequireKeySet = false  
                }
            });

            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = discoveryDocument.TokenEndpoint,
                ClientId = "client",
                ClientSecret = "H+ Sport",
                Scope = "hps-api"
            });
            Console.WriteLine($"Token : {tokenResponse}");
        }
    }
}
