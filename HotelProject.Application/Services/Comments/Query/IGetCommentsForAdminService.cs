using HotelProject.Application.IDataBase_Context;
using HotelProject.Common.Result;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Application.Services.Comments.Query
{
    public interface IGetCommentsForAdminService
    {
        ResultDTO<List<GetCommentsForAdmin_DTO>> GetComments(string SearchKey, int skip, int take);
        int GetCommentscount();
    }

    public class GetCommentsForAdminService : IGetCommentsForAdminService
    {
        private readonly IDataBaseContext _context;
        public GetCommentsForAdminService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO<List<GetCommentsForAdmin_DTO>> GetComments(string SearchKey, int skip, int take)
        {
            var comments = _context.Comments.OrderByDescending(c => c.Id).Skip(skip).Take(take).
                Include(c => c.Room).AsQueryable();

            if (!string.IsNullOrWhiteSpace(SearchKey))
            {
                comments = _context.Comments.OrderByDescending(c => c.Id).Skip(skip).Take(take).Include(c => c.Room)
                    .Where(c => c.Room.Name.Contains(SearchKey) || c.UserName.Contains(SearchKey)
                           || c.Email.Contains(SearchKey) || c.CommentText.Contains(SearchKey))
                    .AsQueryable();
            }

            return new ResultDTO<List<GetCommentsForAdmin_DTO>>()
            {
                Data = comments.Select(c => new GetCommentsForAdmin_DTO 
                { 
                    Id = c.Id,
                    RoomId = c.RoomId,
                    RoomName = c.Room.Name,
                    RoomCode = c.Room.Code,
                    CommentText = c.CommentText,
                    Email = c.Email,
                    UserName = c.UserName,
                    InsertTime = c.InsertTime
                }).ToList(),
                IsSuccess = true,
                Message = ""
            };
        }
        public int GetCommentscount()
        {
            return _context.Comments.Count();
        }
    }

    public class GetCommentsForAdmin_DTO
    {
        public long Id { get; set; }
        public string CommentText { get; set; }
        public long RoomId { get; set; }
        public string RoomName { get; set; }
        public long RoomCode { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime InsertTime { get; set; }
    }
}
