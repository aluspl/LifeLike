namespace LifeLike.Services.ViewModel
{
    public class Login : BaseViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string Info { get;  set; }
    }
}