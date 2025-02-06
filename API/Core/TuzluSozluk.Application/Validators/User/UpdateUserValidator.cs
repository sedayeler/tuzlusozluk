using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuzluSozluk.Application.Features.Commands.UpdateUser;

namespace TuzluSozluk.Application.Validators.User
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommandRequest>
    {
        public UpdateUserValidator()
        {
            RuleFor(u => u.Id)
                .NotEmpty()
                .WithMessage("Id is required.");

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
        }
    }
}

