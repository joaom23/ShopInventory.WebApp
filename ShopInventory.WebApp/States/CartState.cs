using Microsoft.AspNetCore.Components;
using ShopInventory.CoreBusiness;
using ShopInventory.WebApp.Services.Interfaces;
using ShopInventory.WebApp.States.Events;

namespace ShopInventory.WebApp.Services;

public class CartState : ICartState
{
    private readonly ICollection<Artigo> _artigoBasket;
    public HashSet<BasketStateChangedSubscription> ChangeSubscriptions = new();

    public CartState()
    {
        _artigoBasket = [];
    }

    public IDisposable NotifyOnChange(EventCallback callback)
    {
        var subscription = new BasketStateChangedSubscription(this, callback);
        ChangeSubscriptions.Add(subscription);
        return subscription;
    }

    public ICollection<Artigo>? FetchArtigosCart()
    {
        return _artigoBasket;
    }

    public void AddItem(Artigo artigo)
    {
        _artigoBasket.Add(artigo);
        NotifyChangeSubscribers();
    }

    private Task NotifyChangeSubscribers() => Task.WhenAll(ChangeSubscriptions.Select(s => s.NotifyAsync()));

    public void RemoveItem(Artigo artigo)
    {
        _artigoBasket.Remove(artigo);
        NotifyChangeSubscribers();
    }
}
