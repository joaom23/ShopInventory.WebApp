using ShopInventory.CoreBusiness;

namespace ShopInventory.UseCases.Interfaces;

public interface IProductsRepository
{
    Task<ArtigosResponse?> GetArtigosAsync(string? name = null, int? pageNumber = 1, int? pageSize = 10);
    Task<int> GetArtigosCountAsync();
}
