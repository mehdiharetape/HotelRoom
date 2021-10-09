using HotelProject.Application.IDataBase_Context;
using HotelProject.Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Application.Services.Galleries.Query
{
    public interface IGetGalleryForMainPage
    {
        ResultDTO<List<ResultGalleryDTO>> GetGallery(int status);
    }
    public class GetGalleryForMainPage : IGetGalleryForMainPage
    {
        private readonly IDataBaseContext _context;
        public GetGalleryForMainPage(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO<List<ResultGalleryDTO>> GetGallery(int status)
        {
            // 0 => get 4 images ----- 1 => get all images
            if (status == 0)
            {
                var images = _context.Galleries.Take(4).OrderByDescending(r => r.Id)
                    .Where(r => r.IsShow == true).Select(r => new ResultGalleryDTO
                    {
                        Id = r.Id,
                        ImageSrc = r.ImageSrc,
                        IsShow = r.IsShow
                    }).ToList();
                return new ResultDTO<List<ResultGalleryDTO>>
                {
                    Data = images,
                    IsSuccess = true,
                    Message = ""
                };
            }
            else if(status == 1)
            {
                var images = _context.Galleries.OrderByDescending(r => r.Id)
                    .Where(r => r.IsShow == true).Select(r => new ResultGalleryDTO
                    {
                        Id = r.Id,
                        ImageSrc = r.ImageSrc,
                        IsShow = r.IsShow
                    }).ToList();
                return new ResultDTO<List<ResultGalleryDTO>>
                {
                    Data = images,
                    IsSuccess = true,
                    Message = ""
                };
            }
            else
            {
                return new ResultDTO<List<ResultGalleryDTO>>
                {
                    Data = { },
                    IsSuccess = false,
                    Message = "error"
                };
            }
        }
    }
    public class ResultGalleryDTO
    {
        public long Id { get; set; }
        public string ImageSrc { get; set; }
        public bool IsShow { get; set; }
    }
}
