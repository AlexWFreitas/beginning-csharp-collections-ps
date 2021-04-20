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
            reader.RemoveCommaCountries(countries);




            Console.Write("Enter no. of countries to display per batch >");
            bool inputIsInt = int.TryParse(Console.ReadLine(), out int userInput);
            if (!inputIsInt || userInput <= 0)
            {
                Console.WriteLine("You must type in an integer. Exiting program...");
                return;
            }

            int maxToDisplay = userInput;

            for (int i = (countries.Count - 1); i >= 0; i--)
            {
                int displayIndex = countries.Count - 1 - i;
                if (displayIndex > 0 && (displayIndex % maxToDisplay == 0))
                {
                    Console.Write("Hit return to continue, anything else to quit >");
                    if (Console.ReadLine() != "")
                        break;
                }
                Country country = countries[i];
                Console.WriteLine($@"{(displayIndex + 1).ToString().PadRight(3)}{PopulationFormatter.FormatPopulation
                    (country.Population).PadLeft(15)} : {country.Name}");
            }

            //for (int i = (countries.Count - 1); i >= 0; i--)
            //{
            //    int displayIndex = countries.Count - 1 - i;
            //    if (displayIndex > 0 && (displayIndex % maxToDisplay == 0))
            //    {
            //        Console.Write("Hit return to continue, anything else to quit >");
            //        if (Console.ReadLine() != "")
            //            break;
            //    }
            //    Country country = countries[i];
            //    Console.WriteLine($@"{(displayIndex + 1).ToString().PadRight(3)}{PopulationFormatter.FormatPopulation
            //        (country.Population).PadLeft(15)} : {country.Name}");
            //}
        }
    }
}
