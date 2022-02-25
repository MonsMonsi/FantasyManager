using FantasyManager.Domain.Entities;
using FantasyManager.Domain.Enums;
using FantasyManager.Domain.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace FantasyManager.Domain.Services.AuthenticationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthenticationService(IUserService userService, IPasswordHasher<User> passwordHasher)
        {
            _userService = userService;
            _passwordHasher = passwordHasher;
        }

        public async Task<User> Login(string userName, string password)
        {
            User storedUser = await _userService.GetByNameAsync(userName);

            if (storedUser != null)
            {
                PasswordVerificationResult verificationResult = _passwordHasher.VerifyHashedPassword(storedUser, storedUser.PasswordHash, password);

                if (verificationResult != PasswordVerificationResult.Success)
                {
                    throw new InvalidPasswordException(userName, password);
                }

                return storedUser;
            }

            throw new InvalidUserNameException(userName);
        }

        public async Task<RegistrationResult> Register(string userName, string password, string confirmPassword, string email)
        {
            RegistrationResult result = RegistrationResult.Success;

            if (password != confirmPassword)
            {
                result = RegistrationResult.PasswordDoesNotMatch;
            }

            User storedEmailUser = await _userService.GetByEmailAsync(email);

            if (storedEmailUser != null)
            {
                result = RegistrationResult.EmailAlreadyExists;
            }

            User storedNameUser = await _userService.GetByNameAsync(userName);

            if (storedNameUser != null)
            {
                result = RegistrationResult.UserNameAlreadyExists;
            }

            if (result == RegistrationResult.Success)
            {
                string hashedPassword = _passwordHasher.HashPassword(new User(), password);

                User user = new()
                {
                    Name = userName,
                    PasswordHash = hashedPassword,
                    Email = email,
                    JoinedAt = DateTime.Now
                };

                await _userService.CreateAsync(user);
            }

            return result;
        }
    }
}
