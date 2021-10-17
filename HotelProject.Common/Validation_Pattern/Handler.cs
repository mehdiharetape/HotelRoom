using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HotelProject.Common.Validation_Pattern
{
    public class Handler
    {
        public abstract class ValidateHandler
        {
            protected ValidateHandler successor;
            public string message;
            public bool status = true;
            public void setSuccessor(ValidateHandler successor)
            {
                this.successor = successor;
            }
            public abstract void ValidateRequest();
        }

        //check name
        public class CheckName : ValidateHandler
        {
            private string name;
            public CheckName(string name)
            {
                this.name = name;
            }
            public override void ValidateRequest()
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    message = "نام را وارد کنید";
                    status = false;
                }
                else
                {
                    if (successor != null)
                        successor.ValidateRequest();
                }
            }
        }

        //check mobile
        public class CheckMobile : ValidateHandler
        {
            private string mobile;
            public CheckMobile(string mobile)
            {
                this.mobile = mobile;
            }
            public override void ValidateRequest()
            {
                if (string.IsNullOrWhiteSpace(mobile))
                {
                    message = "موبایل را وارد کنید";
                    status = false;
                }
                else
                {
                    if (successor != null)
                        successor.ValidateRequest();
                }
            }
        }

        //check phone
        public class CheckPhone : ValidateHandler
        {
            private string phone;
            public CheckPhone(string phone)
            {
                this.phone = phone;
            }
            public override void ValidateRequest()
            {
                if (string.IsNullOrWhiteSpace(phone))
                {
                    message = "تلفن را وارد کنید";
                    status = false;
                }
                else
                {
                    if (successor != null)
                        successor.ValidateRequest();
                }
            }
        }

        //check password
        public class CheckPassword : ValidateHandler
        {
            private string pass;
            private string rePassword;
            public CheckPassword(string pass,string repass)
            {
                this.pass = pass;
                rePassword = repass;
            }
            public override void ValidateRequest()
            {
                if (string.IsNullOrWhiteSpace(pass) || string.IsNullOrWhiteSpace(rePassword))
                {
                    message = "رمز عبور را وارد کنید";
                    status = false;
                }
                else if(pass.Length < 8)
                {
                    message = "رمز عبور حداقل باید 8 کاراکتر باشد";
                    status = false;
                }
                else if (!CheckRepassword(pass, rePassword))
                {
                    message = "تکرار مز عبور اشتباه است";
                    status = false;
                }
                else
                {
                    if (successor != null)
                        successor.ValidateRequest();
                }
            }

            private bool CheckRepassword(string pass, string repass)
            {
                if (pass != repass)
                    return false;
                return true;
            }
        }

        //check email
        public class CheckEmail : ValidateHandler
        {
            private string email;
            public CheckEmail(string email)
            {
                this.email = email;
            }
            public override void ValidateRequest()
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    message = "ایمیل را وارد کنید";
                    status = false;
                }
                else if (!checkTrueEmail(email))
                {
                    message = "ایمیل را به درستی وارد کنید";
                    status = false;
                }
                else
                {
                    if (successor != null)
                        successor.ValidateRequest();
                }
            }

            public bool checkTrueEmail(string email)
            {
                string emailRegex = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[A-Z0-9.-]+\.[A-Z]{2,}$";
                var match = Regex.Match(email, emailRegex, RegexOptions.IgnoreCase);
                if (!match.Success)
                    return false;
                else
                    return true;
            }
        }//end of check mail
    }
}
