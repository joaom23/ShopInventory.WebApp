using EllipticCurve;

namespace ShopInventory.WebApp.Extentions;

public static class HttpClientBuilderExtensions
{
    public static IHttpClientBuilder AddCustomizedHttpClient<TClient, TImplementation>(this IServiceCollection services)
        where TClient : class
        where TImplementation : class, TClient
    {
        return services.AddHttpClient<TClient, TImplementation>(client =>
        {
            int clientTimeout = 1;
            const string ApiUrlVariableName = "API_URL";

            string? apiUrl = Environment.GetEnvironmentVariable(ApiUrlVariableName);

            if(!string.IsNullOrEmpty(apiUrl)) 
            {
                client.BaseAddress = new Uri(apiUrl);
                client.Timeout = TimeSpan.FromMinutes(clientTimeout);
            }
            else
            {
                throw new InvalidOperationException($"Environment variable '{ApiUrlVariableName}' is not set or is empty.");
            }
        });
    }
}
