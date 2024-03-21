using ShopInventory.CoreBusiness;
using ShopInventory.UseCases.Interfaces;
using ShopInventory.UseCases.Products.Interfaces;

namespace ShopInventory.UseCases.Products;

public class ViewProductsCountUseCase : IViewProductsCountUseCase
{
    private readonly IProductsRepository _httpClient;

    public ViewProductsCountUseCase(IProductsRepository httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<int> ExecuteAsync()
    {
        return await _httpClient.GetArtigosCountAsync();
    }
}
