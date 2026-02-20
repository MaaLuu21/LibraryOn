using LibraryOn.Domain.Security.Tokens;

namespace LibraryOn.Api.Token
{
    public class HttpTokenContextValue : ITokenProvider
    {
        private readonly IHttpContextAccessor _contextAccessor;


        public HttpTokenContextValue(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
        }

        public string TokenOnRequest()
        {
            var authorization = _contextAccessor.HttpContext!.Request.Headers.Authorization.ToString();

            return authorization["Bearer ".Length..].Trim();
        }
    }
}
