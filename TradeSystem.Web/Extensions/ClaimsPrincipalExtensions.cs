namespace System.Security.Claims
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid Id(this ClaimsPrincipal user)
        {
            var result = Guid.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier));
            return result;
        }
    }
}
