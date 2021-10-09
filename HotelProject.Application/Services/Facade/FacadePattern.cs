using HotelProject.Application.Facade;
using HotelProject.Application.IDataBase_Context;
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
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Application.Services.Facade
{
    public class FacadePattern : IFacadePattern
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public FacadePattern(IDataBaseContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        //Admin sevices
        private RegisterUserForAdminService _registerUserForAdmin;
        public RegisterUserForAdminService RegisterUserForAdmin
        {
            get
            {
                return _registerUserForAdmin = _registerUserForAdmin ?? new RegisterUserForAdminService(_context);
            }
        }

        private IGetRolesServices _getRoles;
        public IGetRolesServices GetRolesServices
        {
            get
            {
                return _getRoles = _getRoles ?? new GetRolesServices(_context);
            }
        }

        private IGetUsersListService _getUsersList; 
        public IGetUsersListService GetUsersListService
        {
            get
            {
                return _getUsersList = _getUsersList ?? new GetUsersListService(_context);
            }
        }

        private IEditUserService _editUserService;
        public IEditUserService EditUserService
        {
            get
            {
                return _editUserService = _editUserService ?? new EditUserService(_context);
            }
        }

        private IDeleteUserService _deleteUserService;
        public IDeleteUserService DeleteUserService
        {
            get
            {
                return _deleteUserService = _deleteUserService ?? new DeleteUserService(_context);
            }
        }

        private IAddRoomService _addRoomService; 
        public IAddRoomService AddRoomService
        {
            get
            {
                return _addRoomService = _addRoomService ?? new AddRoomService(_context,_environment);
            }
        }

        private IGetRoomsListService _roomsListService;
        public IGetRoomsListService GetRoomsListService
        {
            get
            {
                return _roomsListService = _roomsListService ?? new GetRoomsListService(_context);
            }
        }

        private IEditRoomService _editRoomService;
        public IEditRoomService EditRoomService
        {
            get
            {
                return _editRoomService = _editRoomService ?? new EditRoomService(_context, _environment);
            }
        }

        private IDeleteRoomService _deleteRoom;
        public IDeleteRoomService DeleteRoomService
        {
            get
            {
                return _deleteRoom = _deleteRoom ?? new DeleteRoomService(_context, _environment);
            }
        }

        private IAddGalleryImageService _addGalleryImage;
        public IAddGalleryImageService AddGalleryImageService
        {
            get
            {
                return _addGalleryImage = _addGalleryImage ?? new AddGalleryImageService(_context, _environment);
            }
        }

        private IGetGalleryImageService _galleryImageService;
        public IGetGalleryImageService GetGalleryImageService
        {
            get
            {
                return _galleryImageService = _galleryImageService ?? new GetGalleryImageService(_context);
            }
        }

        private IRemoveGalleryImageService _removeGalleryImage;
        public IRemoveGalleryImageService RemoveGalleryImageService
        {
            get
            {
                return _removeGalleryImage = _removeGalleryImage ?? new RemoveGalleryImageService(_context, _environment);
            }
        }

        private IEditDisplayImageService _editDisplayImage;
        public IEditDisplayImageService EditDisplayImageService
        {
            get
            {
                return _editDisplayImage = _editDisplayImage ?? new EditDisplayImageService(_context);
            }
        }

        private IGetCommentsForAdminService _getCommentsForAdmin;
        public IGetCommentsForAdminService GetCommentsForAdminService
        {
            get
            {
                return _getCommentsForAdmin = _getCommentsForAdmin ?? new GetCommentsForAdminService(_context);
            }
        }

        private IDeleteCommentService _deleteCommentService;
        public IDeleteCommentService DeleteCommentService
        {
            get
            {
                return _deleteCommentService = _deleteCommentService ?? new DeleteCommentService(_context);
            }
        }

        private IGetReservesForAdmin _reservesForAdmin;
        public IGetReservesForAdmin GetReservesForAdmin
        {
            get
            {
                return _reservesForAdmin = _reservesForAdmin ?? new GetReservesForAdmin(_context);
            }
        }

        private ICancelReservationService _cancelReservation;
        public ICancelReservationService CancelReservationService
        {
            get
            {
                return _cancelReservation = _cancelReservation ?? new CancelReservationService(_context);
            }
        }

        //Site services
        private IGetRoomsForSiteService _roomsForSiteService;
        public IGetRoomsForSiteService GetRoomsForSiteService
        {
            get
            {
                return _roomsForSiteService = _roomsForSiteService ?? new GetRoomsForSiteService(_context);
            }
        }
        private IGetGalleryForMainPage _galleryForMainPage;
        public IGetGalleryForMainPage GetGalleryForMainPage
        {
            get
            {
                return _galleryForMainPage = _galleryForMainPage ?? new GetGalleryForMainPage(_context);
            }
        }

        private IGetRoomDetailService _getRoomDetail;
        public IGetRoomDetailService GetRoomDetailService
        {
            get
            {
                return _getRoomDetail = _getRoomDetail ?? new GetRoomDetailService(_context);
            }
        }

        private ILoginUserService _loginUserService;
        public ILoginUserService LoginUserService
        {
            get
            {
                return _loginUserService = _loginUserService ?? new LoginUserService(_context);
            }
        }

        private IAddNewCommentService _addNewComment;
        public IAddNewCommentService AddNewCommentService
        {
            get
            {
                return _addNewComment = _addNewComment ?? new AddNewCommentService(_context);
            }
        }

        private IGetCommentService _getCommentService;
        public IGetCommentService GetCommentService
        {
            get
            {
                return _getCommentService = _getCommentService ?? new GetCommentService(_context);
            }
        }

        private IReserveForUserService _reserveForUser;
        public IReserveForUserService ReserveForUserService
        {
            get
            {
                return _reserveForUser = _reserveForUser ?? new ReserveForUserService(_context);
            }
        }

        private IGetUserInfo _getUserInfo;
        public IGetUserInfo GetUserInfo
        {
            get
            {
                return _getUserInfo = _getUserInfo ?? new GetUserInfo(_context);
            }
        }

        private ICheckFinishedReservation _checkFinished;
        public ICheckFinishedReservation CheckFinishedReservation
        {
            get
            {
                return _checkFinished = _checkFinished ?? new CheckFinishedReservation(_context);
            }
        }

        private IGetReservsForUser _getReservsForUser;
        public IGetReservsForUser GetReservsForUser
        {
            get
            {
                return _getReservsForUser = _getReservsForUser ?? new GetReservsForUser(_context);
            }
        }

        private IEditUserForUser _editUserForUser;
        public IEditUserForUser EditUserForUser
        {
            get
            {
                return _editUserForUser = _editUserForUser ?? new EditUserForUser(_context);
            }
        }
    }
}
