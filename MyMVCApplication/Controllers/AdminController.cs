using System;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using DAL;
using Dtx.Enums;
using Dtx.Security;
using ViewModels.AdminPanel;
using ViewModels.General;

namespace MyMVCApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly UnitOfWork UnitOfWork = new UnitOfWork();

        public JsonResult GetRegisteredUsers([FromBody] GetRegisteredUsersViewModel.Request request)
        {
            var response = new JsonResultViewModel();

            try
            {
                string email;
                if (!JWT.ValidateToken(request.token ?? Request?.Headers?.Get("token"), out email) || UnitOfWork
                        .UserRepository.FindUserByEmail(email).Role.Permissions.All(permission =>
                            permission.PermissionId != (int) Permission.GetUsers))
                    return Json(new JsonResultViewModel
                    {
                        error_message = "Permission Denied",
                        error_type = ResponseErrorType.PermissionDenied
                    });

                var users = UnitOfWork.UserRepository.GetUsers().Select(user => new UserViewModel
                        {id = user.UserId, email = user.Email, register_date = user.RegisterDate})
                    .ToList();

                response.data = new GetRegisteredUsersViewModel.Response
                {
                    users = users
                };
                response.is_successful = true;
            }
            catch (Exception ex)
            {
                response = new JsonResultViewModel
                {
                    error_message = ex.Message,
                    error_type = ResponseErrorType.UnexpectedError
                };
            }

            return Json(response);
        }
    }
}