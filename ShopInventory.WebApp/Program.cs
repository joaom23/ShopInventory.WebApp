using ShopInventory.Plugins.ShopAPIClient;
using ShopInventory.UseCases.Interfaces;
using ShopInventory.UseCases.Products;
using ShopInventory.UseCases.Products.Interfaces;
using ShopInventory.WebApp.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<IViewListOfProductsUseCase, ViewListOfProductsUseCase>();
builder.Services.AddScoped<IViewProductsCountUseCase, ViewProductsCountUseCase>();

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
