using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Api
{
    public class Message
    {
        private readonly ILogger<Message> _logger;

        public Message(ILogger<Message> logger)
        {
            _logger = logger;
        }

        [Function("message")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            // Respond with the JSON object expected by the frontend
            var response = new { text = "Hello from the API" };

            return new JsonResult(response);
        }
    }
}
