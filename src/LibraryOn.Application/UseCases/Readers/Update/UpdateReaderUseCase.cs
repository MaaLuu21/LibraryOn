using AutoMapper;
using LibraryOn.Communication.Requests.Readers;
using LibraryOn.Domain.Repositories;
using LibraryOn.Domain.Repositories.Readers;
using LibraryOn.Domain.Validators;
using LibraryOn.Exception;
using LibraryOn.Exception.ExceptionsBase;

namespace LibraryOn.Application.UseCases.Readers.Update;
public class UpdateReaderUseCase : IUpdateReaderUseCase
{
    private readonly IReaderUpdateOnlyRepository _repository;
    private readonly IUnityOfWork _unityOfWork;
    private readonly IMapper _mapper;
    private readonly IPhoneNumberValidator _phoneNumberValidator;

    public UpdateReaderUseCase(IReaderUpdateOnlyRepository repository,
                               IUnityOfWork unityOfWork,
                               IMapper mapper,
                               IPhoneNumberValidator phoneNumberValidator)
    {
        _repository = repository;
        _unityOfWork = unityOfWork;
        _mapper = mapper;
        _phoneNumberValidator = phoneNumberValidator;
    }

    public async Task Execute(long id, RequestReaderJson request)
    {
        Validate(request);

        var reader = await _repository.GetById(id);

        if (reader == null)
        {
            throw new NotFoundExecption(ResourceErrorMessages.READER_NOT_FOUND);
        }
        _repository.Update(reader);

        _mapper.Map(request, reader);

        await _unityOfWork.Commit();
    }

    private void Validate(RequestReaderJson request)
    {
        var validate = new ReaderValidator(_phoneNumberValidator);
        var result = validate.Validate(request);

        if(result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
