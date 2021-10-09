using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Common.Result
{
    public class ResultDTO
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    public class ResultDTO<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
