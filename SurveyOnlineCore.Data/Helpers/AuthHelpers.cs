using System.Collections;
using System.Linq;
using System.Runtime.InteropServices;
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

        internal static bool VerifyPassword(string password, byte[] customerPassword, byte[] customerSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(customerSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                if (!StructuralComparisons.StructuralEqualityComparer.Equals(customerPassword, computedHash))
                    return false;
                return true;
            }
        }

        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int Memcmp(byte[] b1, byte[] b2, long count);
    }
}
