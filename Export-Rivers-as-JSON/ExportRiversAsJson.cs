using EF_Mappings;
using System.Linq;
using System;
using System.Web.Script.Serialization;
using System.IO;

namespace Export_Rivers_as_JSON
{
    public class ExportRiversAsJson
    {
        static void Main(string[] args)
        {
            var context = new GeographyEntities();
            
            var rivers = context.Rivers.Select(r =>
            new
            {
                r.RiverName,
                r.Length,
                Countries = r.Countries.Select(c => c.CountryName)
            });

            var riversQuery = context.Rivers
                .OrderByDescending(r => r.Length)
                .Select(r => new
                {
                    r.RiverName,
                    r.Length,
                    Countries = r.Countries
                        .OrderBy(c => c.CountryName)
                        .Select(c => c.CountryName)
                });


            foreach (var river in riversQuery)
            {
                Console.WriteLine(river.RiverName);
            }

            var jsSerializer = new JavaScriptSerializer();
            var riversJson = jsSerializer.Serialize(riversQuery.ToList());
            Console.WriteLine(riversJson);

            File.WriteAllText(@"C:\Users\Admin\Documents\Pratian_Training\.NET Framework\C#_Start_Project_12_9_22\Db-Apps-Lab\jsonOutput.txt", riversJson);
        }
    }
}
