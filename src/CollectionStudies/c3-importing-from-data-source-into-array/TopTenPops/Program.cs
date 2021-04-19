using System;

namespace TopTenPops
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"F:\Workspace\c-sharp-path\beginning-csharp-collections-ps\src\CollectionStudies\Pop by Largest Final.csv";

            CsvReader reader = new CsvReader(filePath);

            Country[] countries = reader.ReadFirstNCountries(10);

            foreach (Country country in countries)
            {
                Console.WriteLine($@"{PopulationFormatter.FormatPopulation
                    (country.Population).PadLeft(15)} : {country.Name}");
            }
        }
    }
}
