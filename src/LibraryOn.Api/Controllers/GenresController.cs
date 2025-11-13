using LibraryOn.Application.UseCases.Genres.Register;
using LibraryOn.Communication.Requests.Genres;
using LibraryOn.Communication.Responses.Genres;
using Microsoft.AspNetCore.Mvc;

namespace LibraryOn.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredGenreJson), StatusCodes.Status201Created)]
        //[ProducesResponseType()] adicionar classe para lista de erros
        public async Task<IActionResult> Register([FromServices] IRegisterGenreUseCase useCase,
                                                  [FromBody] RequestRegisterGenreJson request)
        {
            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }
    }
}
