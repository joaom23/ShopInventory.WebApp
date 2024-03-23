using Microsoft.AspNetCore.Components;
using ShopInventory.WebApp.Services;

namespace ShopInventory.WebApp.States.Events;

public class BasketStateChangedSubscription(CartState Owner, EventCallback Callback) : IDisposable
{
    public async Task NotifyAsync() => await Callback.InvokeAsync();
    public void Dispose() { Owner.ChangeSubscriptions.Remove(this); }
}