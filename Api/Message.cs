using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;

namespace Api
{
    public class Message
    {
        private readonly ILogger<Message> _logger;

        public Message(ILogger<Message> loggers)
        {
            _logger = loggers;
        }

        [Function("Message")]
        public async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            _logger.LogInformation("API triggered.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            await response.WriteStringAsync("Hello, this is a call from the API");

            return response;
        }
    }
}
