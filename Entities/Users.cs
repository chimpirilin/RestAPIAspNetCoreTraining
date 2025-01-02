using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace RestApi.Entities {
    public class Users(string name, string email, string phone)
    {
        private static readonly PasswordHasher<Users> PasswordHasher = new PasswordHasher<Users>();

        [Key]
        public int id { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\s'-]+$", ErrorMessage = "El nombre es invalido")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre no tiene un formato valido")]
        public string name { get; set; } = name;

        [EmailAddress]
        public string email { get; set; } = email;

        [Required]
        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Formato no valido")]
        public string phone { get; set; } = phone;

        [Required]
        public string HashedPassword { get; private set; }
        public string Password {
            set {
                SetPassword(value);
            }
        }

        public void SetPassword(string password) {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password cannot be empty");
            }

            HashedPassword = PasswordHasher.HashPassword(this, password);
        }

        public bool VerifyPassword(string password)
        {
            var verificationResult = PasswordHasher.VerifyHashedPassword(this, HashedPassword, password);
            return verificationResult == PasswordVerificationResult.Success;
        }
    }
}
