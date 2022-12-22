using Movie.API;

public class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var startup = new Startup(builder.Configuration);
        startup.ConfigureServices(builder.Services);

        builder.Configuration.AddEnvironmentVariables();

        var app = builder.Build();
        startup.Configure(app, builder.Environment);
    }
}

