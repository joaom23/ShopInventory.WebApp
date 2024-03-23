using Microsoft.AspNetCore.Components;
using ShopInventory.CoreBusiness;

namespace ShopInventory.WebApp.Services.Interfaces;
public interface ICartState
{
    void AddItem(Artigo artigo);
    void RemoveItem(Artigo artigo); 
    ICollection<Artigo>? FetchArtigosCart();
    IDisposable NotifyOnChange(EventCallback callback);
}