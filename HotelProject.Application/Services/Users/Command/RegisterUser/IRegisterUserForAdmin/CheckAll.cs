using static HotelProject.Common.Validation_Pattern.Handler;

namespace HotelProject.Application.Services.Users.Command.RegisterUser.IRegisterUserForAdmin
{
    public class CheckAll
    {
        private string name, mobile, phone, email, password, repassword;
        ValidateHandler Name, Phone, Mobile, Email, Password;
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
            Name.ValidateRequest();
            if(Name.status == false)
            {
                message = Name.message;
                return false;
            }
            if (Mobile.status == false)
            {
                message = Mobile.message;
                return false;
            }
            if (Phone.status == false)
            {
                message = Phone.message;
                return false;
            }
            if (Email.status == false)
            {
                message = Email.message;
                return false;
            }
            if (Password.status == false)
            {
                message = Password.message;
                return false;
            }
            return status;
        }
    }
}
