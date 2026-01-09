using AutoMapper;
using LibraryOn.Communication.Requests.Genres;
using LibraryOn.Communication.Responses.Genres;
using LibraryOn.Domain.Repositories.Genres;
using LibraryOn.Exception;
using LibraryOn.Exception.ExceptionsBase;

namespace LibraryOn.Application.UseCases.Genres.GetByIds;
public class GetGenresByIdsUseCase : IGetGenresByIdsUseCase
{
    private readonly IGenresReadOnlyRepository _repository;
    private readonly IMapper _mapper;

    public GetGenresByIdsUseCase(IGenresReadOnlyRepository repository,
                                 IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseGenresJson> Execute(List<long> ids)
    {
        var result = await _repository.GetByIds(ids);

        if (result == null || result.Count == 0)
        {
            throw new NotFoundExecption(ResourceErrorMessages.GENRE_NOT_FOUND);
        }

        return new ResponseGenresJson
        {
            Genres = _mapper.Map<List<ResponseGenreJson>>(result)
        };
    }
}
