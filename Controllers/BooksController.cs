using LibraryManagementApi.Requests;
using LibraryManagementApi.Responses;
using LibraryManagementApi.UseCases.Books.GetAll;
using LibraryManagementApi.UseCases.Books.Register;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly GetAllBooksUseCase _getAllBooksUseCase;
    private readonly RegisterBookUseCase _registerBookUseCase;

    public BooksController(
        GetAllBooksUseCase getAllBooksUseCase,
        RegisterBookUseCase registerBookUseCase)
    {
        _getAllBooksUseCase = getAllBooksUseCase;
        _registerBookUseCase = registerBookUseCase;
    }


    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseAllBooks), StatusCodes.Status200OK)]
    public IActionResult Get() {
     
        var response = _getAllBooksUseCase.Execute();
        if (response.Books.Count == 0)
            return NoContent();

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseShortBookJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestBookJson request) {
        var createdBook = _registerBookUseCase.Execute(request);

        var response = new ResponseShortBookJson
        { 
            Id = createdBook.Id,
            Title = createdBook.Title,
            Author = createdBook.Author,
            Genre = createdBook.Genre,
            Price = createdBook.Price
        };

        return Created(string.Empty, response);
    }
}
