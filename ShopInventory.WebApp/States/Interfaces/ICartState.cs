﻿using Microsoft.AspNetCore.Components;
using ShopInventory.CoreBusiness;

namespace ShopInventory.WebApp.Services.Interfaces;
public interface ICartState
{
    void AddItem(Artigo artigo);
    void RemoveItem(ArtigoCart artigo); 
    ICollection<ArtigoCart>? FetchArtigosCart();
    void RemoveAllItems();
    IDisposable NotifyOnChange(EventCallback callback);
}