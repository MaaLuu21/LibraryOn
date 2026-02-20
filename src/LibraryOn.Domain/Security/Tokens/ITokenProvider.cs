namespace LibraryOn.Domain.Security.Tokens
{
    public  interface ITokenProvider
    {
        string TokenOnRequest();
    }
}
