using Newtonsoft.Json;
using ShopInventory.CoreBusiness;
using ShopInventory.UseCases.Interfaces;

namespace ShopInventory.Plugins.ShopAPIClient;

public class ProductsRepository : IProductsRepository
{
    private readonly HttpClient _httpClient;

    public ProductsRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ArtigosResponse?> GetArtigosAsync(string? name = null, int? pageNumber = 1, int? pageSize = 10)
    {
        HttpResponseMessage? response;
        
        if (name == null)
        {
            response = await _httpClient.GetAsync($"/artigos?pageNumber={pageNumber}&pageSize={pageSize}");
        }
        else
        {           
            response = await _httpClient.GetAsync($"/artigos?name={name}&pageNumber={pageNumber}&pageSize={pageSize}");
        }

        var responseBody = await response.Content.ReadAsStringAsync();
        var artigos = JsonConvert.DeserializeObject<ArtigosResponse>(responseBody);

        return artigos;
    }

    public async Task<int> GetArtigosCountAsync()
    {
        var response = await _httpClient.GetAsync($"/artigos/count");
        var responseBody = await response.Content.ReadAsStringAsync();
        var count = JsonConvert.DeserializeObject<int>(responseBody);
        return count;
    }
}
