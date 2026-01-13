using LibraryOn.Application.UseCases.Books.Delete;
using LibraryOn.Application.UseCases.Books.GetAll;
using LibraryOn.Application.UseCases.Books.GetById;
using LibraryOn.Application.UseCases.Books.Register;
using LibraryOn.Communication.Requests.Books;
using LibraryOn.Communication.Responses;
using LibraryOn.Communication.Responses.Book;
using Microsoft.AspNetCore.Mvc;

namespace LibraryOn.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredBookJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RegisterBook([FromServices] IRegisterBookUseCase useCase,
                                                       [FromBody] RequestBookJson request)
        {
            var response = await useCase.Execute(request);


            return Created(string.Empty, response);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll([FromServices] IGetAllBookUseCase useCase)
        {
            var response = await useCase.Execute();

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromServices] IGetBookByIdUseCase useCase,
                                                  [FromRoute] long id)
        {
            var response = await useCase.Execute(id);

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Delete([FromServices] IDeleteBookUseCase useCase,
                                                [FromRoute] long id)
        {
            await useCase.Execute(id);

            return NoContent();
        }
        
    }
}
