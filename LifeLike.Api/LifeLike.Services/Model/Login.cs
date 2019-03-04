using System.ComponentModel.DataAnnotations;

namespace LifeLike.Services.ViewModel
{
    public class Login : BaseViewModel
    {
        [Required, MaxLength(256)]
        public string UserName { get; set; }
        [Required, MaxLength(256)]
        public string Password { get; set; }
        public string Info { get;  set; }
        public string Token { get; set; }
        public string Id { get; set; }
        public string Email { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
    }
}