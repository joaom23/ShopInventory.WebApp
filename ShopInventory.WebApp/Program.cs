using ShopInventory.Plugins.EmailSender;
using ShopInventory.Plugins.ShopAPIClient;
using ShopInventory.UseCases.Interfaces;
using ShopInventory.UseCases.Products;
using ShopInventory.UseCases.Products.Interfaces;
using ShopInventory.WebApp.Components;
using ShopInventory.WebApp.Extentions;
using ShopInventory.WebApp.Services;
using ShopInventory.WebApp.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
services.AddRazorComponents()
    .AddInteractiveServerComponents();

services.AddCustomizedHttpClient<IProductsRepository, ProductsRepository>();
services.AddScoped<IViewListOfProductsUseCase, ViewListOfProductsUseCase>();
services.AddScoped<IViewProductsCountUseCase, ViewProductsCountUseCase>();
services.AddScoped<ICartState, CartState>();
services.AddSingleton<IEmailSender, EmailSender>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
