namespace Fire_and_Forget
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                await LongRunningOperation();
            }).FireAndForget(ex =>
            {

                Console.WriteLine($"An error occurred: {ex.Message}");
            });

            Console.WriteLine("Operation started.");
            Console.ReadLine();
        }

        static async Task LongRunningOperation()
        {
            await Task.Delay(3000);
            throw new Exception();
        }
    }

    public static class TaskExtensions
    {
        public static void FireAndForget(this Task task, Action<Exception> errorHandler = null)
        {
            task.ContinueWith(t =>
            {
                if (t.IsFaulted && errorHandler != null)
                    errorHandler(t.Exception);
            }, TaskContinuationOptions.OnlyOnFaulted);
        }

    }
}