using HotelProject.Application.IDataBase_Context;
using HotelProject.Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Application.Services.Galleries.Query
{
    public interface IGetGalleryImageService
    {
        ResultDTO<List<GalleryListDTO>> GetGallery(int skip, int take);
        int GetGalleryCount();
    }

    public class GetGalleryImageService : IGetGalleryImageService
    {
        private readonly IDataBaseContext _context;
        public GetGalleryImageService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO<List<GalleryListDTO>> GetGallery(int skip, int take)
        {
            var images = _context.Galleries.OrderByDescending(r => r.Id)
                .ToList().Skip(skip).Take(take)
                .Select(r => new GalleryListDTO
            {
                Id = r.Id,
                ImageSrc = r.ImageSrc,
                IsShow = r.IsShow
            }).ToList();

            return new ResultDTO<List<GalleryListDTO>>()
            {
                Data = images,
                IsSuccess = true,
                Message = ""
            };
        }
        public int GetGalleryCount()
        {
            return _context.Galleries.Count();
        }
    }

    public class GalleryListDTO
    {
        public long Id { get; set; }
        public string ImageSrc { get; set; }
        public bool IsShow { get; set; }
    }
}
