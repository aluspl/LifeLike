namespace LifeLike.Common.Enums
{
    public enum ErrorType
    {
        Unexpected,
        Unauthorized,
        TokenInvalid,
        UserDoesNotExist,
        UserCantBeAddedToRole,
        UserNotCreated,
        UserResetPasswordFailed,
        TokenEmpty,
        InvalidUsernameOrPassword,
        UserWithGivenEmailAlreadyExists,
        UserEmailConfirmFailed,
        UserEmailNotConfirmed,
        ErrorSendingEmail,
        ValidationError,
    }
}
