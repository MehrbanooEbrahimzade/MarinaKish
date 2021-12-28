using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.RepositoryImplementation;

namespace Infrastructure.Extensions
{
    public static class IdentityResultExtensions
    {
        public static Result<string> ToApplicationResult(this IdentityResult result, string message, string data)
        {
            return result.Succeeded
                ? Result<string>.Success(message, data)
                : Result<string>.Failure(result.Errors.Select(e => e.Description));
        }
        //public static Result<string> ToApplicationResult(this SignInResult result , string message , string data)
        //{
        //    return result.Succeeded
        //        ? Result<string>.Success(message, data)
                


        //}
    }
}
