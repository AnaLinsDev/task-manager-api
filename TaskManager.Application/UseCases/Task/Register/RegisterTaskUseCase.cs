using TaskManager.Communication.Requests;
using TaskManager.Communication.Responses;

namespace TaskManager.Application.UseCases.Task.Register;
public class RegisterTaskUseCase
{
    public ResponseTask Execute(List<ResponseTask> tasks, RequestRegisterTask request)
    {
        TaskServiceHelper helper = new TaskServiceHelper();
        helper.ValidateTask(request);

        var newTask = new ResponseTask
        {
            Name = request.Name,
            Description = request.Description,
            Priority = request.Priority,
            dueDate = request.dueDate,
            Status = request.Status,
        };

        tasks.Add(newTask);
        return newTask;
    }

}