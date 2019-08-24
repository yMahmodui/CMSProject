namespace ViewModels.Authorization
{
    public class RegisterViewModel
    {
        public class Request
        {
            public string email { get; set; }

            public string hash { get; set; }
        }

        public class Response
        {
            public int role_id { get; set; }

            public string email { get; set; }

            public string access_token { get; set; }
        }
    }
}