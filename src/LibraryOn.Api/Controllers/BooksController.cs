using LibraryOn.Application.UseCases.Books.Register;
using LibraryOn.Communication.Requests.Books;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryOn.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> RegisterBook([FromServices] IRegisterBookUseCase useCase,
                                                       [FromBody] RequestBookJson request)
        {
            var response = await useCase.Execute(request);


            return Created(string.Empty, response);
        }
    }
}
