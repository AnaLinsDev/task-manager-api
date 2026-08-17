using TaskManager.Application.Exceptions;
using TaskManager.Communication.Enums;
using TaskManager.Communication.Requests;

namespace TaskManager.Application.UseCases.Task;
public class TaskServiceHelper
{
    public void ValidateTask(RequestTask request)
    {
        List<string> errors = new List<string>();

        bool validNameSize = request.Name.Count() <= 100;
        bool validDescriptionSize = request.Description == null || request.Description?.Count() <= 500;
        bool validDueDateInThePast = request.dueDate > DateTime.UtcNow;
        bool validPriority = Enum.IsDefined(typeof(Priority), request.Priority);
        bool validStatus = Enum.IsDefined(typeof(Status), request.Status);

        if (!validNameSize)
        {
            errors.Add("Name should have between 0 and 100 char.");
        }
        if (!validDescriptionSize)
        {
            errors.Add("Description should have between 0 and 500 char.");
        }
        if (!validDueDateInThePast)
        {
            errors.Add("Due date should be in the future.");
        }
        if (!validPriority)
        {
            errors.Add("Invalid priority.");
        }
        if (!validStatus)
        {
            errors.Add("Invalid status.");
        }

        if (errors.Count > 0)
        {
            throw new ValidationException(errors);
        }

    }
}
