using System;
using System.Collections.Generic;

namespace ReadCountriesForLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"F:\Workspace\c-sharp-path\beginning-csharp-collections-ps\src\CollectionStudies\Pop by Largest Final.csv";

            CsvReader reader = new CsvReader(filePath);

            List<Country> countries = reader.ReadAllCountries();

            for (int i = 0; i < countries.Count; i++)
            {
                Country country = countries[i];
                Console.WriteLine($@"{PopulationFormatter.FormatPopulation
                    (country.Population).PadLeft(15)} : {country.Name}");
            }
            Console.WriteLine($"\n{(countries.Count).ToString().PadLeft(15)} : Countries on this List");
        }
    }
}
