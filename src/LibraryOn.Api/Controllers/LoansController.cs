using LibraryOn.Application.UseCases.Loans.Register;
using LibraryOn.Communication.Requests.Loans;
using LibraryOn.Communication.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryOn.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LoansController : ControllerBase
{
    [HttpPost("book-loan")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterLoan([FromServices] IRegisterLoanUseCase useCase,
                                              [FromBody] RequestLoanJson request)
    {

        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }
    [HttpPost("book-return")]
    public async Task<IActionResult> RegisterReturn()
    {

        return Ok();
    }
    //ReturnedAt indo nulo pro BD
    //Devolver o livro
}
