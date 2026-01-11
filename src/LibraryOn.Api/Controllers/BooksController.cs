using LibraryOn.Application.UseCases.Books.GetAll;
using LibraryOn.Application.UseCases.Books.Register;
using LibraryOn.Communication.Requests.Books;
using LibraryOn.Communication.Responses;
using LibraryOn.Communication.Responses.Book;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Resources;

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
        [ProducesResponseType (StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllBook([FromServices] IGetAllBookUseCase useCase)
        {
            var response = await useCase.Execute();

            return Ok(response);
        }
    }
}
