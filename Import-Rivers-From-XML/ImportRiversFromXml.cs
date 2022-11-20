using EF_Mappings;
using System;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Import_Rivers_From_XML
{
    public class ImportRiversFromXml
    {
        static void Main(string[] args)
        {
            var xmlDoc = XDocument.Load(@"..\..\rivers.xml");
            var riverNodes = xmlDoc.XPathSelectElements("/rivers/river");
            foreach (var riverNode in riverNodes)
            {
                string riverName = riverNode.Element("name").Value;
                int riverLength = int.Parse(riverNode.Element("length").Value);
                string riverOutflow = riverNode.Element("outflow").Value;
                int? riverDrainageArea = null;
                int? riverAverageDischarge = null;
                if (riverNode.Element("drainage-area") != null)
                    riverDrainageArea = int.Parse(riverNode.Element("drainage-area").Value);
                if (riverNode.Element("average-discharge") != null)
                    riverAverageDischarge = int.Parse(riverNode.Element("average-discharge").Value);

                Console.WriteLine(riverName + " " + riverLength + " " + riverOutflow + " " + riverDrainageArea + " " + riverAverageDischarge);

                var countryNodes = riverNode.XPathSelectElements("countries/country");
                var countryNames = countryNodes.Select(c => c.Value);

                Console.WriteLine(riverName + " -> " + string.Join(", ", countryNames));

                var context = new GeographyEntities();
                var river = new River()
                {
                    RiverName = riverName,
                    Length = riverLength,
                    Outflow = riverOutflow,
                    DrainageArea = riverDrainageArea,
                    AverageDischarge = riverAverageDischarge
                };

                foreach (var countryName in countryNames)
                {
                    var country = context.Countries
                        .FirstOrDefault(c => c.CountryName == countryName);
                    river.Countries.Add(country);
                }
                context.Rivers.Add(river);
                context.SaveChanges();
            }

        }
    }
}
