using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Communication.Requests;
using TaskManager.Communication.Responses;

namespace TaskManager.Application.UseCases.Task.GetAll;
public class GetAllTasksUseCase
{
    public ResponseListAllTasks Execute(List<ResponseTask> tasks)
    {
        ResponseListAllTasks shortTasks = new ResponseListAllTasks();

        foreach (ResponseTask task in tasks) {

            ResponseShortTask shortTask = new ResponseShortTask
            {
                Id = task.Id,
                Name = task.Name,
                dueDate = task.dueDate,
                Priority = task.Priority,
                Status = task.Status,
            };

            shortTasks.tasks.Add(shortTask);
        }

        return shortTasks;
    }
}
