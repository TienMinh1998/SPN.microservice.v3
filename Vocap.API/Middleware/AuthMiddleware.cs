using Microsoft.Extensions.Options;
using System.Net;

namespace Vocap.API.Middleware;

public class AuthMiddleware : IMiddleware
{
    private readonly ApiKeys apiConfig;
    private readonly string _headerKey = "x-api-key";
    public AuthMiddleware(IOptions<ApiKeys> config)
    {
        apiConfig = config.Value;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (apiConfig.Active == false)
        {
            await next(context);
            return;
        }

        if (!context.Request.Headers.TryGetValue(_headerKey, out var extractedApiKey))
        {
            // if key not found
            context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            await context.Response.WriteAsync("invalid ApI-key");
            return;
        }
        var apiKyes = apiConfig.keys.Contains(extractedApiKey);
        await next(context);
    }
}

public class ApiKeys
{
    public List<string> keys { get; set; }
    public bool Active { get; set; }
}