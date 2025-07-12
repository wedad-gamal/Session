using System.Diagnostics;
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
        var stopwatch = Stopwatch.StartNew();
        var request = context.Request;

        request.EnableBuffering();

        string body = "";
        if (request.Method == HttpMethods.Post)
        {
            using var reader = new StreamReader(request.Body, Encoding.UTF8, leaveOpen: true);
            body = await reader.ReadToEndAsync();
            request.Body.Position = 0;
        }

        var queryParams = request.QueryString.HasValue ? request.QueryString.Value : "";
        _logger.LogInformation("➡️ HTTP Request: {Method} {Path}{Query} | CorrelationId: {CorrelationId}",
            request.Method,
            request.Path,
            queryParams,
            context.Items["X-Correlation-ID"]);


        try
        {
            await _next(context);
            stopwatch.Stop();


            var response = context.Response;

            // Log Response Info
            _logger.LogInformation("⬅️ HTTP Response: {StatusCode} | Duration: {Elapsed} ms",
                context.Response.StatusCode,
                stopwatch.ElapsedMilliseconds);

        }
        catch (Exception ex)
        {

            stopwatch.Stop();

            _logger.LogError(ex, "🔥 Exception during HTTP Request {Method} {Path}. | CorrelationId: {CorrelationId} | Took {Elapsed} ms",
                request.Method,
                request.Path,
                context.Items["X-Correlation-ID"],
                stopwatch.ElapsedMilliseconds);

            throw; // Re-throw to preserve pipeline behavior
        }
    }
}
