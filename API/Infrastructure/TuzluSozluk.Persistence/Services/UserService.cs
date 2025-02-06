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
using TuzluSozluk.Application.DTOs;

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

        public async Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request)
        {
            User existingUserByUsername = await _userRepository.GetSingleAsync(u => u.UserName == request.UserName);
            if (existingUserByUsername is not null)
            {
                throw new DatabaseValidationException("Oops! That username is taken.");
            }

            User existingUserByEmail = await _userRepository.GetSingleAsync(u => u.Email == request.Email);
            if (existingUserByEmail is not null)
            {
                throw new DatabaseValidationException("Oops! That email is already in use.");
            }

            User user = new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                Email = request.Email,
                Password = PasswordEncryptor.Encrypt(request.Password)
            };
            await _userRepository.AddAsync(user);
            await _userRepository.SaveAsync();

            return new()
            {
                UserId = user.Id,
                Succeeded = true,
                Message = "You’ve successfully signed up!"
            };
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
