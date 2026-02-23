
using AutoMapper;
using LibraryOn.Communication.Responses.Readers;
using LibraryOn.Domain.Entities;
using LibraryOn.Domain.Exceptions;
using LibraryOn.Domain.Exceptions.Errors;
using LibraryOn.Domain.Repositories.Readers;
using LibraryOn.Exception;
using LibraryOn.Exception.ExceptionsBase;

namespace LibraryOn.Application.UseCases.Readers.GetByCpf;
public class GetReaderByCpfUseCase : IGetReaderByCpfUseCase
{

    private readonly IReaderReadOnlyRepository _repository;
    private readonly IMapper _mapper;

    public GetReaderByCpfUseCase(IReaderReadOnlyRepository repository,
                                 IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseReaderJson> Execute(string cpf)
    {
        var reader = await _repository.GetByCpf(cpf); 

        if (reader == null) 
        { 
            throw new NotFoundExecption(ResourceErrorMessages.READER_NOT_FOUND); 
        }

        return _mapper.Map<ResponseReaderJson>(reader);
    }
}
