using FluentValidation;
using LibraryManagementApi.Requests;

namespace LibraryManagementApi.UseCases.Books.Register;

public class RegisterBookValidator : AbstractValidator<RequestBookJson>
{
    public RegisterBookValidator()
    {
        RuleFor(book => book.Title).NotEmpty().WithMessage("O nome não pode ser vazio");
        RuleFor(book => book.Author).NotEmpty().WithMessage("Autor não pode ser vazio");
        RuleFor(book => book.Genre).NotEmpty().WithMessage("Genero nome não pode ser vazio");
        RuleFor(book => book.Price).GreaterThan(0).WithMessage("Preço inválido.");
        RuleFor(book => book.Stock).GreaterThan(0).WithMessage("Para cadastrar um produto é necesário estoque.");
    }

}
