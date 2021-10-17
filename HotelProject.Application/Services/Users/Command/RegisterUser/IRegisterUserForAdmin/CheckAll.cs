using System.Collections.Generic;
using static HotelProject.Common.Validation_Pattern.Handler;

namespace HotelProject.Application.Services.Users.Command.RegisterUser.IRegisterUserForAdmin
{
    public class CheckAll
    {
        private string name, mobile, phone, email, password, repassword;
        ValidateHandler Name, Phone, Mobile, Email, Password;
        private List<ValidateHandler> handlers = new List<ValidateHandler>();
        public string message;
        private bool status = true;
        public CheckAll(string name, string mobile, string phone, string email, string password, string repassword)
        {
            this.name = name;
            this.mobile = mobile;
            this.phone = phone;
            this.email = email;
            this.password = password;
            this.repassword = repassword;
            
            Name = new CheckName(name);
            Mobile = new CheckMobile(mobile);
            Phone = new CheckPhone(phone);
            Email = new CheckEmail(email);
            Password = new CheckPassword(password, repassword);

            Name.setSuccessor(Mobile);
            Mobile.setSuccessor(Phone);
            Phone.setSuccessor(Email);
            Email.setSuccessor(Password);
        }
        public bool check()
        {
            handlers.Add(Name);
            handlers.Add(Mobile);
            handlers.Add(Phone);
            handlers.Add(Email);
            handlers.Add(Password);

            Name.ValidateRequest();
            status = Response(handlers);
            return status;
        }

        //Response of validation
        public bool Response(List<ValidateHandler> items)
        {
            bool state = true;
            foreach(var i in items)
            {
                if (i.status == false)
                {
                    this.message = i.message;
                    state = false;
                    break;
                }
                state = true;
            }
            return state;
        }
    }
}
