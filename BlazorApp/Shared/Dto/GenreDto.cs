using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared.Dto
{
    public class GenreDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }

    public class GenreDtoValidator : AbstractValidator<GenreDto>
    {
        public GenreDtoValidator()
        {
            RuleFor(g => g.Name)
                .NotEmpty()
                .MaximumLength(15)
                .WithName("Genre"); // Solo personaliza el nombre del campo
                //.WithMessage("") // Personaliza todo el mensaje
        }
    }
}
