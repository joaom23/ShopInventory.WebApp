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

    public async Task<IEnumerable<Artigo>?> GetArtigosAsync()
    {
        //var response = await _httpClient.GetAsync($"http://apishopinventory.ddns.net:8080/artigos");
        var response = await _httpClient.GetAsync($"http://localhost:8080/artigos");
        var responseBody = await response.Content.ReadAsStringAsync();
        var artigos = JsonConvert.DeserializeObject<List<Artigo>>(responseBody);

        return artigos;
    }
}
