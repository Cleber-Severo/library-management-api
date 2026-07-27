using LibraryManagementApi.Entities;
using LibraryManagementApi.Requests;

namespace LibraryManagementApi.Repositories.Interfaces;

public interface IBookRepository
{
    IReadOnlyCollection<Book> GetAll();
    Book? GetById(Guid id);
    void Add(Book book);
    Book? GetByTitleAndAuthor(string title, string author);
    void Update(RequestUpdateBookJson request, Guid id);
}
