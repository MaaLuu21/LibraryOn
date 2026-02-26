using LibraryOn.Application.UseCases.Loans.Register;
using LibraryOn.Application.UseCases.Loans.RegisterReturn;
using LibraryOn.Communication.Requests.Loans;
using LibraryOn.Communication.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryOn.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LoansController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterLoan([FromServices] IRegisterLoanUseCase useCase,
                                              [FromBody] RequestLoanJson request)
    {

        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateLoan([FromServices] IUpdateLoanUseCase useCase,
                                                [FromBody] RequestLoanUpdateJson request)
    {
        await useCase.Execute(request);

        return NoContent();
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {


        return Ok();
    }
}
