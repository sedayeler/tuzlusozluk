using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuzluSozluk.Application.Services;
using TuzluSozluk.Common.Exceptions;
using TuzluSozluk.Common;
using TuzluSozluk.Domain.Entities;
using TuzluSozluk.Application.Repositories;

namespace TuzluSozluk.Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public UserService(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            User user = await _userRepository.GetSingleAsync(u => u.Email == email);
            if (user == null)
                throw new DatabaseValidationException("User not found.");

            var hashPass = PasswordEncryptor.Encrypt(password);
            if (hashPass != user.Password)
                throw new DatabaseValidationException("Email and/or password is incorrect.");

            if (!user.EmailConfirmed)
                throw new DatabaseValidationException("Email is not confirmed yet.");

            string token = _tokenService.CreateToken(15, user);

            return token;
        }
    }
}
