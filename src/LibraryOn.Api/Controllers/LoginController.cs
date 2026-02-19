using LibraryOn.Application.UseCases.Login.DoLogin;
using LibraryOn.Communication.Requests.Employee;
using LibraryOn.Communication.Responses;
using LibraryOn.Communication.Responses.Employee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace LibraryOn.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredEmployeeJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login([FromServices] IDoLoginUseCase useCase,
                                           [FromBody] RequestLoginJson request)
    {
        var response = await useCase.Execute(request);

        return Ok(response);
    }
}
