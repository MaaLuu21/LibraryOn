using AutoMapper;
using LibraryOn.Communication.Responses.Readers;
using LibraryOn.Domain.Repositories.Readers;
using LibraryOn.Exception;
using LibraryOn.Exception.ExceptionsBase;
using System.Drawing;

namespace LibraryOn.Application.UseCases.Readers.GetById;
public class GetReaderByIdUseCase : IGetReaderByIdUseCase
{
    private readonly IReaderReadOnlyRepository _repository;
    private readonly IMapper _mapper;

    public GetReaderByIdUseCase(IReaderReadOnlyRepository repository,
                                IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseReaderJson> Execute(long id)
    {
        var result = await _repository.GetById(id);

        if(result == null)
        {
            throw new NotFoundExecption(ResourceErrorMessages.READER_NOT_FOUND);
        }

        return _mapper.Map<ResponseReaderJson>(result);

    }
}
