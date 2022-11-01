using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MsUsers.Domain.Contracts;
using MsUsers.Domain.Exceptions;
using Newtonsoft.Json;

namespace MsUsers.Configurations
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            this.next = next;
            this._logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(exception: ex, message: ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var (statusCode, message, detail) = exception switch
            {
                IError error => ((int)error.StatusCode, error.ErrorMessage, error.ErrorDetail),
                DbUpdateException dbUpdateException => ((int) HttpStatusCode.BadRequest, "Database failure", "duplicated register"),
                _ => (StatusCodes.Status500InternalServerError, "Internal error.", "An error has occurred. Please contact the administrator.")
            };

            ProblemDetails problem = new ProblemDetails();
            problem.Detail = detail;
            problem.Title = message;
            problem.Status = statusCode;
            problem.Type = exception.GetType().Name;

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(
                problem, Newtonsoft.Json.Formatting.None,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                }));
        }
    }
}

