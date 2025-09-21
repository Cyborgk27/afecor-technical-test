using TT.Domain.Commons;

namespace TT.Domain.Entities
{
    public class Client : BaseEntity<int>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        private Client() { }

        public Client(string firstName, string lastName, string email, string phone, string address)
        {
            if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentException("First name is required");
            if (!email.Contains("@")) throw new ArgumentException("Invalid email");

            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Address = address;
        }

    }
}
