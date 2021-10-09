using HotelProject.Application.IDataBase_Context;
using HotelProject.Common.Result;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Application.Services.Rooms.Command.DeleteRoom
{
    public interface IDeleteRoomService
    {
        ResultDTO Delete(long Id);
    }

    public class DeleteRoomService : IDeleteRoomService
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public DeleteRoomService(IDataBaseContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public ResultDTO Delete(long Id)
        {
            var room = _context.Rooms.Find(Id);
            var details = _context.RoomDetails.Where(d => d.RoomId == Id).FirstOrDefault();
            if(room == null || details == null)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "اتاق یافت نشد"
                };
            }
            DeleteImage(room.ImageSrc);
            _context.Rooms.Remove(room);
            _context.RoomDetails.Remove(details);
            _context.SaveChanges();

            return new ResultDTO
            {
                IsSuccess = true,
                Message = "اتاق حذف شد"
            };
        }

        private void DeleteImage(string imagePath)
        {
            if(imagePath != null)
            {
                string imageDir = Path.Combine(_environment.WebRootPath, imagePath);
                if (File.Exists(imageDir))
                {
                    File.Delete(imageDir);
                }
            }
        }
    }
}
