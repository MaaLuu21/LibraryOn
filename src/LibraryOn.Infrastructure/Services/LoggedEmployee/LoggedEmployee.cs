using LibraryOn.Domain.Entities;
using LibraryOn.Domain.Security.Tokens;
using LibraryOn.Domain.Services.LoggedEmployee;
using LibraryOn.Infrastructure.DataAcess;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace LibraryOn.Infrastructure.Services.LoggedEmployee
{
    public class LoggedEmployee : ILoggedEmployee
    {
        private readonly LibraryOnDbContext _dbContext;
        private readonly ITokenProvider _tokenProvider;

        public LoggedEmployee(LibraryOnDbContext dbContext,
                          ITokenProvider tokenProvider)
        {
            _dbContext = dbContext;
            _tokenProvider = tokenProvider;
        }

        public async Task<Employee> Get()
        {
            string token = _tokenProvider.TokenOnRequest();

            var tokenHandler = new JwtSecurityTokenHandler();

            var jwtSecurityToken = tokenHandler.ReadJwtToken(token);

            var identifier = jwtSecurityToken.Claims.First(claim => claim.Type == ClaimTypes.Sid).Value;

            return await _dbContext
                .Employees
                .AsNoTracking()
                .FirstAsync(employee => employee.EmployeeIdentifier == Guid.Parse(identifier));
        }
    }
}
