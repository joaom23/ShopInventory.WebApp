namespace ShopInventory.WebApp;

public static class AppConfig
{
    private static IConfiguration _configuration;

    static AppConfig()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile("appSettings.Development.json", optional: true, reloadOnChange: true);
        _configuration = builder.Build();
    }

    public static string Get(string name)
    {
        string appSettings = _configuration[name];
        return appSettings;
    }
}