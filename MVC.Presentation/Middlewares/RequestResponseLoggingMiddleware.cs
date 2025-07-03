using System.Text;

namespace MVC.Presentation.Middlewares;

public class RequestResponseLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestResponseLoggingMiddleware> _logger;

    public RequestResponseLoggingMiddleware(RequestDelegate next, ILogger<RequestResponseLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        context.Request.EnableBuffering();

        string body = "";
        if (context.Request.Method == HttpMethods.Post)
        {
            using var reader = new StreamReader(context.Request.Body, Encoding.UTF8, leaveOpen: true);
            body = await reader.ReadToEndAsync();
            context.Request.Body.Position = 0;
        }

        var queryParams = context.Request.QueryString.HasValue ? context.Request.QueryString.Value : "";
        _logger.LogInformation("HTTP {Method} - Path: {Path}, Query: {Query}, Body: {Body}",
            context.Request.Method,
            context.Request.Path,
            queryParams,
            body);
        await _next(context); // Continue down pipeline

        var response = context.Response;
        _logger.LogInformation("Outgoing Response: {StatusCode}", response.StatusCode);
    }
}
