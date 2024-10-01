public class JwtMiddleware
{
    private readonly RequestDelegate _next;

    public JwtMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last(); // Line 28 might be here

        if (token != null)
        {
            // Validate the token and set the user principal
            // If this part of the code is accessing a null object, check it
        }

        await _next(context);
    }
}
