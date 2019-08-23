using System.Collections.Generic;
using ViewModels.General;

namespace ViewModels.AdminPanel
{
    public class GetRegisteredUserViewModel
    {
        public class Request
        {
        }

        public class Response
        {
            public List<UserViewModel> users { get; set; }
        }
    }
}