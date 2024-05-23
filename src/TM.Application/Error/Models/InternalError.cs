namespace TM.Application.Error.Models
{
    public enum ErrorReason
    {
        NotFound,
        ValidationFailed,
        UserNotFound,
        WrongUser
    }

    public abstract record InternalError(ErrorReason Reason, string Message);

    public record NotFoundError(string Id) : InternalError(ErrorReason.NotFound, $"Entity with ID {Id} not found.");
    public record WrongUserError() : InternalError(ErrorReason.WrongUser, $"Error trying to make operation with other user ID");
    public record UserNotFoundError(string UserId) : InternalError(ErrorReason.UserNotFound, $"User with ID {UserId} does not exist in system.");

    public record ValidationError(IEnumerable<string> Errors) : InternalError(ErrorReason.ValidationFailed, "Validation errors occurred.")
    {
        public IEnumerable<string> Errors { get; init; } = Errors;
    }
}
