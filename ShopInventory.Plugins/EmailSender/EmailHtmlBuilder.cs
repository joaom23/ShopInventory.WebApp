using ShopInventory.CoreBusiness;
using System.Reflection;
using System.Text;

namespace ShopInventory.Plugins.EmailSender;

public static class EmailHtmlBuilder
{
    public static StringBuilder CreateHtmlContent(EmailModel model)
    {
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
            <tbody>
        ");

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

        return htmlBuilder;
    }
}
