using AutoMapper;
using LibraryOn.Communication.Responses.Book;
using LibraryOn.Domain.Repositories.Books;

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

            return new ResponseBooksJson
            {
                Books = _mapper.Map<List<ResponseShortBookJson>>(result)
            };
        }
    }
}
