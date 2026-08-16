using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Exceptions;
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
            Priority = Priority.High,
            dueDate = new DateTime(2026, 8, 18),
            Status = Status.Pending
        },

        new ResponseTask
        {
            Id = Guid.NewGuid(),
            Name = "Fazer exercícios de LeetCode",
            Description = "Resolver 2 problemas de algoritmos",
            Priority = Priority.Medium,
            dueDate = new DateTime(2026, 8, 20),
            Status = Status.InProgress
        },

        new ResponseTask
        {
            Id = Guid.NewGuid(),
            Name = "Atualizar currículo",
            Description = "Adicionar projetos backend .NET",
            Priority = Priority.Low,
            dueDate = new DateTime(2026, 8, 25),
            Status = Status.Completed
        }
    };

    [HttpPost]
    [EndpointSummary("Register")]
    [ProducesResponseType(typeof(ResponseTask), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrors), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestRegisterTask request)
    {
        try
        {
            var response = new RegisterTaskUseCase().Execute(tasksDB, request);

            return Created(String.Empty, response);
        }
        catch (ValidationException ex)
        {
            return BadRequest(new ResponseErrors
            {
                Errors = ex.Errors
            });
        }

    }

    [HttpGet]
    [EndpointSummary("Get All")]
    [ProducesResponseType(typeof(ResponseListAllTasks), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrors), StatusCodes.Status400BadRequest)]
    public IActionResult GetAll()
    {
        var response = new GetAllTasksUseCase().Execute(tasksDB);

        return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    [EndpointSummary("Get by ID")]
    [ProducesResponseType(typeof(ResponseTask), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrors), StatusCodes.Status400BadRequest)]
    public IActionResult GetById([FromRoute] Guid id)
    {

        try
        {
            return Ok();
        }
        catch (ValidationException ex)
        {
            return BadRequest(new ResponseErrors
            {
                Errors = ex.Errors
            });
        }
    }

    [HttpPut]
    [Route("{id}")]
    [EndpointSummary("Update")]
    [ProducesResponseType(typeof(ResponseTask), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrors), StatusCodes.Status400BadRequest)]
    public IActionResult Update([FromRoute] Guid id, [FromBody] RequestUpdateTask request)
    {
        try
        {
            return Ok();
        }
        catch (ValidationException ex)
        {
            return BadRequest(new ResponseErrors
            {
                Errors = ex.Errors
            });
        }
    }

    [HttpDelete]
    [Route("{id}")]
    [EndpointSummary("Delete")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrors), StatusCodes.Status400BadRequest)]
    public IActionResult Delete([FromRoute] Guid id)
    {
        try
        {
            return NoContent();
        }
        catch (ValidationException ex)
        {
            return BadRequest(new ResponseErrors
            {
                Errors = ex.Errors
            });
        }
    }
}
