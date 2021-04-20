using System;
using System.Collections.Generic;

namespace DisplaySingleCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"F:\Workspace\c-sharp-path\beginning-csharp-collections-ps\src\CollectionStudies\Pop by Largest Final.csv";

            CsvReader reader = new CsvReader(filePath);

            Dictionary<string, Country> countries = reader.ReadAllCountries();

            Console.WriteLine("Which country code do you want to look up? ");
            string userInput = Console.ReadLine();

            countries.TryGetValue(userInput, out Country country);
            if (country == null)
                Console.WriteLine($"Sorry, there is no country with code {userInput}");
            else
                Console.WriteLine($"{country.Name} has population of {PopulationFormatter.FormatPopulation(country.Population)}");                
        }
    }
}
