﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuzluSozluk.Application.Features.Commands.User.CreateUser;

namespace TuzluSozluk.Application.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommandRequest>
    {
        public CreateUserValidator()
        {
            RuleFor(u => u.FirstName)
                .NotEmpty()
                .WithMessage("First name is required.");

            RuleFor(u => u.LastName)
                .NotEmpty()
                .WithMessage("Last name is required.");

            RuleFor(u => u.UserName)
                .NotEmpty()
                .WithMessage("User name is required.");

            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress().WithMessage("Please enter a valid email address.");

            RuleFor(u => u.Password)
                .NotEmpty()
                .WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.");
        }
    }
}
