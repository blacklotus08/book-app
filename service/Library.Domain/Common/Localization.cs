using Library.Domain.Attributes;

namespace Library.Domain.Common
{
    public class Localization
    {
        public const string NoRecordFound = "No record found on: {0}";
        public const string FriendlyErrorMessage = "Uh oh. Something went wrong.";
        public const string FriendlySuccessMessage = "Success!";
        public const string ErrorOnPersist = "Error saving when {0}";
        public const string EntityIsNull = "Entity for {0} is null";

        public static string GetEntityFriendlyName(Type entity)
        {
            var getCustomAttribute = entity.GetCustomAttributes(typeof(FriendlyNameAttribute), true);
            if (getCustomAttribute != null)
            {
                return getCustomAttribute.Cast<FriendlyNameAttribute>().First().Name;
            }
            else
            {
                return entity.Name;
            }
        }
    }
}
