using LibraryOn.Domain.ValueObjects;
using System.Drawing;

namespace LibraryOn.Domain.Entities;
public class Reader
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public PhoneNumber PhoneNumber { get; private set; }
    public Email Email { get; private set; }

    public Reader(PhoneNumber phoneNumber)
    {
        PhoneNumber = phoneNumber;
    }

}
