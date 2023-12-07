using FluentValidation;
using LibraryAPI.BLL.Models;

namespace LibraryAPI.BLL.Validators
{
    public class CreateBookValidator : AbstractValidator<CreateBookDTO>
    {
        public CreateBookValidator() 
        {
            RuleFor(b => b.ISBN).NotEmpty();
            RuleFor(b => b.Title).NotEmpty()
                .MaximumLength(100);
            RuleFor(b => b.Description).MaximumLength(350);
            RuleFor(b => b.Author).NotEmpty()
                .MaximumLength(100);
            RuleFor(b => b.Genre).NotEmpty()
                .MaximumLength(50);
            RuleFor(b => b.DateOfTaking).NotEmpty();
            RuleFor(b => b.DateOfReturn).NotEmpty();
        }
    }
}
