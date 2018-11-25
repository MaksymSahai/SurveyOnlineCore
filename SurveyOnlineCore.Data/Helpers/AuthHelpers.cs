using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyOnlineCore.Data.Helpers
{
    public static class AuthHelpers
    {
        internal static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        internal static bool VerifyPassword(string password, string customerPassword, string customerSalt)
        {
            var customerSaltByte = Encoding.UTF8.GetBytes(customerSalt);
            using (var hmac = new System.Security.Cryptography.HMACSHA512(customerSaltByte))
            {
                var computedHash = Encoding.Default.GetString(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
                if (customerPassword.Equals(computedHash))
                    return false;
                return true;
            }
        }
    }
}
