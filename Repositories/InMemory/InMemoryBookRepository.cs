using LibraryManagementApi.Entities;
using LibraryManagementApi.Enums;
using LibraryManagementApi.Repositories.Interfaces;

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

    public bool Update(Book book)
    {
        throw new NotImplementedException();
    }

    IReadOnlyCollection<Book> IBookRepository.GetAll()
    {
        return GetAll();
    }
}