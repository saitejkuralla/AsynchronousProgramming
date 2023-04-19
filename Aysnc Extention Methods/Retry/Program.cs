using System;
using System.Threading.Tasks;

namespace Retry
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://example.com/data";
            int maxRetries = 3;
            TimeSpan delayBetweenRetries = TimeSpan.FromSeconds(1);

            try
            {
                var data = await retry(async () => await FetchDataFromServerAsync(url), maxRetries, delayBetweenRetries);
                Console.WriteLine($"Fetched data: {data}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to fetch data after {maxRetries} attempts: {ex.Message}");
            }
        }


        public static async Task<TResult> retry<TResult>(Func<Task<TResult>> taskFactory, int maxRetries, TimeSpan delay)
        {
            for (var i = 0; i < maxRetries; i++)
            {
                try
                {
                    return await taskFactory().ConfigureAwait(false);
                }
                catch
                {
                    if (i == maxRetries - 1)
                    {
                        throw;
                    }
                        await Task.Delay(delay).ConfigureAwait(false);
                }
            }
            return default(TResult);
        }


        private static async Task<string> FetchDataFromServerAsync(string url)
        {
            await Task.Delay(3000).ConfigureAwait(false);
          throw new NotImplementedException();
            //return "data from server";
        }
    }
}
