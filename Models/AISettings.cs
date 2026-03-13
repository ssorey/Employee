namespace Employee.Models
{
    public class AISettings
    {
        public string ApiKey { get; set; } = string.Empty;
        public string ModelId { get; set; } = "gpt-4o-mini";
        public string Endpoint { get; set; } = "https://api.openai.com/v1";
    }
}
