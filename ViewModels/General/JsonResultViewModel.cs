using Dtx.Enums;

namespace ViewModels.General
{
    public class JsonResultViewModel
    {
        public bool is_successful { get; set; } = false;

        public string error_message { get; set; } = string.Empty;

        public object response { get; set; } = string.Empty;

        public ResponseErrorType error_type { get; set; } = ResponseErrorType.NoError;
    }
}