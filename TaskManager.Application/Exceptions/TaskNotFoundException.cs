namespace TaskManager.Application.Exceptions;
public class TaskNotFoundException : Exception
{
    public TaskNotFoundException(string error)
        : base(error)
    {
    }
}
