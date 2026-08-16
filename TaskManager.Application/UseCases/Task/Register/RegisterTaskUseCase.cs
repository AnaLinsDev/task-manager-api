using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Exceptions;
using TaskManager.Communication.Enums;
using TaskManager.Communication.Requests;
using TaskManager.Communication.Responses;

namespace TaskManager.Application.UseCases.Task.Register;
public class RegisterTaskUseCase
{
    public ResponseTask Execute(List<ResponseTask> tasks, RequestRegisterTask request)
    {
        var newTask = new ResponseTask
        {
            Name = request.Name,
            Description = request.Description,
            Priority = request.Priority,
            dueDate = request.dueDate,
            Status = request.Status,
        };

        List<string> errors = new List<string>();

        bool validNameSize = newTask.Name.Count() <= 100;
        bool validDescriptionSize = newTask.Description.Count() <= 500;
        bool validDueDateInThePast = newTask.dueDate > DateTime.UtcNow;
        bool validPriority = Enum.IsDefined(typeof(Priority), newTask.Priority);
        bool validStatus = Enum.IsDefined(typeof(Status), newTask.Status);

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

        if (errors.Count > 0) {
            throw new ValidationException(errors);
        }

        tasks.Add(newTask);
        return newTask;
    }
}