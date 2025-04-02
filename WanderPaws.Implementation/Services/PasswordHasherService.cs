using WanderPaws.Application.Interfaces;
using WanderPaws.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace WanderPaws.Implementation.Services
{
    public class PasswordHasherService : IPasswordHasherService
    {
        private readonly PasswordHasher<User> _passwordHasher;

        public PasswordHasherService()
        {
            _passwordHasher = new PasswordHasher<User>();
        }

        public string HashPassword(string password)
        {
            // Kreira hash lozinke za korisnika
            var user = new User();  // Dummy user, we don't need to actually use a specific user here.
            return _passwordHasher.HashPassword(user, password);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            // Proverava da li se unesena lozinka poklapa sa hashiranom lozinkom
            var user = new User();  // Dummy user, just for verification purpose.
            var result = _passwordHasher.VerifyHashedPassword(user, hashedPassword, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}
