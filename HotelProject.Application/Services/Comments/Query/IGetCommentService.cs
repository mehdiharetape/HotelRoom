using HotelProject.Application.IDataBase_Context;
using HotelProject.Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Application.Services.Comments.Query
{
    public interface IGetCommentService
    {
        ResultDTO<List<GetCommentResultDTO>> GetComment(long Id);
    }

    public class GetCommentService : IGetCommentService
    {
        private readonly IDataBaseContext _context;
        public GetCommentService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO<List<GetCommentResultDTO>> GetComment(long Id)
        {
            var comments = _context.Comments.OrderByDescending(c => c.Id).Where(c => c.RoomId == Id)
                .Select(c => new GetCommentResultDTO
                {
                    InsertTime = c.InsertTime,
                    CommentTxt = c.CommentText,
                    Name = c.UserName
                }).ToList();
            return new ResultDTO<List<GetCommentResultDTO>>()
            {
                Data = comments,
                IsSuccess = true,
                Message = ""
            };
        }
    }

    public class GetCommentResultDTO
    {
        public string CommentTxt { get; set; }
        public string Name { get; set; }
        public DateTime InsertTime { get; set; }
    }
}
