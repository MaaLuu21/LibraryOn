using AutoMapper;
using LibraryOn.Communication.Responses.Employee;
using LibraryOn.Domain.Repositories.Employees;

namespace LibraryOn.Application.UseCases.Employee.GetAll;
public class GetAllEmployeesUseCase : IGetAllEmployeesUseCase
{
    private readonly IEmployeeReadOnlyRepository _repository;
    private readonly IMapper _mapper;

    public GetAllEmployeesUseCase(IEmployeeReadOnlyRepository repository,
                                  IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }


    public async Task<ResponseEmployeesJson> Execute()
    {
        var employees = await _repository.GetAll();

        return new ResponseEmployeesJson
        {
            Employees = _mapper.Map<List<ResponseShortEmployeeJson>>(employees)
        };
    }
}
