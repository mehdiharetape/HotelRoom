using HotelProject.Application.IDataBase_Context;
using HotelProject.Common.Result;
using HotelProject.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Application.Services.Roles.Query.GetRoles
{
    public interface IGetRolesServices
    {
        ResultDTO<List<RolesDTO>> GetRoles();
    }

    public class GetRolesServices : IGetRolesServices
    {
        private readonly IDataBaseContext _context;
        public GetRolesServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO<List<RolesDTO>> GetRoles()
        {
            var roles = _context.Roles.ToList().Select(r => new RolesDTO
            {
                Id = r.Id,
                Name = r.Name
            }).ToList();
            return new ResultDTO<List<RolesDTO>>()
            {
                Data = roles,
                IsSuccess = true,
                Message = ""
            };
        }
    }

    public class RolesDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
