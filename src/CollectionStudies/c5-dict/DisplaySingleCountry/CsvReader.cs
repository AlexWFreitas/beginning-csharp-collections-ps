using System.IO;
using System.Collections.Generic;

namespace DisplaySingleCountry
{
    class CsvReader
    {
        private string _csvFilePath;

        public CsvReader(string csvFilePath)
        {
            this._csvFilePath = csvFilePath;
        }

        public Dictionary<string, Country> ReadAllCountries()
        {
            var countries = new Dictionary<string, Country>();

            using (StreamReader sr = new StreamReader(_csvFilePath))
            {
                // Reads header line - to skip column names
                sr.ReadLine();

                string csvLine;

                while ((csvLine = sr.ReadLine()) != null)
                {
                    Country country = ReadCountryFromCsvLine(csvLine);
                    countries.Add(country.Code, country);
                }
            }
            return countries;
        }

        public Country ReadCountryFromCsvLine(string csvLine)
        {
            string[] parts = csvLine.Split(',');
            
            string name;
            string code;
            string region;
            string popText;

            switch(parts.Length)
            {
                case 4:
                    name = parts[0];
                    code = parts[1];
                    region = parts[2];
                    popText = parts[3];
                    break;

                case 5:
                    name = parts[0];
                    name += parts[1];
                    code = parts[2];
                    region = parts[3];
                    popText = parts[4];
                    break;

                default:
                    throw new System.Exception($"Can't parse country from csvLine: {csvLine}");
            }

            int.TryParse(popText, out int population);

            return new Country(name, code, region, population);
        }
    }
}
