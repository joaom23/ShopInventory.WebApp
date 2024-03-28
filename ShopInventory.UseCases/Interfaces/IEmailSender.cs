using ShopInventory.CoreBusiness;
using ShopInventory.Plugins.EmailSender;

namespace ShopInventory.UseCases.Interfaces;

public interface IEmailSender
{
    Task<EmailResponse> SendEmailAsync(EmailModel model);
}
