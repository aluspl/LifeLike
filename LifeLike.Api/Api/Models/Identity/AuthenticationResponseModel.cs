#region Usings

#endregion

namespace Api.Models.Identity
{
    public class AuthenticationResponseModel
    {
        public string RefreshToken { get; set; }

        public string Token { get; set; }
    }
}
