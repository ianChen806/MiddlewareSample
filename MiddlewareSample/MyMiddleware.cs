using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace MiddlewareSample
{
    public class MyMiddleware
    {
        private readonly RequestDelegate _next;

        public MyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("Stat");

            await _next.Invoke(context);

            Console.WriteLine("End");
        }
    }

    public static class MyMiddlewareExtension
    {
        public static void UseMyMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<MyMiddleware>();
        }
    }
}