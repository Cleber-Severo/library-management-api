using LibraryManagementApi.ExceptionBase;
using LibraryManagementApi.Repositories.Interfaces;
using LibraryManagementApi.Requests;
using LibraryManagementApi.UseCases.Books.Update;

namespace LibraryManagementApi.UseCases.Books.Delete;

public class DeleteBookUseCase
{
    private readonly IBookRepository _repository;

    public DeleteBookUseCase(IBookRepository repository)
    {
        _repository = repository;
    }

    public void Execute(Guid id)
    {

        Validate(id);

        _repository.Delete(id);
    }

    private void Validate(Guid id)
    {
        var foundBook = _repository.GetById(id);

        if (foundBook is null)
            throw new NotFoundException("Livro não encontrado");
    }
}
