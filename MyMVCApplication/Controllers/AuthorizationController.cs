using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using DAL;
using Microsoft.IdentityModel.Tokens;
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

                if(user == null)
                    return Json(new JsonResultViewModel()
                    {
                        error_message = "User not found",
                        error_type = Dtx.Enums.ResponseErrorType.UserNotFound
                    });

                if(user.Password != Dtx.Security.Hashing.GetSha1(request.hash + "ConstValue"))
                    return Json(new JsonResultViewModel()
                    {
                        error_message = "Wrong password",
                        error_type = Dtx.Enums.ResponseErrorType.WrongPassword
                    });

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SecurityKey"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenOption = new JwtSecurityToken(
                    issuer: "https://localhost:44384",
                    claims: new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, request.email)
                    },
                    expires: DateTime.Now.AddDays(30),
                    signingCredentials: signinCredentials
                );
                var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOption);

                response.response = new LoginViewModel.Response()
                {
                    access_token = accessToken
                };
                response.is_successful = true;
            }
            catch (Exception)
            {
                // log it
            }

            return Json(response);
        }

     
        public JsonResult Register([FromBody] RegisterViewModel.Request request)
        {
            var response = new JsonResultViewModel();

            try
            {
                UnitOfWork.UserRepository.AddUser(new User()
                {
                    Email = request.email,
                    Password = Dtx.Security.Hashing.GetSha1(request.hash + "ConstValue"),
                    RegisterDate = DateTime.Now,
                    RoleId = 1
                });

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SecurityKey"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenOption = new JwtSecurityToken(
                    issuer: "https://localhost:44384",
                    claims: new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, request.email)
                    },
                    expires: DateTime.Now.AddDays(30),
                    signingCredentials: signinCredentials
                );
                var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOption);

                UnitOfWork.Save();

                response.response = new RegisterViewModel.Response()
                {
                    access_token = accessToken
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