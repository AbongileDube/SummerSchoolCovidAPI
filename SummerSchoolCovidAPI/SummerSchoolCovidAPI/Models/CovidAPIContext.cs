using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SummerSchoolCovidAPI.Models
{
    public class CovidAPIContext : DbContext
    {
        public CovidAPIContext()
        {
        }

        public CovidAPIContext(DbContextOptions<CovidAPIContext> options) : base(options)
        {

        }
        public DbSet<CovidCaseContact> CovidCaseContacts { get; set; }
        public DbSet<InfectedUser> InfectedUsers { get; set; }
        public DbSet<CovidCase> CovidCases { get; set; }
        public DbSet<Location> Locations { get; set; }
      

    }
}
