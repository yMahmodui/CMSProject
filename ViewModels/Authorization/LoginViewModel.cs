namespace ViewModels.Authorization
{
    public class LoginViewModel
    {
        public class Request
        {
            public string email { get; set; }

            public string hash { get; set; }
        }

        public class Response
        {
            public string access_token { get; set; }
        }
    }
}