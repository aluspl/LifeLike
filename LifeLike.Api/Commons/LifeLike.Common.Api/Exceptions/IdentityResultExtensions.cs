#region Usings

using System;
using System.Linq;
using System.Threading.Tasks;
using LifeLike.Common.Enums;
using LifeLike.Common.Model;
using Microsoft.AspNetCore.Identity;

#endregion

namespace LifeLike.Common.Api.Exceptions
{
    public static class IdentityResultExtensions
    {
        public static void ThrowIfFailed(this IdentityResult identityResult)
        {
            if (identityResult is null)
            {
                throw new ArgumentNullException(nameof(identityResult));
            }

            if (!identityResult.Succeeded)
            {
                throw new Common.Exceptions.LoginException(
                    ErrorType.Unexpected,
                    identityResult
                        .Errors
                        .Select(x => new Error(ErrorType.Unexpected, x.Description)));
            }
        }

        public static async Task<IdentityResult> ThrowIfFailed(this Task<IdentityResult> task)
        {
            if (task is null)
            {
                throw new ArgumentNullException(nameof(task));
            }

            var identityResult = await task;

            identityResult.ThrowIfFailed();

            return identityResult;
        }
    }
}
