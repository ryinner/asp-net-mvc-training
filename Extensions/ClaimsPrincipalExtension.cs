using System.Security.Claims;

namespace AspDotNetMVC.Extensions
{
    public static class ClaimsPrincipalExtension
    {
        public static string GetUserId(this ClaimsPrincipal user)
        {

            return user.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
