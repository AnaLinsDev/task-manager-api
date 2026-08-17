using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Exceptions;
using TaskManager.Communication.Responses;

namespace TaskManager.Application.UseCases.Task.GetById;
public class GetTaskByIdUseCase
{
    public ResponseTask Execute(List<ResponseTask> tasks, Guid id)
    {
        var task = tasks.Find(task => task.Id == id);

        if (task == null)
        {
            throw new TaskNotFoundException("Task not found.");
        }

        return task;
    }
}
