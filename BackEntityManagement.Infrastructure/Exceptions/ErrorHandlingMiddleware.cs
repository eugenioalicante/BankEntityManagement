using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackEntityManagement.Infrastructure.Exceptions
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IHostingEnvironment _environment;

        public ErrorHandlingMiddleware(RequestDelegate next, IHostingEnvironment environment)
        {
            this.next = next ?? throw new ArgumentNullException(nameof(next));
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this.next(context);
            }
            catch (Exception exception)
            {
                await this.HandleExceptionAsync(context, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.Clear();
            context.Response.ContentType = "application/json";

            var (Status, Message) = exception.CreateResponseMessage();
            context.Response.StatusCode = Status;
           
            return context.Response.WriteAsync(Message);
        }

    }
}
