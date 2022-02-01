using System;
using Report.Areas.Identity.Data;
using Report.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Report.Areas.Identity.IdentityHostingStartup))]
namespace Report.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<FeedbackPortalContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("FeedbackPortalContext")));

            });
        }
    }
}