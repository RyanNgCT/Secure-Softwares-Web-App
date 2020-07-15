using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ssd_assignment_team1_draft1.Models;

namespace ssd_assignment_team1_draft1.Data
{
    public class ssd_assignment_team1_draft1Context : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ssd_assignment_team1_draft1Context (DbContextOptions<ssd_assignment_team1_draft1Context> options)
            : base(options)
        {
        }

        public DbSet<ssd_assignment_team1_draft1.Models.Software> Software { get; set; }
    }
}
