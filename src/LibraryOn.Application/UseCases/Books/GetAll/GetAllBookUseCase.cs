using AutoMapper;
using LibraryOn.Communication.Responses.Book;
using LibraryOn.Domain.Entities;
using LibraryOn.Domain.Repositories.Books;
using LibraryOn.Exception;
using LibraryOn.Exception.ExceptionsBase;

namespace LibraryOn.Application.UseCases.Books.GetAll
{
    public class GetAllBookUseCase : IGetAllBookUseCase
    {
        private readonly IBookReadOnlyRepository _repository;
        private readonly IMapper _mapper;


        public GetAllBookUseCase(IBookReadOnlyRepository repository,
                                 IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBooksJson> Execute()
        {
            var result = await _repository.GetAll();

            if (result == null || result.Count == 0)
            {
                throw new NotFoundException(ResourceErrorMessages.BOOK_NOT_FOUND);
            }

            return new ResponseBooksJson
            {
                Books = _mapper.Map<List<ResponseShortBookJson>>(result)
            };
        }
    }
}
