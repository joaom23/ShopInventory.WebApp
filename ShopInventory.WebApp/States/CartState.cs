using Microsoft.AspNetCore.Components;
using ShopInventory.CoreBusiness;
using ShopInventory.WebApp.Services.Interfaces;
using ShopInventory.WebApp.States.Events;

namespace ShopInventory.WebApp.Services;

public class CartState : ICartState
{
    private readonly ICollection<ArtigoCart> _artigoCart;
    public HashSet<BasketStateChangedSubscription> ChangeSubscriptions = new();

    public CartState()
    {
        _artigoCart = [];
    }

    public IDisposable NotifyOnChange(EventCallback callback)
    {
        var subscription = new BasketStateChangedSubscription(this, callback);
        ChangeSubscriptions.Add(subscription);
        return subscription;
    }

    public ICollection<ArtigoCart>? FetchArtigosCart()
    {
        return _artigoCart;
    }

    public void AddItem(Artigo artigo)
    {
        var artigoInTheBasket = _artigoCart.FirstOrDefault(x => x.Name == artigo.Name);

        if (artigoInTheBasket == null) 
        {
            _artigoCart.Add(new ArtigoCart
            {
                Price = artigo.Price,
                Quantity = 1, 
                Name = artigo.Name,
            });
        }
        else
        {
            artigoInTheBasket.Quantity++;
        }

        NotifyChangeSubscribers();
    }


    public void RemoveItem(ArtigoCart artigo)
    {
        _artigoCart.Remove(artigo);
        NotifyChangeSubscribers();
    }

    public void RemoveAllItems()
    {
        _artigoCart.Clear();
        NotifyChangeSubscribers();
    }

    private Task NotifyChangeSubscribers() => Task.WhenAll(ChangeSubscriptions.Select(s => s.NotifyAsync()));
}
