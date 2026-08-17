namespace TaskManager.Application.Exceptions;
public class ValidationException : Exception
{
    public List<string> Errors { get; }

    public ValidationException(List<string> errors)
    {
        Errors = errors;
    }
}