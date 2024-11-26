using Newtonsoft.Json;

namespace UserManagementApi.Errors
{
    public class CodeErrorValidation
    {
        [JsonProperty(PropertyName = "type")]
        public string? Type { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string? Message { get; set; }

        [JsonProperty(PropertyName = "path")]
        public string? Path { get; set; }

        [JsonProperty(PropertyName = "location")]
        public string? Location { get; set; }

        public CodeErrorValidation(string? type, string? message, string? path, string? location)
        {
            Type = type;
            Message = message;
            Path = path;
            Location = location;
        }
    }
}