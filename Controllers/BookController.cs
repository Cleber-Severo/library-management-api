using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() {
        return Ok("Livros");
    }
}
