using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LibraryAPI.BLL.ExceptionHandlers
{
	public class GlobalExceptionHandler : IExceptionHandler
	{
		public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
		{
			int statusCode = GetErrorCode(exception);
			ProblemDetails problemDetails = new ProblemDetails
			{
				Status = statusCode,
				Title = exception.Message
			};
			httpContext.Response.StatusCode = statusCode;
			await httpContext.Response.WriteAsJsonAsync(problemDetails);
			return true;
		}

		private static int GetErrorCode(Exception e)
		{
			switch(e)
			{
				case ArgumentNullException _:
					return (int)HttpStatusCode.UnprocessableEntity;
				case ArgumentException _:
					return (int)HttpStatusCode.NotFound;
				default:
					return (int)HttpStatusCode.BadRequest;
			}
		}
	}
}
