using Employee.Services;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Controllers
{
    [ApiController]
    [Route("api/ai")]
    public class AiController : ControllerBase
    {
        private readonly AiEmployeeAssistant _assistant;

        public AiController(AiEmployeeAssistant assistant)
        {
            _assistant = assistant;
        }

        /// <summary>
        /// Chat with the AI assistant about your employees.
        /// </summary>
        /// <param name="request">The chat message request.</param>
        [HttpPost("chat")]
        public async Task<IActionResult> Chat([FromBody] ChatRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Message))
                return BadRequest(new { error = "Message cannot be empty." });

            var reply = await _assistant.ChatAsync(request.Message, cancellationToken);
            return Ok(new { reply });
        }

        /// <summary>
        /// Get AI-generated insights about your employee data.
        /// </summary>
        [HttpGet("insights")]
        public async Task<IActionResult> Insights(CancellationToken cancellationToken)
        {
            var insights = await _assistant.GetInsightsAsync(cancellationToken);
            return Ok(new { insights });
        }
    }

    public record ChatRequest(string Message);
}
