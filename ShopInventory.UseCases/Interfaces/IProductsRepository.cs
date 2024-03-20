using ShopInventory.CoreBusiness;

namespace ShopInventory.UseCases.Interfaces;

public interface IProductsRepository
{
    Task<IEnumerable<Artigo>?> GetArtigosAsync();
}
