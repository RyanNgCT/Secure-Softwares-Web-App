using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ssd_assignment_team1_draft1.Data;

namespace ssd_assignment_team1_draft1.Models
{
    public static class SeedData
    {
        public static void Initiliaze(IServiceProvider serviceProvider)
        {
            using(var context = new ssd_assignment_team1_draft1Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ssd_assignment_team1_draft1Context>>()))
            {
                if (context.Software.Any())
                {
                    return;
                }

                context.Software.AddRange(
                    new Software
                    {
                        Name = "Visual Studio",
                        Hash = "6a662b05aa9ecd075a9042a1be0625d9",
                        Price = 0,
                        ReleaseDate = DateTime.Parse("2011-1-11"),
                        SerialNumber = 12349876,
                        WarrantyPeriod = 3
                    },
                    new Software
                    {
                        Name = "McAfee Livesafe",
                        Hash = "89ef2c7ba57c23bd05ebd738340a9545",
                        Price = 50,
                        ReleaseDate = DateTime.Parse("2012-5-29"),
                        SerialNumber = 50289065,
                        WarrantyPeriod = 6
                    },
                    new Software
                    {
                        Name = "SQL Server Developer",
                        Hash = "b79c7ed8b38c4c3a7091885753ffdc24",
                        Price = 15,
                        ReleaseDate = DateTime.Parse("2015-9-02"),
                        SerialNumber = 72940301,
                        WarrantyPeriod = 5
                    },
                    new Software
                    {
                        Name = "AzureDevOps Server",
                        Hash = "6326659aceb0f201d5931cadbc347412",
                        Price = 20,
                        ReleaseDate = DateTime.Parse("2017-4-30"),
                        SerialNumber = 65923011,
                        WarrantyPeriod = 6
                    },
                    new Software
                    {
                        Name = "Machine Learning Server",
                        Hash = "fd289240f0d92d51f607caee99670861",
                        Price = 10,
                        ReleaseDate = DateTime.Parse("2016-11-23"),
                        SerialNumber = 09128734,
                        WarrantyPeriod = 3
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
