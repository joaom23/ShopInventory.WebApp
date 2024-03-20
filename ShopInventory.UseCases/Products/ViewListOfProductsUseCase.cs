using ShopInventory.CoreBusiness;
using ShopInventory.UseCases.Interfaces;
using ShopInventory.UseCases.Products.Interfaces;

namespace ShopInventory.UseCases.Products;

public class ViewListOfProductsUseCase : IViewListOfProductsUseCase
{
    private readonly IProductsRepository _httpClient;

    public ViewListOfProductsUseCase(IProductsRepository httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Artigo>?> Execute()
    {
        return await _httpClient.GetArtigosAsync();
    }
}
