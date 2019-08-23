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
        }
    }
}