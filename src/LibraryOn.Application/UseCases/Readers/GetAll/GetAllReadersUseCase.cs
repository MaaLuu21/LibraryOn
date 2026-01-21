using AutoMapper;
using LibraryOn.Communication.Responses.Readers;
using LibraryOn.Domain.Repositories.Readers;

namespace LibraryOn.Application.UseCases.Readers.GetAll;
public class GetAllReadersUseCase : IGetAllReadersUseCase
{
    private readonly IReaderReadOnlyRepository _repository;
    private readonly IMapper _mapper;

    public GetAllReadersUseCase(IReaderReadOnlyRepository repository,
                                IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ResponseReadersJson> Execute()
    {
        var result = await _repository.GetAll();

        return new ResponseReadersJson
        {
            Readers = _mapper.Map<List<ResponseShortReaderJson>>(result)
        };
    }
}
