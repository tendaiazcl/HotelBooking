using HotelBooking.Application.Exceptions;

namespace HotelBooking.Api.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(
        RequestDelegate next,
        ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var traceId = context.TraceIdentifier;

        using var scope = _logger.BeginScope(
            new Dictionary<string, object>
            {
                ["TraceId"] = traceId
            });

        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            _logger.LogError(
                exception,
                "Unhandled exception occurred.");

            await HandleExceptionAsync(
                context,
                exception);
        }
    }

    private static async Task HandleExceptionAsync(
        HttpContext context,
        Exception exception)
    {
        var statusCode = exception switch
        {
            CustomerNotFoundException =>
                StatusCodes.Status404NotFound,

            RoomNotFoundException =>
                StatusCodes.Status404NotFound,

            BookingNotFoundException =>
                StatusCodes.Status404NotFound,

            RoomNotAvailableException =>
                StatusCodes.Status409Conflict,

            ArgumentException =>
                StatusCodes.Status400BadRequest,

            _ =>
                StatusCodes.Status500InternalServerError
        };
        var traceId = context.TraceIdentifier;

        context.Response.StatusCode = statusCode;

        await Results.Problem(
        statusCode: statusCode,
        title: GetTitle(statusCode),
        detail: GetDetail(exception, statusCode),
        extensions: new Dictionary<string, object?>
        {
            ["traceId"] = traceId
        })
        .ExecuteAsync(context);
    }

    private static string GetTitle(int statusCode)
    {
        return statusCode switch
        {
            StatusCodes.Status400BadRequest =>
                "Bad Request",

            StatusCodes.Status404NotFound =>
                "Resource Not Found",

            StatusCodes.Status409Conflict =>
                "Conflict",

            _ =>
                "An unexpected error occurred"
        };
    }

    private static string? GetDetail(
        Exception exception,
        int statusCode)
    {
        if (statusCode == StatusCodes.Status500InternalServerError)
        {
            return "An unexpected error occurred.";
        }

        return exception.Message;
    }
}