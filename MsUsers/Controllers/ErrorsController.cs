using System;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MsUsers.Domain.Contracts;

namespace MsUsers.Controllers
{
	public class ErrorsController : Controller
    {
		[HttpGet("/error")]
		public IActionResult Error()
		{
			Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

			var (statusCode, message, detail) = exception switch
			{
				IError error => ((int) error.StatusCode, error.ErrorMessage, error.ErrorDetail),
				_ => (StatusCodes.Status500InternalServerError, "Internal error.", "An error has occurred. Please contact the administrator.")
			};

			return Problem(statusCode: statusCode, title: message, detail: detail);
		}
	}
}