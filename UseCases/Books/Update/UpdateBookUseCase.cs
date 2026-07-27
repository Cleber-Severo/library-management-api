using LibraryManagementApi.ExceptionBase;
using LibraryManagementApi.Repositories.Interfaces;
using LibraryManagementApi.Requests;

namespace LibraryManagementApi.UseCases.Books.Update;

public class UpdateBookUseCase
{
    private readonly IBookRepository _repository;

    public UpdateBookUseCase(IBookRepository repository)
    {
        _repository = repository;
    }

    public void Execute(RequestUpdateBookJson request, Guid id)
    {

        Validate(request, id);

        _repository.Update(request, id);
    }

    private void Validate(RequestUpdateBookJson request, Guid id)
    {
        var validator = new UpdateBookValidator();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errors);
        }

        var foundBook = _repository.GetById(id);

        if (foundBook is null)
            throw new NotFoundException("Livro não encontrado");

        var existingBook = _repository.GetByTitleAndAuthor(
            request.Title,
            request.Author
        );

        if (existingBook is not null)
        {
            throw new ErrorOnValidationException(["Um livro com este titulo e autor já existe."]);
        }
    }
}
