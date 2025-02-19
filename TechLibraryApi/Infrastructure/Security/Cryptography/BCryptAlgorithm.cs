using TechLibraryApi.Domain.Entities;

namespace TechLibraryApi.Infrastructure.Security.Cryptography
{
    public class BCryptAlgorithm
    {
        public string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword("my passoword");

        public bool Verify(string password, User user) => BCrypt.Net.BCrypt.Verify(password, user.Password);
       
    }
}
