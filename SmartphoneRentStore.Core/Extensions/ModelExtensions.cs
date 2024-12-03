namespace SmartphoneRentStore.Core.Extensions
{
    using SmartphoneRentStore.Core.Contracts;
    using System.Text.RegularExpressions;

    public static class ModelExtensions
    {

        public static string GetInformation(this ISmartphoneModel smartphone) // for url swag security
        { 
            string info = smartphone.Title.Replace(" ", "-") + GetDescription(smartphone.Description);
            info = Regex.Replace(info, @"[^a-zA-Z0-9\-]", string.Empty);

            return info;
        }

        private static string GetDescription(string description)
        {
            description = string.Join("-", description.Split(" ").Take(3));

            return description;
        }
    }
}
