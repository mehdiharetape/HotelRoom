using HotelProject.Application.Services.Comments.Command;
using HotelProject.Application.Services.Comments.Query;
using HotelProject.Application.Services.Galleries.Command;
using HotelProject.Application.Services.Galleries.Query;
using HotelProject.Application.Services.Reservations.Command;
using HotelProject.Application.Services.Reservations.Queries;
using HotelProject.Application.Services.Roles.Query.GetRoles;
using HotelProject.Application.Services.Rooms.Command.AddNewRoom;
using HotelProject.Application.Services.Rooms.Command.DeleteRoom;
using HotelProject.Application.Services.Rooms.Command.EditRoom;
using HotelProject.Application.Services.Rooms.Query.GetRoomDetails;
using HotelProject.Application.Services.Rooms.Query.GetRoomsForSite;
using HotelProject.Application.Services.Rooms.Query.GetRoomsList;
using HotelProject.Application.Services.Users.Command.DeleteUser;
using HotelProject.Application.Services.Users.Command.EditUser;
using HotelProject.Application.Services.Users.Command.RegisterUser.IRegisterUserForAdmin;
using HotelProject.Application.Services.Users.Query.GetUserDetails;
using HotelProject.Application.Services.Users.Query.GetUsersList;
using HotelProject.Application.Services.Users.Query.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Application.Facade
{
    public interface IFacadePattern
    {
        //Admin services
        RegisterUserForAdminService RegisterUserForAdmin { get; }
        IGetRolesServices GetRolesServices { get; }
        IGetUsersListService GetUsersListService { get; }
        IEditUserService EditUserService { get; }
        IDeleteUserService DeleteUserService { get; }
        IAddRoomService AddRoomService { get; }
        IGetRoomsListService GetRoomsListService { get; }
        IEditRoomService EditRoomService { get; }
        IDeleteRoomService DeleteRoomService { get; }
        IAddGalleryImageService AddGalleryImageService { get; }
        IGetGalleryImageService GetGalleryImageService { get; }
        IRemoveGalleryImageService RemoveGalleryImageService { get; }
        IEditDisplayImageService EditDisplayImageService { get; }
        IGetCommentsForAdminService GetCommentsForAdminService { get; }
        IDeleteCommentService DeleteCommentService { get; }
        IGetReservesForAdmin GetReservesForAdmin { get; }
        ICancelReservationService CancelReservationService { get; }

        //Site services
        IGetRoomsForSiteService GetRoomsForSiteService { get; }
        IGetGalleryForMainPage GetGalleryForMainPage { get; }
        IGetRoomDetailService GetRoomDetailService { get; }
        ILoginUserService LoginUserService { get; }
        IAddNewCommentService AddNewCommentService { get; }
        IGetCommentService GetCommentService { get; }
        IReserveForUserService ReserveForUserService { get; }
        IGetUserInfo GetUserInfo { get; }
        ICheckFinishedReservation CheckFinishedReservation { get; }
        IGetReservsForUser GetReservsForUser { get; }
        IEditUserForUser EditUserForUser { get; }
    }
}
