namespace ShopInventory.CoreBusiness;

public class EmailModel
{
    public ICollection<ArtigoCart> Artigos { get; set; } = [];
    public string ClientName { get; set; } = string.Empty;
    public double TotalPrice { get; set; }
}
