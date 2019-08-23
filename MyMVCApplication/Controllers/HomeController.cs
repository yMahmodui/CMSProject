using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using ViewModels.General;
using ViewModels.Home;

namespace MyMVCApp.Controllers
{
    public class HomeController : Controller
    {
        public JsonResult GetPost([FromBody] GetPostViewModel.Request request)
        {
            var response = new JsonResultViewModel();

            var limit = 4;
            var passage = "Test Message";

            try
            {
                if (User.Identity.IsAuthenticated)
                    response.response = new GetPostViewModel.Response()
                    {
                        passage = passage,
                        is_complete_passage = true
                    };
                else
                    response.response = new GetPostViewModel.Response()
                    {
                        passage = passage.Substring(0, limit),
                        is_complete_passage = false
                    };
                response.is_successful = true;
            }
            catch (Exception)
            {
                //log it
            }

            return Json(response);
        }
    }
}
