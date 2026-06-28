using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Fitness.Core.Models
{
    public class User
    {
        public const int MAX_NAME_LENGH = 20;
        public const int MIN_NAME_LENGH = 3;

        private User(Guid id, string name, string passwordHash, string email) 
        {
            Id = id;
            Name = name;
            PasswordHash = passwordHash;
            Email = email;
        }

        public Guid Id { get; set; }
        public string Name { get; private set; } = string.Empty;
        public string PasswordHash { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;

        public static (User User, string Error) Create (Guid id, string name, string passwordHash, string email)
        {
            var error = string.Empty;

            if (string.IsNullOrWhiteSpace(name))
            {
                error = "Name is required";
            }
            else if (name.Length < MIN_NAME_LENGH)
            {
                error = "The name must be less than 3 characters long.";
            }
            else if (name.Length > MAX_NAME_LENGH)
            {
                error = "The name must be more than 20 characters long.";
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                error = "Email is required";
            }
            else if (!email.Contains("@") || !email.Contains("."))
            {
                error = "Invalid email format";
            }

            var user = new User(id, name, passwordHash, email);

            return (user, error);
        }
    }
}
