using LibraryManagementApi.Entities;
using LibraryManagementApi.Enums;

namespace LibraryManagementApi.Responses;

public class ResponseBookJson
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public EnumGenre Genre { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public DateTime CreatedAt { get; set; } = default!;
    public DateTime? UpdatedAt { get; set; } = default!;
}
