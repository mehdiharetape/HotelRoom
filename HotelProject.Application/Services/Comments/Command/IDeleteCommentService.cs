using HotelProject.Application.IDataBase_Context;
using HotelProject.Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Application.Services.Comments.Command
{
    public interface IDeleteCommentService
    {
        ResultDTO DeleteComment(long Id);
    }
    public class DeleteCommentService : IDeleteCommentService
    {
        private readonly IDataBaseContext _context;
        public DeleteCommentService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO DeleteComment(long Id)
        {
            var comment = _context.Comments.Find(Id);
            if(comment == null)
            {
                return new ResultDTO
                {
                     IsSuccess = false,
                     Message = "نظری یافت نشد"
                };
            }
            _context.Comments.Remove(comment);
            _context.SaveChanges();
            return new ResultDTO
            {
                IsSuccess = true,
                Message = "کامنت حذف شد"
            };
        }
    }
}
