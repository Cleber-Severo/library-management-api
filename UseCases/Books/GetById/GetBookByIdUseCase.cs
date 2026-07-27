using LibraryManagementApi.ExceptionBase;
using LibraryManagementApi.Repositories.Interfaces;
using LibraryManagementApi.Responses;

namespace LibraryManagementApi.UseCases.Books.GetById;

public class GetBookByIdUseCase
{
    private readonly IBookRepository _repository;

    public GetBookByIdUseCase(IBookRepository repository)
    {
        _repository = repository;
    }

    public ResponseBookJson Execute(Guid id) { 
        var entity = _repository.GetById(id);

        if (entity is null)
            throw new NotFoundException("Livro não encontrado.");


        return new ResponseBookJson
        {
            Id = entity.Id,
            Title = entity.Title,
            Author = entity.Author,
            Genre = entity.Genre,
            Price = entity.Price,
            Stock = entity.Stock,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
        };
    } 

}
