namespace TM.Application.Common.Models
{
    public class ErrorResponse
    {
        public string Message { get; set; }
        public int Status { get; set; }
        public string? Details { get; set; }
        public IEnumerable<string>? Errors { get; set; }

        public ErrorResponse(string message, int statusCode, string? details = null, IEnumerable<string>? errors = null)
        {
            Message = message;
            Status = statusCode;
            Details = details;
            Errors = errors;
        }
    }
}
