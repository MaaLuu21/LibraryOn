using AutoMapper;
using LibraryOn.Communication.Responses.Book;
using LibraryOn.Domain.Repositories.Books;
using LibraryOn.Exception;
using LibraryOn.Exception.ExceptionsBase;

namespace LibraryOn.Application.UseCases.Books.GetById;
public class GetBookByIdUseCase : IGetBookByIdUseCase
{
    private readonly IBookReadOnlyRepository _repository;
    private readonly IMapper _mapper;

    public GetBookByIdUseCase(IBookReadOnlyRepository repository,
                              IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseBookJson> Execute(long id)
    {
        var result = await _repository.GetById(id);

        if(result == null)
        {
            throw new NotFoundExecption(ResourceErrorMessages.BOOK_NOT_FOUND);
        } 

        return _mapper.Map<ResponseBookJson>(result);

    }
}
