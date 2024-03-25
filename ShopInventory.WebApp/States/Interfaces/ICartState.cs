using Microsoft.AspNetCore.Components;
using ShopInventory.CoreBusiness;
using ShopInventory.WebApp.ViewModels;

namespace ShopInventory.WebApp.Services.Interfaces;
public interface ICartState
{
    void AddItem(Artigo artigo);
    void RemoveItem(ArtigoCart artigo); 
    ICollection<ArtigoCart>? FetchArtigosCart();
    IDisposable NotifyOnChange(EventCallback callback);
}