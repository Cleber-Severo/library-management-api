using System.Net;

namespace LibraryManagementApi.ExceptionBase;

public class ErrorOnValidationException : LibraryManagementApiException
{
    private readonly List<string> _errors;

    public ErrorOnValidationException(List<string> errorMessages) : base(string.Empty)
    {
        _errors = errorMessages;
    }

    public override List<string> GetErrors() => _errors;

    public override HttpStatusCode GetHttpStatuscode() => HttpStatusCode.BadRequest;

}
