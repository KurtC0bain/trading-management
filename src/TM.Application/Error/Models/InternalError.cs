namespace TM.Application.Error.Models
{
    public enum ErrorReason
    {
        NotFound,
        ValidationFailed
    }

    public abstract record InternalError(ErrorReason Reason, string Message);

    public record NotFoundError(string Id) : InternalError(ErrorReason.NotFound, $"Element with ID {Id} not found.");
    public record ValidationError(IEnumerable<string> Errors) : InternalError(ErrorReason.ValidationFailed, "Validation errors occurred.")
    {
        public IEnumerable<string> Errors { get; init; } = Errors;
    }
}
