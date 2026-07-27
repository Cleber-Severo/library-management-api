using System.Net;

namespace LibraryManagementApi.ExceptionBase;

public abstract class LibraryManagementApiException : SystemException
{
    public LibraryManagementApiException(string ErrorMessage) : base(ErrorMessage)
    {
    }

    public abstract List<string> GetErrors();
    public abstract HttpStatusCode GetHttpStatuscode();
}
