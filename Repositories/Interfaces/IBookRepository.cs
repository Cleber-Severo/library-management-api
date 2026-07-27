using LibraryManagementApi.Entities;

namespace LibraryManagementApi.Repositories.Interfaces;

public interface IBookRepository
{
    IReadOnlyCollection<Book> GetAll();

    Book? GetById(Guid id);
}
