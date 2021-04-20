using System;
using System.Collections.Generic;

namespace DictSnippets
{
    class Program
    {
        static void Main(string[] args)
        {
            Country norway = new Country("Norway", "NOR", "Europe", 5_282_223);
            Country finland = new Country("Finland", "FIN", "Europe", 5_511_303);

            Dictionary<string, Country> countries = new Dictionary<string, Country>
            {
                { norway.Code, norway },
                { finland.Code, finland }
            };

            foreach (Country country in countries.Values)
                Console.WriteLine(country.Name);

            //Country selectedCountry = countries["NOR"];

            // Explanation about trying to use the value of a key that doesn't exist

            // Will throw exception
            // Console.WriteLine(countries["MUS"].Name);
            
            // Won't throw exception - Because it checks if the key / value exists.
            {
                bool exists = countries.TryGetValue("MUS", out Country country);
                if (exists)
                    Console.WriteLine("\n" + country.Name);
                else
                    Console.WriteLine("\nThere is no country with the code MUS");
            }



        }
    }
}
