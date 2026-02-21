using LibraryOn.Application.UseCases.Employee.ChangePassword;
using LibraryOn.Application.UseCases.Employee.Register;
using LibraryOn.Communication.Requests.Employees;
using LibraryOn.Communication.Responses;
using LibraryOn.Communication.Responses.Employee;
using Microsoft.AspNetCore.Mvc;

namespace LibraryOn.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    [HttpPost]
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

    // update employee
    // delete
}
