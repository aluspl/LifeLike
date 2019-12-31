using System.ComponentModel.DataAnnotations;

namespace LifeLike.Shared.Model
{
    public class Login : BaseModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Info { get;  set; }
        public string Token { get; set; }
        public string Id { get; set; }
        public string Email { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
    }
}