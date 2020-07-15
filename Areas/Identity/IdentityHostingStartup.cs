using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ssd_assignment_team1_draft1.Data;
using ssd_assignment_team1_draft1.Models;

[assembly: HostingStartup(typeof(ssd_assignment_team1_draft1.Areas.Identity.IdentityHostingStartup))]
namespace ssd_assignment_team1_draft1.Areas.Identity
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