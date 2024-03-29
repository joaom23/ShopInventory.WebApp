using ShopInventory.CoreBusiness;

namespace ShopInventory.UseCases.Products.Interfaces;
public interface IViewListOfProductsUseCase
{
    Task<ArtigosResponse?> ExecuteAsync(string? name = null, int? pageNumber = 1, int? pageSize = 10);
}