using System.Text.Json;
namespace VetPMS.ExceptionHandling
{
    public class ErrorHandlingMessageHandler : DelegatingHandler
    {
        private readonly ILogger<ErrorHandlingMessageHandler> _logger;

        public ErrorHandlingMessageHandler(ILogger<ErrorHandlingMessageHandler> logger)
        {
            _logger = logger;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await base.SendAsync(request, cancellationToken);

                // Capture and log detailed error information if response is not successful
                if (!response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    _logger.LogError("API error: {ResponseContent}", responseContent);

                    // Optionally, parse the error content and log detailed error information
                    var errorDetail = ExtractErrorDetail(responseContent);
                    _logger.LogError("Error Detail: {ErrorDetail}", errorDetail);

                    // Throw custom exception with detailed message
                    throw new HttpRequestException($"API Error: {errorDetail}");
                }

                return response;
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "An error occurred while processing the HTTP request.");
                throw; // Optionally rethrow or handle it as needed
            }
        }

        private string ExtractErrorDetail(string responseContent)
        {
            try
            {
                // Parse the response content (assuming it’s in JSON format)
                var jsonResponse = JsonDocument.Parse(responseContent);

                // Extract the "Detail" property from the JSON response
                if (jsonResponse.RootElement.TryGetProperty("Detail", out var detailProperty))
                {
                    return detailProperty.GetString() ?? "Unknown error occurred.";
                }
                return "Unknown error occurred.";
            }
            catch (JsonException)
            {
                // Handle JSON parsing errors
                return "Error parsing the error response.";
            }
        }
    }
}
