namespace Dtx.Enums
{
    public enum ResponseErrorType
    {
        NoError,

        //Login Enums
        UserNotFound,
        WrongPassword,

        //Register Enums
        InvalidEmail,
        ShortPassword
    }
}