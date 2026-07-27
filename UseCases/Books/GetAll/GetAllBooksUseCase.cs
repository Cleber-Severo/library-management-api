using LibraryManagementApi.Repositories.Interfaces;
using LibraryManagementApi.Responses;

namespace LibraryManagementApi.UseCases.Books.GetAll;

public class GetAllBooksUseCase
{
    private readonly IBookRepository _repository;

    public GetAllBooksUseCase(IBookRepository repository)
    {
        _repository = repository;
    }


    public ResponseAllBooks Execute() {
        var booksList = _repository.GetAll().ToList();

        return new ResponseAllBooks
        {
            Books = booksList.Select(book => new ResponseShortBookJson{
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre,
                Price = book.Price,
            }).ToList()
        };
    }
}
