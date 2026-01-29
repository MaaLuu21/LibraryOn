using LibraryOn.Domain.Security.Cryptography;
using BC = BCrypt.Net.BCrypt;

namespace LibraryOn.Infrastructure.Security.Cryptography;
internal class Bcrypt : IPasswordEncripter
{
    public string Encripty(string password)
    {
        string passwordHash = BC.HashPassword(password);

        return passwordHash;
    }

    public bool Verify(string password, string passworHash) => BC.Verify(password, passworHash);

}
