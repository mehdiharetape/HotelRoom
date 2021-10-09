using HotelProject.Application.IDataBase_Context;
using HotelProject.Common.UserRoles;
using HotelProject.Domain.Entities.Cooments;
using HotelProject.Domain.Entities.Reserves;
using HotelProject.Domain.Entities.Rooms;
using HotelProject.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Persistance.Context
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomDetails> RoomDetails { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<WithPersons> WithPersons { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserInRole> UserInRoles { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
        } 
        public void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = nameof(UserRole.Admin) });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 2, Name = nameof(UserRole.User) });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 3, Name = nameof(UserRole.Operator) });
        }
    }
}
