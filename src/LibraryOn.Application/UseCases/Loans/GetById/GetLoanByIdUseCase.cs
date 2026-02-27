using AutoMapper;
using LibraryOn.Application.UseCases.Loans.GetAll;
using LibraryOn.Communication.Responses.Loans;
using LibraryOn.Domain.Entities;
using LibraryOn.Domain.Repositories.Loans;
using LibraryOn.Exception;
using LibraryOn.Exception.ExceptionsBase;

namespace LibraryOn.Application.UseCases.Loans.GetById;
public class GetLoanByIdUseCase : IGetLoanByIdUseCase
{
    private readonly ILoanReadOnlyRepository _repository;
    private readonly IMapper _mapper;

    public GetLoanByIdUseCase(ILoanReadOnlyRepository repository,
                              IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseLoanJson> Execute(long id)
    {
        var result = await _repository.GetById(id);

        if(result == null)
        {
            throw new NotFoundException(ResourceErrorMessages.LOAN_NOT_FOUND);
        }

        return _mapper.Map<ResponseLoanJson>(result);
    }
}
