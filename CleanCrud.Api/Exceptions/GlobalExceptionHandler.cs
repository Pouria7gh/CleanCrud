using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace CleanCrud.Api.Exceptions
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {

            var problemDetails = new ProblemDetails();
            problemDetails.Instance = httpContext.Request.Path;

            if (exception is FluentValidation.ValidationException validationException)
            {
                problemDetails.Title = "One or more validation exception occured";
                problemDetails.Status = (int)HttpStatusCode.BadRequest;
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                List<string> errors = new List<string>();
                foreach(var error in validationException.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
                problemDetails.Extensions.Add("errors", errors);
            }


            problemDetails.Status = httpContext.Response.StatusCode;
            await httpContext.Response.WriteAsJsonAsync(problemDetails).ConfigureAwait(false);

            return true;
        }
    }
}
