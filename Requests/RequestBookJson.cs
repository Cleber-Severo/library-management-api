using LibraryManagementApi.Enums;

namespace LibraryManagementApi.Requests;

public class RequestBookJson
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public EnumGenre Genre { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }

}
