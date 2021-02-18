using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SummerSchoolCovidAPI.Models.Logic
{
    public class Logic
    {
        private static CovidAPIContext db = new CovidAPIContext();

        public static void updateLocation(string infectedUserId)
        {
            var locId = (from i in db.InfectedUsers
                         where i.Id == infectedUserId
                         select i.LocationId).FirstOrDefault();

            Location loc = db.Locations.Find(locId);
            loc.CNumberInfected += 1;
            db.Entry(loc).State = EntityState.Modified;
            db.SaveChanges();
        }
        public static void updateInfectedUser(string infectedUserId)
        {
            InfectedUser infectedUser = db.InfectedUsers.Find(infectedUserId);
            infectedUser.Infected = true;
            db.Entry(infectedUser).State = EntityState.Modified;
            db.SaveChangesAsync();
        }
    }
}
