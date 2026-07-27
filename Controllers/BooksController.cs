using LibraryManagementApi.Responses;
using LibraryManagementApi.UseCases.Books.GetAll;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly GetAllBooksUseCase _getAllBooksUseCase;

    public BooksController(GetAllBooksUseCase getAllBooksUseCase)
    {
        _getAllBooksUseCase = getAllBooksUseCase;
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
}
