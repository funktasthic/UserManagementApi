using Newtonsoft.Json;

namespace UserManagementApi.Errors
{
    public class CodeErrorGlobalResponse
    {
        [JsonProperty(PropertyName = "status", Order = 1)]
        public string? Status { get; set; } = "error";

        [JsonProperty(PropertyName = "message", Order = 2)]
        public string? Message { get; set; }

        [JsonProperty(PropertyName = "statusCode", Order = 4)]
        public int StatusCode { get; set; }

        public CodeErrorGlobalResponse(int statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageStatusCode(statusCode);
        }

        private string GetDefaultMessageStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Request has errors",
                401 => "You are not authorized",
                404 => "Resource not found",
                500 => "Internal server error",
                _ => string.Empty
            };
        }
    }
}