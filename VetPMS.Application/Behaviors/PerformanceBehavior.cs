using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace VetPMS.Application.Behaviors
{
    public class PerformanceBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly Stopwatch _timer;
        private readonly ILogger<TRequest> _logger;

        public PerformanceBehavior(
            ILogger<TRequest> logger) => (_timer, _logger) = (new Stopwatch(), logger);

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();

            var elapsedMilliseconds = _timer.ElapsedMilliseconds;

            if (elapsedMilliseconds > 500)
            {
                var requestName = typeof(TRequest).Name;



                _logger.LogWarning("Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds)   {@Request}",
                    requestName, elapsedMilliseconds, request);
            }

            return response;
        }
    }
}
