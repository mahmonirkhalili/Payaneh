using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common
{
    public interface IPasswordHasher
    {
        /// <summary>
        ///     Hash a password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        string HashPassword(string password);

        /// <summary>
        ///     Verify that a password matches the hashed password
        /// </summary>
        /// <param name="hashedPassword"></param>
        /// <param name="providedPassword"></param>
        /// <returns></returns>
        PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword);
    }

    public enum PasswordVerificationResult
    {
        /// <summary>
        ///     Password verification failed
        /// </summary>
        Failed = 0,

        /// <summary>
        ///     Success
        /// </summary>
        Success = 1,

        /// <summary>
        ///     Success but should update and rehash the password
        /// </summary>
        SuccessRehashNeeded = 2
    }
}
