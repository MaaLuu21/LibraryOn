using LibraryOn.Application.UseCases.Readers.Register;
using LibraryOn.Communication.Requests.Readers;
using LibraryOn.Communication.Responses;
using LibraryOn.Communication.Responses.Book;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryOn.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ReadersController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredBookJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Register([FromServices] IRegisterReaderUseCase useCase,
                                              [FromBody] RequestReaderJson request)
    {
        var response = await useCase.Execute(request);


        return Created(string.Empty, response);
    }

}
