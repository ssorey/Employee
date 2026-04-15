using Microsoft.EntityFrameworkCore;
using Employee.Data;
using Employee.Models;
using Employee.Services;
using Microsoft.Extensions.AI;
using OpenAI;
using System.ClientModel;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Register DbContext - use SQLite for development, SQL Server for production
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
if (connectionString.StartsWith("Data Source=", StringComparison.OrdinalIgnoreCase))
{
    builder.Services.AddDbContext<EmployeeDbContext>(options =>
        options.UseSqlite(connectionString));
}
else
{
    builder.Services.AddDbContext<EmployeeDbContext>(options =>
        options.UseSqlServer(connectionString));
}

// Register AI services
var aiSettings = builder.Configuration.GetSection("AISettings").Get<AISettings>() ?? new AISettings();
if (!string.IsNullOrWhiteSpace(aiSettings.ApiKey))
{
    var openAiClient = new OpenAIClient(new ApiKeyCredential(aiSettings.ApiKey));
    builder.Services.AddSingleton<IChatClient>(
        openAiClient.GetChatClient(aiSettings.ModelId).AsIChatClient());
}
builder.Services.AddScoped<AiEmployeeAssistant>();

// Add controllers
builder.Services.AddControllers();

// Add Swagger for API documentation (optional but common)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Ensure the database schema is created (for development/first-run)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<EmployeeDbContext>();
    db.Database.EnsureCreated();
}

app.UseDefaultFiles();  // looks for index.html
app.UseStaticFiles();   // serves static content


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();