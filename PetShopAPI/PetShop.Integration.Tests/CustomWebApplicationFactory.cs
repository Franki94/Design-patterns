using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using PetShopAPI;

namespace PetShop.Integration.Tests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<Startup>
    {
        public CustomWebApplicationFactory()
        {
        }
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var servicePetShop = new ServiceCollection()
               .AddEntityFrameworkInMemoryDatabase()
               .BuildServiceProvider();

                //services.AddDbContext<>

            });
            base.ConfigureWebHost(builder);
        }
    }
}
