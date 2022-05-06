using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Dto
{
    public class ActorDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int YearsActive { get; set; }
        public string PhotoUrl { get; set; }
        public string Bio { get; set; }
    }

    public class ActorDtoValidator : AbstractValidator<ActorDto>
    {
        public ActorDtoValidator()
        {
            RuleFor(a => a.FirstName)
                .NotEmpty()
                .WithName("First Name");

            RuleFor(a => a.LastName)
                .NotEmpty()
                .WithName("Last Name");

            RuleFor(a => a.DateOfBirth)
                .NotEmpty()
                .WithName("Date of birth");

            RuleFor(a => a.YearsActive)
                .GreaterThan(-1)
                .WithName("Years active");

            RuleFor(a => a.Bio)
                .MaximumLength(100)
                .WithName("Biography");

        }
    }
}
