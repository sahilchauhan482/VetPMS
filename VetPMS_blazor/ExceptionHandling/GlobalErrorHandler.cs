namespace VetPMS.ExceptionHandling
{
    public class GlobalErrorHandler
    {
        // Property to store the last encountered exception
        public Exception? LastException { get; private set; }

        // Property to check if an error has occurred
        public bool HasError => LastException != null;

        // Method to handle errors globally
        public Task HandleErrorAsync(Exception exception)
        {
            LastException = exception;
            // Log the error or perform other actions
            Console.WriteLine($"Error: {exception.Message}");

            // Optionally, you could log this error to a remote server or file

            return Task.CompletedTask;
        }
    }
}
