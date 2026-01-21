using LibraryOn.Application.UseCases.Readers.Delete;
using LibraryOn.Application.UseCases.Readers.GetAll;
using LibraryOn.Application.UseCases.Readers.GetById;
using LibraryOn.Application.UseCases.Readers.Register;
using LibraryOn.Application.UseCases.Readers.Update;
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

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAll([FromServices] IGetAllReadersUseCase useCase)
    {
        var response = await useCase.Execute();

        return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById([FromServices] IGetReaderByIdUseCase useCase,
                                             [FromRoute] long id)
    {
        var response = await useCase.Execute(id);

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromServices] IDeleteReaderUseCase useCase,
                                            [FromRoute] long id)
    {
        await useCase.Execute(id);

        return NoContent();
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([FromServices] IUpdateReaderUseCase usecase,
                                            [FromRoute] long id,
                                            [FromBody] RequestReaderJson request)
    {
        await usecase.Execute(id, request);


        return NoContent();
    }

}
