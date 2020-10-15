using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class CorsMiddleware
{
    private readonly RequestDelegate _next;
    public CorsMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if (!context.Response.Headers.ContainsKey("Access-Control-Allow-Origin"))
        {
            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
        }
        await _next(context);
    }
}