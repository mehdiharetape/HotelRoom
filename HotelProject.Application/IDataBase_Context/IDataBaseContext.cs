using HotelProject.Domain.Entities.Cooments;
using HotelProject.Domain.Entities.Reserves;
using HotelProject.Domain.Entities.Rooms;
using HotelProject.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HotelProject.Application.IDataBase_Context
{
    public interface IDataBaseContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Room> Rooms { get; set; }
        DbSet<RoomDetails> RoomDetails { get; set; }
        DbSet<Reservation> Reservations { get; set; }
        DbSet<WithPersons> WithPersons { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<UserInRole> UserInRoles { get; set; }
        DbSet<Gallery> Galleries { get; set; }
        DbSet<Comment> Comments { get; set; }
        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
