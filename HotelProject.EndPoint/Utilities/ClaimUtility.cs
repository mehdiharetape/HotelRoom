using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HotelProject.EndPoint.Utilities
{
    public class ClaimUtility
    {
        public static long? GetUserId(ClaimsPrincipal User)
        {
            try
            {
                var claimsIdentity = User.Identity as ClaimsIdentity;
                if (claimsIdentity.FindFirst(ClaimTypes.NameIdentifier) != null)
                {
                    long UserId = long.Parse(claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);
                    return UserId;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
