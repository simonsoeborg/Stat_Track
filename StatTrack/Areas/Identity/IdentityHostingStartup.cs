using Microsoft.AspNetCore.Hosting;
using StatTrack.Areas.Identity;

[assembly: HostingStartup(typeof(IdentityHostingStartup))]

namespace StatTrack.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => { });
        }
    }
}