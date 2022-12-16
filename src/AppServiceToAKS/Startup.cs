using Movie.API.Clients;
using Movie.API.Services;

namespace Movie.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
           services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddHttpClient<IOmdbClient, OmdbClient>(x =>
                x.BaseAddress = new Uri("https://www.omdbapi.com"));

            services.AddSingleton<IWatchedMoviesService, WatchedMoviesService>();
            services.AddSingleton<IWatchListServices, WatchListServices>();

            services.AddHealthChecks();
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapHealthChecks("/hc");

            app.MapControllers();

            app.Run(); 
        }
    }
}
