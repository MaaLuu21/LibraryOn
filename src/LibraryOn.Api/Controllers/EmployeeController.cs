using LibraryOn.Application.UseCases.Employee.Register;
using LibraryOn.Communication.Requests.Employee;
using LibraryOn.Communication.Responses;
using LibraryOn.Communication.Responses.Employee;
using Microsoft.AspNetCore.Http;
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

    // login - CONTROLLER SEPARADO E ISOLADO PARA O LOGIN
    // update password
    // update employee
    // 
    // delete
}
