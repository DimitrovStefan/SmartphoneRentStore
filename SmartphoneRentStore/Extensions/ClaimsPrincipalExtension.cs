namespace SmartphoneRentStore.Extensions
{
    using System.Security.Claims;
    using static SmartphoneRentStore.Core.Constants.AdministratorConstants;


    public static class ClaimsPrincipalExtension
    {
        public static string Id(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return user.IsInRole(AdminRole);
        }

    }
}
