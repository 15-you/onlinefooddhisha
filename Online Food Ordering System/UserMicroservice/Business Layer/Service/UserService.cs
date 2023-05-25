using FluentAssertions.Common;
using Microsoft.IdentityModel.Tokens;
using Online_Food_Ordering_System.UserMicroservice.Business_Layer.DTO;
using Online_Food_Ordering_System.UserMicroservice.Data_Access_Layer.Models;
using Online_Food_Ordering_System.UserMicroservice.Data_Access_Layer.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Online_Food_Ordering_System.UserMicroservice.Business_Layer.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration )
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public void RegisterUser(UserDto userDto)
        {
            // Check if the username is already taken
            var existingUser = _userRepository.GetByUsername(userDto.Username);
            if (existingUser != null)
            {
                throw new Exception("Username is already taken.");
            }

            // Check if the email is already taken
            var existingEmail = _userRepository.GetByUsername(userDto.Username);
            if (existingEmail != null)
            {
                throw new Exception("Email is already taken.");
            }

            // Create a new User entity
            var newUser = new User
            {
                Username = userDto.Username,
                Password = HashPassword(userDto.Password),
                ConfirmPassword = HashPassword(userDto.ConfirmPassword),
                Email = userDto.Email,
                IsAdmin = userDto.IsAdmin
            };

            // Save the user to the repository
            _userRepository.Add(newUser);
            _userRepository.SaveChanges();
        }

        public string Login(UserLoginDTO userLoginDto)
        {
            // Retrieve the user from the repository
            var user = _userRepository.GetByUsername(userLoginDto.Username);
            if (user == null)
            {
                throw new Exception("Invalid username or password.");
            }

            // Verify the user's password
            if (!VerifyPassword(userLoginDto.Password, user.Password))
            {
                throw new Exception("Invalid username or password.");
            }

            // Generate and return the authentication token
            var token = GenerateToken(user.Username, user.IsAdmin);
            return token;
        }

        public string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        public bool VerifyPassword(string enteredPassword, string hashedPassword)
        {
            var hashedBytes = Convert.FromBase64String(hashedPassword);
            using (var sha256 = SHA256.Create())
            {
                var enteredPasswordHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(enteredPassword));
                return hashedBytes.SequenceEqual(enteredPasswordHash);
            }
        }

        public string GenerateToken(string username, bool isAdmin)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("Jwt:Key")); // Replace with your own secret key
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, isAdmin ? "Admin" : "User") // Add role claim based on isAdmin flag
        }),
                Expires = DateTime.UtcNow.AddDays(7), // Set the token expiration time
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
