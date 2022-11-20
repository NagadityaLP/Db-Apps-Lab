using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Mountains_Code_First
{
    public class MountainsCodeFirst
    {
        static void Main(string[] args)
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MountainsContext>());
            Database.SetInitializer(new MountainsMigrationStrategy());
           
            Country c = new Country() { Code = "AB", Name = "Absurdistan" };
            Mountain m = new Mountain() { Name = "Absurdistan Hills" };
            m.Peaks.Add(new Peak() { Name = "Great Peak", Mountain = m });
            m.Peaks.Add(new Peak() { Name = "Small Peak", Mountain = m });
            c.Mountains.Add(m);

            var context = new MountainsContext();
            context.Countries.Add(c);
            context.SaveChanges();
        }
    }
}
