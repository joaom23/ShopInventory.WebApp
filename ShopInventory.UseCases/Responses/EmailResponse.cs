using System.Net;

namespace ShopInventory.Plugins.EmailSender;

public class EmailResponse
{
    public bool IsSuccessStatusCode { get; set; }
    public HttpStatusCode StatusCode { get; set; }  
}
