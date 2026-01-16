using AutoMapper;
using LibraryOn.Communication.Requests.Genres;
using LibraryOn.Communication.Responses.Genres;
using LibraryOn.Domain.Entities;
using LibraryOn.Domain.Repositories;
using LibraryOn.Domain.Repositories.Genres;
using LibraryOn.Exception.ExceptionsBase;

namespace LibraryOn.Application.UseCases.Genres.Register;
internal class RegisterGenreUseCase : IRegisterGenreUseCase
{
    private readonly IGenresWriteOnlyRepository _repository;
    private readonly IUnityOfWork _unityOfWork;
    private readonly IMapper _mapper;

    public RegisterGenreUseCase(IGenresWriteOnlyRepository repository,
        IUnityOfWork unityOfWork, IMapper mapper)
    {
        _repository = repository;
        _unityOfWork = unityOfWork;
        _mapper = mapper;
    }

    public async Task<ResponseRegisteredGenreJson> Execute(RequestGenreJson request)
    {
        Validate(request);

        var entity = _mapper.Map<Genre>(request);

        await _repository.Add(entity);
        await _unityOfWork.Commit();

        return _mapper.Map<ResponseRegisteredGenreJson>(entity);
    }

    private void Validate (RequestGenreJson request)
    {
        var validator = new GenreValidator();
        var result = validator.Validate(request);

        if(result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }

    }
}
