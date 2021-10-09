using HotelProject.Application.IDataBase_Context;
using HotelProject.Common.Result;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Application.Services.Galleries.Command
{
    public interface IRemoveGalleryImageService
    {
        ResultDTO RemoveImage(long Id);
    }

    public class RemoveGalleryImageService : IRemoveGalleryImageService
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public RemoveGalleryImageService(IDataBaseContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public ResultDTO RemoveImage(long Id)
        {
            var image = _context.Galleries.Find(Id);
            if(image == null)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "عکس یافت نشد"
                };
            }
            DeleteImage(image.ImageSrc);
            _context.Galleries.Remove(image);
            _context.SaveChanges();

            return new ResultDTO
            {
                IsSuccess = true,
                Message = "عکس با موفقیت حذف شد"
            };
        }

        //Delete
        public void DeleteImage(string imagePath)
        {
            if(imagePath != null)
            {
                string imgDir = Path.Combine(_environment.WebRootPath, imagePath);
                if (File.Exists(imgDir))
                {
                    File.Delete(imgDir);
                }
            }
        }
    }
}
