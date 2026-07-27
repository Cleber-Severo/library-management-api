using LibraryManagementApi.Requests;
using LibraryManagementApi.Responses;
using LibraryManagementApi.UseCases.Books.GetAll;
using LibraryManagementApi.UseCases.Books.GetById;
using LibraryManagementApi.UseCases.Books.Register;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly GetAllBooksUseCase _getAllBooksUseCase;
    private readonly RegisterBookUseCase _registerBookUseCase;
    private readonly GetBookByIdUseCase _getBookByidUseCase;

    public BooksController(
        GetAllBooksUseCase getAllBooksUseCase,
        RegisterBookUseCase registerBookUseCase,
        GetBookByIdUseCase getBookByIdUseCase)
    {
        _getAllBooksUseCase = getAllBooksUseCase;
        _registerBookUseCase = registerBookUseCase;
        _getBookByidUseCase = getBookByIdUseCase;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseShortBookJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestBookJson request)
    {
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

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseAllBooks), StatusCodes.Status200OK)]
    public IActionResult Get() {
     
        var response = _getAllBooksUseCase.Execute();
        if (response.Books.Count == 0)
            return NoContent();

        return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseBookJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
    public IActionResult GetById([FromRoute] Guid id) {
        var response = _getBookByidUseCase.Execute(id);

        return Ok(response);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update(Guid id)
    {
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
   
    public IActionResult Delete(Guid id)
    {
        return NoContent();
    }

}
