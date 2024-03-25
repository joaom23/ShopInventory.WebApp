using System.ComponentModel.DataAnnotations;

namespace ShopInventory.WebApp.ViewModels;

public class ArtigoCart
{
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public double Quantity { get; set; }
}
