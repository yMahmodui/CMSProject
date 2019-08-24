namespace Dtx.Enums
{
    public enum ResponseErrorType
    {
        NoError,
        UnexpectedError,
        PermissionDenied,

        //Login Enums
        UserNotFound,
        WrongPassword,

        //Register Enums
        InvalidEmail,
        ShortPassword,
        DuplicateEmail
    }
}