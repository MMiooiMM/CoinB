namespace CoinB.Middlewares
{
    public class HeaderVerificationMiddleware(RequestDelegate next, string verificationCode)
    {
        private const string HeaderName = "X-BB-Code";

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(HeaderName, out var extractedCode))
            {
                context.Response.StatusCode = 418; // I'm a teapot
                await context.Response.WriteAsync("Verification code is missing.");
                return;
            }

            if (!string.Equals(extractedCode, verificationCode, StringComparison.Ordinal))
            {
                context.Response.StatusCode = 418; // I'm a teapot
                await context.Response.WriteAsync("Invalid verification code.");
                return;
            }

            await next(context);
        }
    }
}
