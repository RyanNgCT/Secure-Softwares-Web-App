using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ssd_assignment_team1_draft1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ssd_assignment_team1_draft1.Data
{
    public class ssd_assignment_team1_draft1Context : IdentityDbContext<ApplicationUser>
    {
        public ssd_assignment_team1_draft1Context (DbContextOptions<ssd_assignment_team1_draft1Context> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }


        public DbSet<ssd_assignment_team1_draft1.Models.Software> Software { get; set; }
    }
}
