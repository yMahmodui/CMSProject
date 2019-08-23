namespace ViewModels.Home
{
    public class GetPostViewModel
    {
        public class Request
        {
        }

        public class Response
        {
            public string passage { get; set; }

            public bool is_complete_passage { get; set; }
        }
    }
}