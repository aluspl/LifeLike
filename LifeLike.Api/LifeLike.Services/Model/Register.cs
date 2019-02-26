using System.ComponentModel.DataAnnotations;

namespace LifeLike.Services.ViewModel
{
    public class Register : BaseViewModel
    {
        [Required, MaxLength(256)] 
        public string Username { get; set; }  
   
        [Required, DataType(DataType.Password)] 
        public string Password { get; set; }  
       
        [DataType(DataType.EmailAddress), MaxLength(256)] 
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Info { get; set; }
    }
}