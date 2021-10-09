using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Common.UserRoles
{
    public class UserRole
    {
        [Display(Name = "ادمین")]
        public const string Admin = "Admin";

        [Display(Name = "کاربر عادی")]
        public const string User = "User";

        [Display(Name = "اپراتور")]
        public const string Operator = "Operator";
    }
}
