using AutoMapper;
using LibraryOn.Communication.Requests.Books;
using LibraryOn.Communication.Responses.Book;
using LibraryOn.Domain.Entities;
using LibraryOn.Domain.Repositories;
using LibraryOn.Domain.Repositories.Books;
using LibraryOn.Exception.ExceptionsBase;

namespace LibraryOn.Application.UseCases.Books.Register;
public class RegisterBookUseCase : IRegisterBookUseCase
{
    private readonly IBookWriteOnlyRepository _repository;
    private readonly IUnityOfWork _unityOfWork;
    private readonly IMapper _mapper;

    public async Task<ResponseRegisteredBookJson> Execute(RequestBookJson request)
    {
        Validate(request);

        var entity = _mapper.Map<Book>(request);

        await _repository.Add(entity);
        await _unityOfWork.Commit();

        return _mapper.Map<ResponseRegisteredBookJson>(entity);

    }

    private void Validate(RequestBookJson request)
    {
        var validator = new BookValidator();
        var result = validator.Validate(request);

        if(result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
