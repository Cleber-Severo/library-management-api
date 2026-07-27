using LibraryManagementApi.Enums;

namespace LibraryManagementApi.Responses;

public class ResponseShortBookJson
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public EnumGenre Genre { get; set; }
    public decimal Price { get; set; }
}
