namespace Api;

public class Program
{
    public static async Task Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();

        await host.RunAsync();
    }

    private static string GetHostPort()
    {
        var h = new WebHostBuilder();
        var EnvironmentName = h.GetSetting("environment");
        var config = new ConfigurationBuilder()
            .AddJsonFile($"appsettings.{EnvironmentName}.json", true)
            .AddJsonFile("appsettings.json", true)
            .AddEnvironmentVariables()
            .Build();

        var applicationUrl = config["AppSettings:applicationUrl"];

        return applicationUrl ?? "https://localhost:5001;http://localhost:5000";
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseUrls(GetHostPort()).UseStartup<Startup>();
            })
            .UseDefaultServiceProvider(options => options.ValidateScopes = false);;
    }
}