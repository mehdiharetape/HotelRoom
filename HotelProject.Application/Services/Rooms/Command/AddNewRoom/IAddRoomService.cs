using HotelProject.Application.IDataBase_Context;
using HotelProject.Common.Result;
using HotelProject.Domain.Entities.Rooms;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Application.Services.Rooms.Command.AddNewRoom
{
    public interface IAddRoomService
    {
        ResultDTO AddRoom(AddNewRoom_DTO request);
    }
    public class AddRoomService : IAddRoomService
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public AddRoomService(IDataBaseContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public ResultDTO AddRoom(AddNewRoom_DTO request)
        {
            try
            {
                var imageFile = Upload(request.Image);
                Room room = new Room()
                {
                    Code = request.Code,
                    Name = request.Name,
                    BedsCount = request.BedsCount,
                    CostPerNight = request.CostPerNight,
                    Dimension = request.Dimension,
                    ImageSrc = imageFile.ImageSrc,
                };

                List<RoomDetails> describe = new List<RoomDetails>();
                RoomDetails details = new RoomDetails()
                {
                    Room = room,
                    RoomId = room.Id,
                    Detail = request.RoomDecribe
                };
                describe.Add(details);
                room.RoomDetails = describe;

                _context.Rooms.Add(room);
                foreach(var i in describe)
                {
                    _context.RoomDetails.Add(i);
                }

                _context.SaveChanges();
                return new ResultDTO
                {
                    IsSuccess = true,
                    Message = "اتاق با موفقیت اضافه شد"
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

        private UploadResult Upload(IFormFile image)
        {
            if(image != null)
            {
                if(image == null || image.Length == 0)
                {
                    return new UploadResult
                    {
                        status = false,
                        ImageSrc = ""
                    };
                }
                string imageSrc = $@"Images\Rooms\";
                var rootFilePath = Path.Combine(_environment.WebRootPath, imageSrc);
                if (!Directory.Exists(rootFilePath))
                {
                    Directory.CreateDirectory(rootFilePath);
                }

                string fileName = DateTime.Now.Ticks.ToString() + image.FileName;
                var filePath = Path.Combine(rootFilePath, fileName);
                using(var stream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }

                return new UploadResult
                {
                    status = true,
                    ImageSrc = imageSrc + fileName
                };
            }
            return null;
        }
    }

    public class AddNewRoom_DTO
    {
        public long Id { get; set; }
        public long Code { get; set; }
        public string Name { get; set; }
        public string BedsCount { get; set; }
        public long CostPerNight { get; set; }
        public IFormFile Image { get; set; }
        public string Dimension { get; set; }
        public string RoomDecribe { get; set; }
    }

    public class UploadResult
    {
        public bool status { get; set; }
        public string ImageSrc { get; set; }
    }
}
