using System;


namespace CountriesByRegion
{
    class PopulationFormatter
    {
        public static string FormatPopulation(int population)
        {
            if (population == 0)
                return "(Unknown)";

            int popRounded = RoundPopulation4(population);

            return $"{popRounded: ### ### ### ###}".Trim();
        }

        /// <summary>
        /// Rounds the population displaying only the first four significant digits
        /// </summary>
        /// <param name="population">Total population</param>
        /// <returns></returns>
        private static int RoundPopulation4(int population)
        {
			int accuracy = Math.Max((int)(GetLowestPowerOfTenLargerThan(population) / 10_000L), 1);
			return RoundToNearest(population, accuracy);
        }

		/// <summary>
		/// Rounds the number to the specified accuracy
		/// For example, if the accuracy is 10, then we round to the nearest 10:
		///     23 -> 20 (rounded to nearest 10)
		///     25 -> 30 (rounded to nearest 10)
		///     etc.
		/// Note that we are following the convention that 0.5 rounds up to 1, but anything below 0.5 rounds down
		/// </summary>
		/// <param name="exact">The number to be rounded</param>
		/// <param name="accuracy">The required accuracy</param>
		/// <returns>The number rounded to the specified accuracy</returns>
		public static int RoundToNearest(int exact, int accuracy)
		{
			int adjusted = exact + accuracy / 2;
			return adjusted - adjusted % accuracy;
		}

		/// <summary>
		/// Returns the lowest number that is a power of 10 and is larger than the value supplied 
		/// <br></br>
		/// Examples:
		/// <br></br>
		/// GetLowestPowerOfTenLargerThan(11) = 100
		/// <br></br>
		/// GetLowestPowerOfTenLargerThan(99) = 100
		/// <br></br>
		/// GetLowestPowerOfTenLargerThan(100) = 1000
		/// <br></br>
		/// GetLowestPowerOfTenLargerThan(843) = 1000
		/// <br></br>
		/// GetLowestPowerOfTenLargerThan(1000) = 10000
		/// </summary>
		/// <param name="number"></param>
		/// <returns></returns>
		public static long GetLowestPowerOfTenLargerThan(int x)
		{
			long result = 1;
			while (x > 0)
			{
				x /= 10;
				result *= 10;
			}
			return result;
		}
	}
}