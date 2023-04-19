using System;
using System.Threading.Tasks;

namespace FallBack
{
    internal static class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://example.com/data";
            var data = await RetrieveAsync(url).Fallback("fallback data");
            Console.WriteLine($"Fetched data: {data}");
        }

        public static async Task<TResult> Fallback<TResult>(this Task<TResult> task, TResult fallbackValue)
        {
            try
            {
                return await task.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to retrieve data: {ex.Message}");
                return fallbackValue;
            }
        }

        private static async Task<string> RetrieveAsync(string url)
        {
            await Task.Delay(2000).ConfigureAwait(false);
            throw new Exception("Failed to retrieve data from server");
            //return "Data from server";
        }
    }
}
