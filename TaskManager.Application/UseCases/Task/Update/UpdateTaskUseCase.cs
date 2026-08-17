using TaskManager.Application.Exceptions;
using TaskManager.Communication.Requests;
using TaskManager.Communication.Responses;

namespace TaskManager.Application.UseCases.Task.Update;

public class UpdateTaskUseCase
{
    public ResponseTask Execute(List<ResponseTask> tasks, Guid id, RequestUpdateTask request)
    {
        TaskServiceHelper helper = new TaskServiceHelper();
        helper.ValidateTask(request);

        var taskToUpdate = tasks.Find(task => task.Id == id);

        if (taskToUpdate == null)
        {
            throw new TaskNotFoundException("Task not found.");
        }

        taskToUpdate.Name = request.Name;
        taskToUpdate.Description = request.Description;
        taskToUpdate.Priority = request.Priority;
        taskToUpdate.dueDate = request.dueDate;
        taskToUpdate.Status = request.Status;

        return taskToUpdate;
    }
}
