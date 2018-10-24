using System.Text.RegularExpressions;

namespace SimpleRestApiUtility
{
    public static class RegExValidation
    {
        public const string NameRegex = @"^(?i)([a-zA-Z])[a-zA-Z'\-\._ ]+$";
        public const string MobileRegex = @"^[6789]\d{9}$";
        public const string EmailRegex = @"^[a-z0-9._-]+@([a-z0-9-]+\.)+[a-z]{2,6}$";

        /// <summary>
        /// check for mobile validity
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public static bool IsValidMobile(string mobile)
        {
            var mobileRegEx = new Regex(MobileRegex);
            return mobileRegEx.IsMatch(mobile ?? string.Empty);
        }
        /// <summary>
        /// check for name validity
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool IsValidName(string name)
        {
            Regex nameRegex = new Regex(NameRegex);
            return nameRegex.IsMatch(name ?? string.Empty);
        }
        /// <summary>
        /// check for email validity
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool IsValidEmail(string email)
        {
            var emailRegEx = new Regex(EmailRegex);
            return emailRegEx.IsMatch(email ?? string.Empty);
        }
    }
}
