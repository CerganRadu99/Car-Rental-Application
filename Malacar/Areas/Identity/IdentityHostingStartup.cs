using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Malacar.Areas.Identity.IdentityHostingStartup))]
namespace Malacar.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}