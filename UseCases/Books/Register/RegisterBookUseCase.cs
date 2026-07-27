using LibraryManagementApi.Entities;
using LibraryManagementApi.ExceptionBase;
using LibraryManagementApi.Repositories.Interfaces;
using LibraryManagementApi.Requests;
using LibraryManagementApi.Responses;

namespace LibraryManagementApi.UseCases.Books.Register;

public class RegisterBookUseCase
{
    private readonly IBookRepository _repository;

    public RegisterBookUseCase(IBookRepository repository)
    {
        _repository = repository;
    }

    public ResponseShortBookJson Execute(RequestBookJson request) 
    {
        Validate(request);

        var existingBook = _repository.GetByTitleAndAuthor(
        request.Title,
        request.Author);

        if (existingBook is not null)
        {
            throw new Exception("Book already exists.");
        }

        var entity = new Book
        {
            Title = request.Title,
            Author = request.Author,
            Genre = request.Genre,
            Price = request.Price,
            Stock = request.Stock,
        };

        _repository.Add(entity);

        return new ResponseShortBookJson
        {
            Title = entity.Title,
            Author = entity.Author,
            Genre = entity.Genre,
            Price = entity.Price,
            Id = entity.Id,
        };   
    }

    private void Validate(RequestBookJson request) {
        var validator = new RegisterBookValidator();

        var result = validator.Validate(request);

        if(!result.IsValid)
        {
            var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errors);
        }

    }

}
