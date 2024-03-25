using Newtonsoft.Json.Linq;
using System.Runtime.CompilerServices;

namespace ShopInventory.WebApp.Extentions;

public static class DoubleExtentions
{
    public static string FormatPrice(this double value)
    {
        return $"{value:F2}";
    }
}
