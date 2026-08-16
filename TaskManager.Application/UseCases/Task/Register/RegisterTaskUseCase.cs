using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Communication.Enums;
using TaskManager.Communication.Requests;
using TaskManager.Communication.Responses;

namespace TaskManager.Application.UseCases.Task.Register;
public class RegisterTaskUseCase
{
    public ResponseTask Execute(RequestRegisterTask request)
    {
        return new ResponseTask
        {
            Name = request.Name,
            Description = request.Description,
            Priority = request.Priority,
            dueDate = request.dueDate,
            Status = request.Status,
        };
    }
}