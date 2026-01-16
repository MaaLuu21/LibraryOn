using LibraryOn.Application.UseCases.Genres.Delete;
using LibraryOn.Application.UseCases.Genres.GetAll;
using LibraryOn.Application.UseCases.Genres.GetById;
using LibraryOn.Application.UseCases.Genres.GetByIds;
using LibraryOn.Application.UseCases.Genres.Register;
using LibraryOn.Application.UseCases.Genres.Update;
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
        public async Task<IActionResult> RegisterGenre([FromServices] IRegisterGenreUseCase useCase,
                                                  [FromBody] RequestGenreJson request)
        {
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromServices] IGetGenreByIdUseCase useCase,
                                                   [FromRoute] long id)
        {
            var response = await useCase.Execute(id);

            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll([FromServices] IGetAllGenreUseCase useCase)
        {
            var response = await useCase.Execute();

            if (response.Genres.Count != 0)
            {
                return Ok(response);
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteGenre([FromServices] IDeleteGenreUseCase useCase,
                                                [FromRoute] long id)
        {
            await useCase.Execute(id);

            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateGenre([FromServices] IUpdateGenreUseCase useCase,
                                                [FromRoute] long id,
                                                [FromBody] RequestGenreJson request)
        {
            await useCase.Execute(id, request);

            return NoContent();
        }

        [HttpGet("by-ids")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIds([FromServices] IGetGenresByIdsUseCase useCase,
                                                       [FromQuery] List<long> ids)
        {
            var response = await useCase.Execute(ids);

            return Ok(response);
        }

    }
}
