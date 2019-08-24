using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using DAL;
using Dtx.Enums;
using Dtx.Security;
using Models;
using ViewModels.Authorization;
using ViewModels.General;

namespace MyMVCApp.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly UnitOfWork UnitOfWork = new UnitOfWork();

        public JsonResult Login([FromBody] LoginViewModel.Request request)
        {
            var response = new JsonResultViewModel();

            try
            {
                var user = UnitOfWork.UserRepository.FindUserByEmail(request.email);

                if (user == null)
                    return Json(new JsonResultViewModel
                    {
                        error_message = "User not found",
                        error_type = ResponseErrorType.UserNotFound
                    });

                if (user.Password != Hashing.GetSha1(request.hash.ToLower() + "ConstValue"))
                    return Json(new JsonResultViewModel
                    {
                        error_message = "Wrong password",
                        error_type = ResponseErrorType.WrongPassword
                    });

                var accessToken = JWT.GetToken(request.email);

                response.data = new LoginViewModel.Response
                {
                    access_token = accessToken,
                    email = user.Email,
                    role_id = user.RoleId
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


        public JsonResult Register([FromBody] RegisterViewModel.Request request)
        {
            var response = new JsonResultViewModel();

            try
            {
                if (request.hash.Length < 8)
                    return Json(new JsonResultViewModel
                    {
                        error_message = "Weak password",
                        error_type = ResponseErrorType.ShortPassword
                    });

                var emailAddressAttribute = new EmailAddressAttribute();
                if (!emailAddressAttribute.IsValid(request.email))
                    return Json(new JsonResultViewModel
                    {
                        error_message = "Invalid email",
                        error_type = ResponseErrorType.InvalidEmail
                    });

                if (UnitOfWork.UserRepository.GetUsers().Any(user => user.Email == request.email))
                    return Json(new JsonResultViewModel
                    {
                        error_message = "Duplicate email",
                        error_type = ResponseErrorType.DuplicateEmail
                    });

                UnitOfWork.UserRepository.AddUser(new User
                {
                    Email = request.email,
                    Password = Hashing.GetSha1(request.hash.ToLower() + "ConstValue"),
                    RegisterDate = DateTime.Now.ToString("MM/dd/yyyy HH:mm"),
                    RoleId = 2
                });

                var accessToken = JWT.GetToken(request.email);

                if (!request.email.Equals("test_register@localhost.com"))
                    UnitOfWork.Save();

                response.data = new RegisterViewModel.Response
                {
                    access_token = accessToken,
                    email = request.email,
                    role_id = 2
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