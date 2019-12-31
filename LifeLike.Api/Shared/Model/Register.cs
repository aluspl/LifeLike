namespace LifeLike.Shared.Model
{
    public class Register : BaseModel
    {
        public string Username { get; set; }  
   
        public string Password { get; set; }  
       
        public string Email { get; set; }
        
        public string Firstname { get; set; }
        
        public string Lastname { get; set; }
        
        public string Info { get; set; }
    }
}