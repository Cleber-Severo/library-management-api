using LibraryManagementApi.Entities;
using LibraryManagementApi.Enums;
using LibraryManagementApi.Repositories.Interfaces;
using LibraryManagementApi.Requests;

namespace LibraryManagementApi.Repositories.InMemory;

public class InMemoryBookRepository : IBookRepository
{
    private readonly List<Book> _books =
    [
        new()
        {
            Title = "Clean Code",
            Author = "Robert C. Martin",
            Genre = EnumGenre.Romance,
            Price = 129.90m,
            Stock = 10
        },
        new()
        {
            Title = "Harry Potter",
            Author = "J. K. Rowling",
            Genre = EnumGenre.Adventure,
            Price = 79.90m,
            Stock = 20
        }
    ];

    public void Add(Book book)
    {
        _books.Add(book);
    }

    public Book? GetByTitleAndAuthor(string title, string author)
    {
        return _books.FirstOrDefault(book =>
            book.Title == title &&
            book.Author == author);
    }

    public bool Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<Book> GetAll() => _books;

    public Book? GetById(Guid id)
        => _books.FirstOrDefault(book => book.Id == id);

    public void Update(RequestUpdateBookJson request, Guid id)
    {
        var book = _books.FirstOrDefault(book => book.Id == id);

        if (book is null) return;

        book.Title = request.Title;
        book.Author = request.Author;
        book.UpdatedAt = DateTime.UtcNow;
    }
    IReadOnlyCollection<Book> IBookRepository.GetAll()
    {
        return GetAll();
    }
}