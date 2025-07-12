namespace MVC.Presentation.Middlewares;

public class ResponseLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ResponseLoggingMiddleware> _logger;

    public ResponseLoggingMiddleware(RequestDelegate next, ILogger<ResponseLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var originalBodyStream = context.Response.Body;

        using (var memoryStream = new MemoryStream())
        {
            context.Response.Body = memoryStream;

            await _next(context);

            memoryStream.Seek(0, SeekOrigin.Begin);
            var responseBody = await new StreamReader(memoryStream).ReadToEndAsync();
            memoryStream.Seek(0, SeekOrigin.Begin);

            // Log to Seq            
            _logger.LogInformation("Response to {Path}: {Body}", context.Request.Path, responseBody);
            await memoryStream.CopyToAsync(originalBodyStream);
            context.Response.Body = originalBodyStream;
        }
    }
}
