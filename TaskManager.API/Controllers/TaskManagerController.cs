using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.UseCases.Task.GetAll;
using TaskManager.Application.UseCases.Task.Register;
using TaskManager.Communication.Enums;
using TaskManager.Communication.Requests;
using TaskManager.Communication.Responses;

namespace TaskManager.API.Controllers;
[Route("api/tasks")]
[ApiController]
public class TaskManagerController : ControllerBase
{
    private static List<ResponseTask> tasksDB = new List<ResponseTask>()
    {
        new ResponseTask
        {
            Id = Guid.NewGuid(),
            Name = "Estudar C#",
            Description = "Estudar classes, interfaces e LINQ",
            Priority = "High",
            dueDate = new DateTime(2026, 8, 18),
            Status = Status.Pending
        },

        new ResponseTask
        {
            Id = Guid.NewGuid(),
            Name = "Fazer exercícios de LeetCode",
            Description = "Resolver 2 problemas de algoritmos",
            Priority = "Medium",
            dueDate = new DateTime(2026, 8, 20),
            Status = Status.InProgress
        },

        new ResponseTask
        {
            Id = Guid.NewGuid(),
            Name = "Atualizar currículo",
            Description = "Adicionar projetos backend .NET",
            Priority = "Low",
            dueDate = new DateTime(2026, 8, 25),
            Status = Status.Completed
        }
    };

    [HttpPost]
    [EndpointSummary("Register")]
    [ProducesResponseType(typeof(ResponseTask), StatusCodes.Status201Created)]
    public IActionResult Register([FromBody] RequestRegisterTask request)
    {
        var response = new RegisterTaskUseCase().Execute(request);

        return Created(String.Empty, response);
    }

    [HttpGet]
    [EndpointSummary("Get All")]
    [ProducesResponseType(typeof(ResponseListAllTasks), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        var response = new GetAllTasksUseCase().Execute(tasksDB);

        return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    [EndpointSummary("Get by ID")]
    [ProducesResponseType(typeof(ResponseTask), StatusCodes.Status200OK)]
    public IActionResult GetById([FromRoute] Guid id)
    {
        return Ok();
    }

    [HttpPut]
    [Route("{id}")]
    [EndpointSummary("Update")]
    [ProducesResponseType(typeof(ResponseTask), StatusCodes.Status200OK)]
    public IActionResult Update([FromRoute] Guid id, [FromBody] RequestUpdateTask request)
    {
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    [EndpointSummary("Delete")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Delete([FromRoute] Guid id)
    {
        return NoContent();
    }
}
