using Microsoft.AspNetCore.Http;
using System.Net;

namespace BlogPost.Common
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _requestDelete;

        public CustomExceptionMiddleware(RequestDelegate requestDelete)
        {
            _requestDelete = requestDelete;
        }
        public async Task Invoke(HttpContext context) {
            try
            {
                await _requestDelete(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync(ex.Message);


            }
            

        }
        
    }
}