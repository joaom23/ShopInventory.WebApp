using ShopInventory.UseCases.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;
using ShopInventory.CoreBusiness;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace ShopInventory.Plugins.EmailSender;

public class EmailSender : IEmailSender
{
    public async Task<EmailResponse> SendEmailAsync(EmailModel model)
    {
        var apiKey = Environment.GetEnvironmentVariable("SEND_GRID_KEY");

        var client = new SendGridClient(apiKey);
        var from = new EmailAddress("jmfernandes8@sapo.pt", "João");
        var subject = "Encomenda";
        var to = new EmailAddress("jvfernandes72@gmail.com", "Joaquim");
        var plainTextContent = "Test";

        var htmlBuilder = EmailHtmlBuilder.CreateHtmlContent(model);

        var htmlContent = htmlBuilder.ToString();
        var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        var response = await client.SendEmailAsync(msg);

        //var response = await Task.Run( () => new Response(HttpStatusCode.OK, new StringContent("default"), new HttpResponseMessage().Headers));

        return new EmailResponse
        {
            IsSuccessStatusCode = response.IsSuccessStatusCode,
            StatusCode = response.StatusCode
        };
    }
}
