using HotelProject.Application.IDataBase_Context;
using HotelProject.Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Application.Services.Galleries.Command
{
    public interface IEditDisplayImageService
    {
        ResultDTO EditDisplay(long Id, bool show);
    }

    public class EditDisplayImageService : IEditDisplayImageService
    {
        private readonly IDataBaseContext _context;
        public EditDisplayImageService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO EditDisplay(long Id, bool show)
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
            image.IsShow = show;
            _context.SaveChanges();
            return new ResultDTO
            {
                IsSuccess = true,
                Message = "نمایش عکس تغییر کرد",
            };
        }
    }
}
