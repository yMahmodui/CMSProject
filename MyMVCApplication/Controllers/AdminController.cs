using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using DAL;
using Dtx.Time;
using ViewModels.AdminPanel;
using ViewModels.General;

namespace MyMVCApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly UnitOfWork UnitOfWork = new UnitOfWork();

        public JsonResult GetRegisteredUser([FromBody] GetRegisteredUserViewModel.Request request)
        {
            var response = new JsonResultViewModel();
               
            try
            {
                if (User.Identity.IsAuthenticated
                    && UnitOfWork.UserRepository.FindUserByEmail(User.Identity.Name).Role.RoleId != 1)
                    return Json(response);

                var users = UnitOfWork.UserRepository.GetUsers().Select(user => new UserViewModel()
                    { email = user.Email, register_date = user.RegisterDate.ToMilliseconds() }).ToList();

                response.response = new GetRegisteredUserViewModel.Response()
                {
                    users = users
                };
                response.is_successful = true;
            }
            catch (Exception)
            {
                // log it
            }

            return Json(response);
        }
    }
}