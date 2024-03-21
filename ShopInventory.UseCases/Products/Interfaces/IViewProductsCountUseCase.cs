
namespace ShopInventory.UseCases.Products;

public interface IViewProductsCountUseCase
{
    Task<int> ExecuteAsync();
}