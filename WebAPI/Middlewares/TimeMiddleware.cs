namespace WebAPI.Middlewares
{
    public class TimeMiddleware
    {
        readonly RequestDelegate next; // RequestDelegate permite hacer el llamado al siguiente middleware

        public TimeMiddleware(RequestDelegate nextRequest)
        {
            next = nextRequest;
        }

        public async Task Invoke(HttpContext context) // Toda la información del request viene en el HttpContext
        {
            await next(context); // Primero, hace un llamado al siguiente middleware

            // Luego ejecuta la lógica de este middleware
            if (context.Request.Query.Any(p => p.Key == "time"))
            {
                await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
            }
        }
    }

    public static class TimeMiddlewareExtension
    {
        public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TimeMiddleware>();
        }
    }
}
