using LibraryOn.Communication.Responses;
using LibraryOn.Exception;
using LibraryOn.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LibraryOn.Api.csproj.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if(context.Exception is LibraryOnException)
        {
            HandleProjectException(context);
        }
        else
        {
            ThrowUnknowError(context);
        }
    }

    private void HandleProjectException(ExceptionContext context)
    {
        var libraryOnException = (LibraryOnException)context.Exception;
        var errorResponse = new ResponseErrorJson(libraryOnException.GetErrors());

        context.HttpContext.Response.StatusCode = libraryOnException.StatusCode;
        context.Result = new ObjectResult(errorResponse);
    }
    private void ThrowUnknowError(ExceptionContext context)
    {
        var errorResponse = new ResponseErrorJson(ResourceErrorMessages.UNKNOW_ERROR);
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);
    }
}
