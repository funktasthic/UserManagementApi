namespace UserManagementApi.Models.Common
{
    public class MessageResponse<T>
    {
        public string? Status { get; set; } = "success";

        public string? Message { get; set; }

        public MessageResponse(string? message)
        {
            Message = message;
        }
    }
}