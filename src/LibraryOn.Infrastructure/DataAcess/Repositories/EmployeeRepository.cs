using LibraryOn.Domain.Entities;
using LibraryOn.Domain.Repositories.Employees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOn.Infrastructure.DataAcess.Repositories;
internal class EmployeeRepository : IEmployeeWriteOnlyRepository, IEmployeeReadOnlyRepository
{
    private readonly LibraryOnDbContext _dbContext;

    public EmployeeRepository(LibraryOnDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Employee employee)
    {
       await _dbContext.Employees.AddAsync(employee);
    }

    public async Task<bool> ExistActiveEmployeeWithEmail(string email)
    {
        return await _dbContext.Employees.AnyAsync(e => e.Email.Equals(email));
    }

    public async Task<Employee?> GetEmployeeEmail(string email)
    {
        return await _dbContext.Employees.AsNoTracking().FirstOrDefaultAsync(e => e.Email.Equals(email));
    }
}
