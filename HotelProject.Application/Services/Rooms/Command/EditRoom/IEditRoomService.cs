using HotelProject.Application.IDataBase_Context;
using HotelProject.Application.Services.Rooms.Query.GetRoomsList;
using HotelProject.Common.Result;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Application.Services.Rooms.Command.EditRoom
{
    public interface IEditRoomService
    {
        ResultDTO EditRoom(RequestEditRoom_DTO request);
    }

    public class EditRoomService : IEditRoomService
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public EditRoomService(IDataBaseContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public ResultDTO EditRoom(RequestEditRoom_DTO request)
        {
            try
            {
                var room = _context.Rooms.Find(request.Id);
                if (room == null)
                {
                    return new ResultDTO
                    {
                        IsSuccess = false,
                        Message = "اتاق یافت نشد ..."
                    };
                }
                room.Code = request.Code;
                room.Name = request.Name;
                room.BedsCount = request.BedCount;
                room.CostPerNight = request.CostePerNight;
                room.Dimension = request.Dimension;

                var details = _context.RoomDetails.Where(r => r.RoomId == request.Id).ToList();
                foreach (var i in details)
                {
                    i.Detail = request.RoomsDetails;
                }

                string imageSrc = null;


                if (request.ImageFile != null)
                {
                    imageSrc = UploadNewImage(request.ImageFile, room.Id);
                    room.ImageSrc = imageSrc;
                }
                _context.SaveChanges();

                return new ResultDTO
                {
                    IsSuccess = true,
                    Message = "اتاق ویرایش شد"
                };
            }
            catch(Exception e)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "خطا رخ داد"
                };
            }
        }

        //Upload New Image
        private string UploadNewImage(IFormFile ImageFile, long RoomId)
        {
            if (ImageFile != null && RoomId != 0)
            {
                RemoveImage(RoomId);
                string ImageFolder = $@"Images\Rooms\";
                string uploadRootFolder = Path.Combine(_environment.WebRootPath, ImageFolder);
                if (!Directory.Exists(uploadRootFolder))
                {
                    Directory.CreateDirectory(uploadRootFolder);
                }

                if (ImageFile == null || ImageFile.Length == 0)
                {
                    return "";
                }

                string ImageFileName = DateTime.Now.Ticks.ToString() + ImageFile.FileName;
                var filePath = Path.Combine(uploadRootFolder, ImageFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    ImageFile.CopyTo(fileStream);
                }

                return ImageFolder + ImageFileName;
            }
            return null;
        }

        //Remove Image
        private void RemoveImage(long RoomId)
        {
            var room = _context.Rooms.Where(p => p.Id == RoomId).FirstOrDefault();
            string imgDir = Path.Combine(_environment.WebRootPath, room.ImageSrc);

            if (File.Exists(imgDir))
                File.Delete(imgDir);
        }
    }


    public class RequestEditRoom_DTO
    {
        public long Id { get; set; }
        public long Code { get; set; }
        public string Name { get; set; }
        public string BedCount { get; set; }
        public long CostePerNight { get; set; }
        public string Dimension { get; set; }
        public string RoomsDetails { get; set; }
        public IFormFile ImageFile { get; set; }

    }
}
