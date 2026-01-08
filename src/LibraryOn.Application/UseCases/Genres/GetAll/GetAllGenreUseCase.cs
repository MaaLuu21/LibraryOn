using AutoMapper;
using LibraryOn.Communication.Responses.Genres;
using LibraryOn.Domain.Repositories.Genres;

namespace LibraryOn.Application.UseCases.Genres.GetAll;
public class GetAllGenreUseCase : IGetAllGenreUseCase
{
    private readonly IGenresReadOnlyRepository _repository;

    public GetAllGenreUseCase(IGenresReadOnlyRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResponseGenresJson> Execute()
    {
        var genres = await _repository.GetAll();


        return new ResponseGenresJson
        {
           Genres = genres.Select(g => new ResponseGenreJson
           {
               Id = g.Id,
               Name = g.Name
           }).ToList()
        };
    }
}
