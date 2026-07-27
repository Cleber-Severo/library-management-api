using LibraryManagementApi.ExceptionBase;
using LibraryManagementApi.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LibraryManagementApi.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is LibraryManagementApiException libraryManagementApiException)
        {
            context.HttpContext.Response.StatusCode = (int)libraryManagementApiException.GetHttpStatuscode();


            context.Result = new ObjectResult(new ResponseErrorMessagesJson(libraryManagementApiException.GetErrors()));
        }
        else
        {
            ThrowUnknowError(context);
        }
    }

    private void ThrowUnknowError(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(new ResponseErrorMessagesJson("Erro desconhecido."));
    }
}
