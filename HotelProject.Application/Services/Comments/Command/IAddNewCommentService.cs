
using HotelProject.Application.IDataBase_Context;
using HotelProject.Common.Result;
using HotelProject.Domain.Entities.Cooments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HotelProject.Application.Services.Comments.Command
{
    public interface IAddNewCommentService
    {
        ResultDTO AddComment(ReqestAddCommentDTO reqest);
    }

    public class AddNewCommentService : IAddNewCommentService
    {
        private readonly IDataBaseContext _context;
        public AddNewCommentService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO AddComment(ReqestAddCommentDTO reqest)
        {
            if (string.IsNullOrEmpty(reqest.Email) || string.IsNullOrEmpty(reqest.Name)
                || string.IsNullOrEmpty(reqest.CommentTxt))
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "لطفا تمام موارد را وارد کنید"
                };
            }
            string emailRegex = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[A-Z0-9.-]+\.[A-Z]{2,}$";
            var match = Regex.Match(reqest.Email, emailRegex, RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "لطفا آدرس ایمیل را به درستی وارد کنید"
                };
            }
            Comment comment = new Comment()
            {
                RoomId = reqest.Id,
                CommentText = reqest.CommentTxt,
                Email = reqest.Email,
                UserName = reqest.Name,
                InsertTime = DateTime.Now,
            };
            _context.Comments.Add(comment);
            _context.SaveChanges();

            return new ResultDTO
            {
                IsSuccess = true,
                Message = "نظر شما اضافه شد - برای مشاهده یکبار صفحه را رفرش کنید"
            };
        }
    }

    public class ReqestAddCommentDTO
    {
        public long Id { get; set; }
        public string CommentTxt { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
