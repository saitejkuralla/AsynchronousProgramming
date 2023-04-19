using System;
using System.Threading.Tasks;

namespace Timeout
{
    internal static class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://example.com/data";
            try
            {
                await RetrieveAsync(url).WithTimeout(TimeSpan.FromSeconds(5));
                Console.WriteLine("Data retrieved successfully");
            }
            catch (TimeoutException)
            {
                Console.WriteLine("Data retrieval timed out");
            }
        }

        public static async Task WithTimeout(this Task task, TimeSpan timeout)
        {
            var delayTask = Task.Delay(timeout);
            var completedTask = await Task.WhenAny(task, delayTask);
            if (completedTask == delayTask)
            {
                throw new TimeoutException();
            }
            await task.ConfigureAwait(false);
        }

        private static async Task<string> RetrieveAsync(string url)
        {
            await Task.Delay(6000).ConfigureAwait(false);
            return "Data";
        }
    }
}
