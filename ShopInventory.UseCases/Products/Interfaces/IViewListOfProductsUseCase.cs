using ShopInventory.CoreBusiness;

namespace ShopInventory.UseCases.Products.Interfaces;
public interface IViewListOfProductsUseCase
{
    Task<IEnumerable<Artigo>?> Execute();
}