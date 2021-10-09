using HotelProject.Application.IDataBase_Context;
using HotelProject.Common.Result;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.Domain.Entities.Rooms;

namespace HotelProject.Application.Services.Galleries.Command
{
    public interface IAddGalleryImageService
    {
        ResultDTO AddImage(IFormFile imageFile, bool Show);
    }

    public class AddGalleryImageService : IAddGalleryImageService
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public AddGalleryImageService(IDataBaseContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public ResultDTO AddImage(IFormFile imageFile, bool Show)
        {
            if(imageFile != null)
            {
                string imagePath = $@"Images\GalleryImages\";
                var rootFilePath = Path.Combine(_environment.WebRootPath, imagePath);
                if (!Directory.Exists(rootFilePath))
                {
                    Directory.CreateDirectory(rootFilePath);
                }
                if(imageFile.Length == 0 || imageFile == null)
                {
                    return new ResultDTO
                    {
                        IsSuccess = false,
                        Message = "خطا رخ داد ...."
                    };
                }
                string imageFileName = DateTime.Now.Ticks.ToString() + imageFile.FileName;
                var filePath = Path.Combine(rootFilePath, imageFileName);
                using(var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                Gallery gallery = new Gallery()
                {
                    ImageSrc = imagePath + imageFileName,
                    IsShow = Show
                };
                _context.Galleries.Add(gallery);
                _context.SaveChanges();
                return new ResultDTO
                {
                    IsSuccess = true,
                    Message = "تصویر با موفقیت آپلود شد ...."
                };
            }
            else
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "عکس آپلود نشد ... "
                };
            }
        }
    }
}
