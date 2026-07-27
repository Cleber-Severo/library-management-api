using System.Net;

namespace LibraryManagementApi.ExceptionBase;

public class NotFoundException : LibraryManagementApiException
{
    public NotFoundException(string ErrorMessage) : base(ErrorMessage)
    {
    }

    public override List<string> GetErrors() => [Message];
    public override HttpStatusCode GetHttpStatuscode() => HttpStatusCode.NotFound;
}
