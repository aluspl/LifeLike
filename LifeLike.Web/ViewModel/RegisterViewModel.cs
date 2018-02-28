using System.ComponentModel.DataAnnotations;

namespace LifeLike.Web.ViewModel
{
    public class RegisterViewModel
    {
        [Required, MaxLength(256)] 
        public string Login { get; set; }  
   
        [Required, DataType(DataType.Password)] 
        public string Password { get; set; }  
   
        [DataType(DataType.Password), Compare(nameof(Password))] 
        public string ConfirmPassword { get; set; }
        [DataType(DataType.EmailAddress), MaxLength(256)] 
        public string Email { get; set; }
        public string Info { get; set; }
    }
}