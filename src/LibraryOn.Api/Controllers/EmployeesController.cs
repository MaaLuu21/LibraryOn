using LibraryOn.Application.UseCases.Employee.ChangePassword;
using LibraryOn.Application.UseCases.Employee.Delete;
using LibraryOn.Application.UseCases.Employee.GetAll;
using LibraryOn.Application.UseCases.Employee.Register;
using LibraryOn.Communication.Requests.Employees;
using LibraryOn.Communication.Responses;
using LibraryOn.Communication.Responses.Employee;
using LibraryOn.Domain.Enums;
using LibraryOn.Infrastructure.DataAcess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryOn.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    [HttpPost]
    [Authorize(Roles = Roles.ADMIN)]
    [ProducesResponseType(typeof(ResponseRegisteredEmployeeJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromServices] IRegisterEmployeeUseCase useCase,
                                              [FromBody] RequestRegisterEmployeeJson request)
    {
        var response = await useCase.Execute(request);


        return Created(string.Empty, response);
    }

    [HttpPut("change-password")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ChangePassword([FromServices] IChangePasswordUseCase useCase,
                                                    [FromBody] RequestChangePasswordJson request)
    {
        await useCase.Execute(request);


        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    [Authorize(Roles = Roles.ADMIN)]
    public async Task<IActionResult> Delete([FromServices] IDeleteEmployeeAccountUseCase useCase,
                                            [FromQuery] long id)
    {
        await useCase.Execute(id);

        return NoContent();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    [Authorize(Roles = Roles.ADMIN)]
    public async Task<IActionResult> GetAll([FromServices] IGetAllEmployeesUseCase useCase)
    {
        var response = await useCase.Execute();

        return Ok(response);
    }

}
