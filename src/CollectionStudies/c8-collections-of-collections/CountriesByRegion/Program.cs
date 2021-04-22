using System;
using System.Collections.Generic;
using System.Linq;

namespace CountriesByRegion
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"F:\Workspace\c-sharp-path\beginning-csharp-collections-ps\src\CollectionStudies\Pop by Largest Final.csv";

            CsvReader reader = new CsvReader(filePath);

            var countries = reader.ReadAllCountries();

            //foreach (Country country in countries.OrderBy(country => country.Name).Take(10))

            // Method Syntax
            IEnumerable<Country> filteredCountries = countries.Where(country => !country.Name.Contains(',')).Take(20);

            // Query Syntax
            var filteredCountries2 = from country in countries
                                     where !country.Name.Contains(',')
                                     select country;

            foreach (Country country in filteredCountries2)
            {
                Console.WriteLine($@"{PopulationFormatter.FormatPopulation
                    (country.Population).PadLeft(15)} : {country.Name}");
            }
        }
    }
}
