using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SummerSchoolCovidAPI.Models
{
    public class CovidDbContext : DbContext
    {
        public CovidDbContext(DbContextOptions<CovidDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<CovidCaseContact> CovidCaseContacts { get; set; }
        public DbSet<InfectedUser> InfectedUsers { get; set; }
        public DbSet<CovidCase> CovidCases { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}