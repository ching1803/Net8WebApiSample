using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using Web.Models;

namespace Web.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // 根據例外類型回傳不同的狀態碼
            var statusCode = context.Exception switch
            {
                UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
                KeyNotFoundException => (int)HttpStatusCode.NotFound,
                ArgumentException => (int)HttpStatusCode.BadRequest,
                _ => (int)HttpStatusCode.InternalServerError
            };

            var response = ApiResponse.Fail(context.Exception.Message);

            context.Result = new ObjectResult(response)
            {
                StatusCode = statusCode,
            };

            context.ExceptionHandled = true;
        }
    }
}
