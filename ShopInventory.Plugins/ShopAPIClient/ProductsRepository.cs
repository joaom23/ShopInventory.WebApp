using Newtonsoft.Json;
using ShopInventory.CoreBusiness;
using ShopInventory.UseCases.Interfaces;

namespace ShopInventory.Plugins.ShopAPIClient;

public class ProductsRepository : IProductsRepository
{
    private readonly HttpClient _httpClient;

    public ProductsRepository()
    {
        _httpClient = new HttpClient();
    }

    public async Task<IEnumerable<Artigo>?> GetArtigosAsync(string? name = null)
    {
        //var response = await _httpClient.GetAsync($"http://apishopinventory.ddns.net:8080/artigos");
        HttpResponseMessage? response;
        
        if (name == null)
        {
            response = await _httpClient.GetAsync("http://localhost:8080/artigos");
        }
        else
        {
            response = await _httpClient.GetAsync($"http://localhost:8080/artigos?name={name}");
        }

        var responseBody = await response.Content.ReadAsStringAsync();
        var artigos = JsonConvert.DeserializeObject<List<Artigo>>(responseBody);

        return artigos;
    }

    public async Task<int> GetArtigosCountAsync()
    {
        var response = await _httpClient.GetAsync($"http://localhost:8080/artigos/count");
        var responseBody = await response.Content.ReadAsStringAsync();
        var count = JsonConvert.DeserializeObject<int>(responseBody);
        return count;
    }
}
