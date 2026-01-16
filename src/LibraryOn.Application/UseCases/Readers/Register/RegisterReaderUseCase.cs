using AutoMapper;
using LibraryOn.Communication.Requests.Readers;
using LibraryOn.Communication.Responses.Readers;
using LibraryOn.Domain.Entities;
using LibraryOn.Domain.Repositories;
using LibraryOn.Domain.Repositories.Readers;
using LibraryOn.Domain.Validators;
using LibraryOn.Domain.ValueObjects;
using LibraryOn.Exception.ExceptionsBase;

namespace LibraryOn.Application.UseCases.Readers.Register;
public class RegisterReaderUseCase : IRegisterReaderUseCase
{
    private readonly IReaderWriteOnlyRepository _repository;
    private readonly IUnityOfWork _unityOfWork;
    private readonly IMapper _mapper;
    private readonly IPhoneNumberValidator _phoneNumberValidator;

    public RegisterReaderUseCase(IReaderWriteOnlyRepository repository,
                                 IUnityOfWork unityOfWork,
                                 IMapper mapper, 
                                 IPhoneNumberValidator phoneNumberValidator)
    {
        _repository = repository;
        _unityOfWork = unityOfWork;
        _mapper = mapper;
        _phoneNumberValidator = phoneNumberValidator;
    }

    public async Task<ResponseRegisteredReaderJson> Execute(RequestReaderJson request)
    {
        Validate(request);

        var phoneNumber = PhoneNumber.Create(request.PhoneNumber, _phoneNumberValidator);
        var email = Email.Create(request.Email);
        var cpf = Cpf.Create(request.Cpf);

        var entity = new Reader(phoneNumber, email, cpf)
        {
            Name = request.Name,
        };


        await _repository.Add(entity);
        await _unityOfWork.Commit();

        return _mapper.Map<ResponseRegisteredReaderJson>(entity);

    }

    private void Validate (RequestReaderJson request)
    {
        var validate = new ReaderValidator(_phoneNumberValidator);

        var result = validate.Validate(request);

        if(result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
