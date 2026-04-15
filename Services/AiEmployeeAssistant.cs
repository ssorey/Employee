using Employee.Data;
using Employee.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Options;

namespace Employee.Services
{
    public class AiEmployeeAssistant
    {
        private readonly EmployeeDbContext _context;
        private readonly IChatClient? _chatClient;

        public AiEmployeeAssistant(EmployeeDbContext context, IChatClient? chatClient = null)
        {
            _context = context;
            _chatClient = chatClient;
        }

        public async Task<string> ChatAsync(string userMessage, CancellationToken cancellationToken = default)
        {
            if (_chatClient is null)
                return "AI is not configured. Please set a valid OpenAI API key in appsettings.json under AISettings:ApiKey.";

            var employees = await _context.employees.ToListAsync(cancellationToken);

            var employeeData = employees.Count == 0
                ? "No employees in the system."
                : string.Join("\n", employees.Select(e =>
                    $"ID: {e.EmpId}, Name: {e.FirstName} {e.LastName}, Email: {e.Email}"));

            var systemPrompt = $"""
                You are an intelligent HR assistant for an Employee Management System.
                You help users query and understand their employee data using natural language.
                
                Current employee data:
                {employeeData}
                
                Answer questions about employees helpfully and concisely.
                If asked to perform data changes, explain that changes must be made through the REST API.
                """;

            var messages = new List<ChatMessage>
            {
                new ChatMessage(ChatRole.System, systemPrompt),
                new ChatMessage(ChatRole.User, userMessage)
            };

            var response = await _chatClient.GetResponseAsync(messages, cancellationToken: cancellationToken);
            return response.Text ?? "No response from AI.";
        }

        public async Task<string> GetInsightsAsync(CancellationToken cancellationToken = default)
        {
            if (_chatClient is null)
                return "AI is not configured. Please set a valid OpenAI API key in appsettings.json under AISettings:ApiKey.";

            var employees = await _context.employees.ToListAsync(cancellationToken);

            if (employees.Count == 0)
                return "No employees found in the system to generate insights.";

            var employeeData = string.Join("\n", employees.Select(e =>
                $"ID: {e.EmpId}, Name: {e.FirstName} {e.LastName}, Email: {e.Email}"));

            var messages = new List<ChatMessage>
            {
                new ChatMessage(ChatRole.System,
                    "You are an HR analytics assistant. Analyze employee data and provide concise, actionable insights."),
                new ChatMessage(ChatRole.User,
                    $"Please analyze this employee data and provide key insights, patterns, and recommendations:\n\n{employeeData}")
            };

            var response = await _chatClient.GetResponseAsync(messages, cancellationToken: cancellationToken);
            return response.Text ?? "No insights generated.";
        }
    }
}
