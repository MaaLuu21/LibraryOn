using AutoMapper;
using FluentValidation.Results;
using LibraryOn.Communication.Requests.Readers;
using LibraryOn.Communication.Responses.Readers;
using LibraryOn.Domain.Entities;
using LibraryOn.Domain.Repositories;
using LibraryOn.Domain.Repositories.Readers;
using LibraryOn.Domain.Validators;
using LibraryOn.Domain.ValueObjects;
using LibraryOn.Exception;
using LibraryOn.Exception.ExceptionsBase;

namespace LibraryOn.Application.UseCases.Readers.Register;
public class RegisterReaderUseCase : IRegisterReaderUseCase
{
    private readonly IReaderWriteOnlyRepository _writeRepository;
    private readonly IReaderReadOnlyRepository _readRepository;
    private readonly IUnityOfWork _unityOfWork;
    private readonly IMapper _mapper;
    private readonly IPhoneNumberValidator _phoneNumberValidator;

    public RegisterReaderUseCase(IReaderWriteOnlyRepository repository,
                                 IReaderReadOnlyRepository readRepository,   
                                 IUnityOfWork unityOfWork,
                                 IMapper mapper, 
                                 IPhoneNumberValidator phoneNumberValidator)
    {
        _writeRepository = repository;
        _readRepository = readRepository;
        _unityOfWork = unityOfWork;
        _mapper = mapper;
        _phoneNumberValidator = phoneNumberValidator;
    }

    public async Task<ResponseRegisteredReaderJson> Execute(RequestReaderJson request)
    {
        await Validate(request);

        var phoneNumber = PhoneNumber.Create(request.PhoneNumber, _phoneNumberValidator);
        var cpf = Cpf.Create(request.Cpf);

        var entity = new Reader(phoneNumber, cpf )
        {
            Name = request.Name,
            Email = request.Email,
        };

        await _writeRepository.Add(entity);
        await _unityOfWork.Commit();

        return _mapper.Map<ResponseRegisteredReaderJson>(entity);

    }

    private async Task Validate (RequestReaderJson request)
    {
        var validate = new ReaderValidator(_phoneNumberValidator);
        var result = validate.Validate(request);
        
        var existActiveCpf = await _readRepository.ExistActiveReaderCpf(request.Cpf);

        if (existActiveCpf)
        {
            result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.CPF_ALREADY_REGISTERED));
        }

        if(result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
