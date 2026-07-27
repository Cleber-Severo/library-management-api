using FluentValidation;
using LibraryManagementApi.Requests;

namespace LibraryManagementApi.UseCases.Books.Update;

public class UpdateBookValidator : AbstractValidator<RequestUpdateBookJson>
{
    public UpdateBookValidator()
    {
        RuleFor(book => book.Title).NotEmpty().WithMessage("O nome não pode ser vazio");
        RuleFor(book => book.Author).NotEmpty().WithMessage("Autor não pode ser vazio");
    }
}
