namespace UserManagementApi.Exceptions;

public class DisabledUserException : ApplicationException
{
    public DisabledUserException() { }

    public DisabledUserException(string? message)
        : base(message) { }

    public DisabledUserException(string? message, Exception? innerException)
        : base(message, innerException) { }

}