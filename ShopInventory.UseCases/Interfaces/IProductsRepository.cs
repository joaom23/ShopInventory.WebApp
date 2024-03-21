using ShopInventory.CoreBusiness;

namespace ShopInventory.UseCases.Interfaces;

public interface IProductsRepository
{
    Task<IEnumerable<Artigo>?> GetArtigosAsync(string? name = null);
    Task<int> GetArtigosCountAsync();
}
