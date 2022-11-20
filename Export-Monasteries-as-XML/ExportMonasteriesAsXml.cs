using System;
using System.Linq;
using System.Xml.Linq;
using EF_Mappings;

namespace Export_Monasteries_as_XML
{
    public class ExportMonasteriesAsXml
    {
        static void Main(string[] args)
        {
            var context = new GeographyEntities();
            /*foreach (var monastery in context.Monasteries)
            {
                Console.WriteLine(monastery.Name);
            }*/
            var countriesQuery = context.Countries
                  .OrderBy(c => c.CountryName)
                  .Select(c => new
                  {
                      c.CountryName,
                      Monasteries = c.Monasteries
                      .OrderBy(m => m.Name)
                      .Select(m => m.Name)
                  });
            /*foreach (var country in countriesQuery)
            {
                Console.WriteLine(country.CountryName + " " + string.Join(", ", country.Monasteries));
            }*/

            var countriesWithMonasteries = context.Countries
                .Where(c => c.Monasteries.Any())
                .OrderBy(c => c.CountryName)
                .Select(c => new
                {
                    c.CountryName,
                    Monasteries = c.Monasteries
                    .OrderBy(m => m.Name)
                      .Select(m => m.Name)
                });

            /*foreach (var country in countriesWithMonasteries)
            {
                Console.WriteLine(country.CountryName + " " + string.Join(", ", country.Monasteries));
            }*/

            //Building output XML
            var xmlMonasteries = new XElement("monasteries");
            foreach (var country in countriesQuery)
            {
                var xmlCountry = new XElement("country");
                xmlCountry.Add(new XAttribute("name", country.CountryName));
                xmlMonasteries.Add(xmlCountry);
                foreach (var monastery in country.Monasteries)
                {
                    xmlCountry.Add(new XElement("monastery", monastery));
                }
            }

            var xmlDoc = new XDocument(xmlMonasteries);
            xmlDoc.Save("monasteries.xml");
           
        }
    }
}
