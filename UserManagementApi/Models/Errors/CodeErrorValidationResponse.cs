using Newtonsoft.Json;
using UserManagementApi.Errors;

namespace UserManagementApi.Models.Errors
{
    public class CodeErrorValidationResponse
    {
        [JsonProperty(PropertyName = "status")]
        public string? Status { get; set; } = "error";
        [JsonProperty(PropertyName = "statusCode")]
        public int StatusCode { get; set; }
        [JsonProperty(PropertyName = "errors")]
        public CodeErrorValidation[]? Errors { get; set; }

        public CodeErrorValidationResponse(int statusCode, CodeErrorValidation[]? errors)
        {
            StatusCode = statusCode;
            Errors = errors;
        }
    }
}