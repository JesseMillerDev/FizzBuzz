﻿using FizzBuzzLib;

namespace FizzBuzz
{
    public class FizzBuzzer
    {
        private readonly FizzBuzzConfig _config;

        public FizzBuzzer(FizzBuzzConfig config)
        {
            _config = config;
        }

        /// <summary>
        /// This method returns an async stream of values as calculated by ShouldFizzBuzz
        /// </summary>
        /// <param name="min">Low value to fizz buzz</param>
        /// <param name="max">High value to fizz buzz inclusive</param>
        /// <returns></returns>
        public async IAsyncEnumerable<string> GetFizzBuzz(int min, int max)
        {
            for (int i = min; i <= max; i++)
            {               
                yield return await ShouldFizzBuzz(i);
            }
        }

        /// <summary>
        /// Calculates whether a given number should FizzBuzz based on the given configuration
        /// </summary>
        /// <param name="number">The number to evaluate</param>
        /// <returns></returns>
        public async Task<string> ShouldFizzBuzz(int number)
        {
            return await Task.Run(() =>
            {
                foreach (var r in _config.WordNumberPairs.OrderByDescending(x => x.Value.Length))
                {
                    if (r.Value.All(v => number % v == 0))
                    {
                        return r.Key;
                    }
                }

                return number.ToString();
            });
        }
    }
}
