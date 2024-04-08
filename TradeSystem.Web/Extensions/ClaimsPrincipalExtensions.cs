namespace System.Security.Claims
{
    public static class ClaimsPrincipalExtensions
    {
        public static string Id(this ClaimsPrincipal user)
        {
            var result = (user.FindFirstValue(ClaimTypes.NameIdentifier));
            return result;
        }

    }
}
