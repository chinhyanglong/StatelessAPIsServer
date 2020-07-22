using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace StatelessAPIs.Services.Common
{
    public class Utilities
    {
        public static string GetUserNameToTokenJWT(string tokenUser)
        {
            try
            {
                if (String.IsNullOrEmpty(tokenUser))
                {
                    return "";
                }
                var handler = new JwtSecurityTokenHandler();
                var objToken = handler.ReadJwtToken(tokenUser.ToString().Replace("Bearer ", "")).Claims.ToList();

                var userName = objToken[0].Value;

                return userName;
            }
            catch
            {
                return "";
            }
        }

        //public static int GetUserIdFromDbByJwt(UserManager<ApplicationUser> userManager, string tokenUser)
        //{
        //    try
        //    {
        //        if (String.IsNullOrEmpty(tokenUser))
        //        {
        //            return 0;
        //        }
        //        var handler = new JwtSecurityTokenHandler();
        //        var objToken = handler.ReadJwtToken(tokenUser.Replace("Bearer ", "")).Claims.ToList();

        //        var userName = objToken[0].Value;

        //        return userManager.Users.Where(x => x.UserName.ToLower().Equals(userName.ToLower())).Select(x => x.UserId).FirstOrDefault();

        //    }
        //    catch
        //    {
        //        return 0;
        //    }
        //}
    }
}
