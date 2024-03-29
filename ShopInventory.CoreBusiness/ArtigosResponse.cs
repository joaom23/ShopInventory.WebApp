namespace ShopInventory.CoreBusiness;

public class ArtigosResponse
{
    public List<Artigo> Artigos { get; set; } = new();
    public int TotalCount { get; set; }
    public int PageSize { get; set; }
    public int CurrentPage { get; set; }
}
