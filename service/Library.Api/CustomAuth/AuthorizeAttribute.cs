using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;

namespace Library.Api.CustomAuth
{
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private const string APIKEYNAME = "X-Api-Token";
        private static string? _apiKey;

        public static void SetApiKey(string apiKey)
        {
            _apiKey = apiKey;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "API Key is missing."
                };
                return;
            }
            Console.WriteLine("APIKEY");
            Console.WriteLine(_apiKey);
            Console.WriteLine("EXTRACTED");
            Console.WriteLine(extractedApiKey);
            if (string.IsNullOrWhiteSpace(_apiKey) || !_apiKey.Trim().Equals(extractedApiKey.ToString().Trim(), StringComparison.Ordinal))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Unauthorized client."
                };
                return;
            }
        }
    }
}
