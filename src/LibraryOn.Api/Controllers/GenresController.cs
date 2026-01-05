using LibraryOn.Application.UseCases.Genres.Register;
using LibraryOn.Communication.Requests.Genres;
using LibraryOn.Communication.Responses;
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
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        //[ProducesResponseType()] adicionar classe para lista de erros
        public async Task<IActionResult> Register([FromServices] IRegisterGenreUseCase useCase,
                                                  [FromBody] RequestGenreJson request)
        {
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }
    }
}
