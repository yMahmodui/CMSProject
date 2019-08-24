using System.Collections.Generic;
using ViewModels.General;

namespace ViewModels.AdminPanel
{
    public class GetRegisteredUsersViewModel
    {
        public class Request
        {
            public string token { get; set; }
        }

        public class Response
        {
            public List<UserViewModel> users { get; set; }
        }
    }
}