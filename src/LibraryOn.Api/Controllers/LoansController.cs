using LibraryOn.Application.UseCases.Loans.GetAll;
using LibraryOn.Application.UseCases.Loans.GetOverdue;
using LibraryOn.Application.UseCases.Loans.Register;
using LibraryOn.Application.UseCases.Loans.RegisterReturn;
using LibraryOn.Communication.Requests.Loans;
using LibraryOn.Communication.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryOn.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LoansController : ControllerBase
{
    [Authorize]
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
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateLoan([FromServices] IUpdateLoanUseCase useCase,
                                                [FromBody] RequestLoanUpdateJson request,
                                                [FromRoute] long id)
    {
        await useCase.Execute(request, id);

        return NoContent();
    }
    [Authorize]
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById([FromServices] IGetLoanByIdUseCase useCase,
                                             [FromRoute] long id)
    {
        var response = await useCase.Execute(id);

        return Ok(response);
    }

    [HttpGet("overdue")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetOverDue([FromServices] IGetLoanOverdueUseCase useCase)
    {
        var response = await useCase.Execute();

        return Ok(response);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAll([FromServices] IGetAllLoanUseCase useCase)
    {
        var response = await useCase.Execute();
     
        return Ok(response);
    }
}
