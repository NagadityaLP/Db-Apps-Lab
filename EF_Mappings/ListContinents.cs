using System;

namespace EF_Mappings
{
    public class ListContinents
    {
        static void Main(string[] args)
        {
            var context = new GeographyEntities();
            foreach (var continent in context.Continents)
                Console.WriteLine(continent.ContinentName);

        }
    }
}
