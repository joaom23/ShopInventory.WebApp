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
        var htmlBuilder = new StringBuilder();

        htmlBuilder.AppendLine($@"
        <div style='max-width: 600px; margin: auto; padding: 20px;'>
            <h2 style='color: #333;'>Nova encomenda</h2>
            <p>Cliente: {model.ClientName},</p>
            <table style='width: 100%; border-collapse: collapse;'>
                <thead>
                    <tr>
                        <th style='padding: 10px; border-bottom: 1px solid #ddd; text-align: left;'>Produto</th>
                        <th style='padding: 10px; border-bottom: 1px solid #ddd; text-align: left;'>Quantidadde</th>
                        <th style='padding: 10px; border-bottom: 1px solid #ddd; text-align: left;'>Preço</th>
                    </tr>
                </thead>
            <tbody>");

        foreach (var product in model.Artigos)
        {
            htmlBuilder.AppendLine($@"
                <tr>
                    <td style='padding: 10px; border-bottom: 1px solid #ddd;'>{product.Name}</td>
                    <td style='padding: 10px; border-bottom: 1px solid #ddd;'>{product.Quantity}</td>
                    <td style='padding: 10px; border-bottom: 1px solid #ddd;'>{product.Price}</td>
                </tr>");
        }

        htmlBuilder.AppendLine($@"
                </tbody>
            </table>
            <p style='font-weight: bold;'>Preço total: {model.TotalPrice} €</p>
        </div>");

        var htmlContent = htmlBuilder.ToString();
        var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        var response = await client.SendEmailAsync(msg);

        //var response = new Response(HttpStatusCode.OK, new StringContent("default"), new HttpResponseMessage().Headers);

        return new EmailResponse
        {
            IsSuccessStatusCode = response.IsSuccessStatusCode,
            StatusCode = response.StatusCode
        };
    }
}
