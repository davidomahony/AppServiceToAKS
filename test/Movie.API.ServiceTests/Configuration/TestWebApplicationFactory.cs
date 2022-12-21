using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Movie.API.Clients;
using Movie.API.ServiceTests.MockClients;

namespace Movie.API.Tests.Configuration
{
    public class TestWebApplicationFactory : WebApplicationFactory<Program> 
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                var serviceProvider = services.BuildServiceProvider();
                var descriptor = new ServiceDescriptor(typeof(IOmdbClient), typeof(MockOmdbClient), ServiceLifetime.Transient);
                services.Replace(descriptor);
            });
        }
    }
}
