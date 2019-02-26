using Microsoft.AspNetCore.Identity;

namespace LifeLike.Data.Models
{
    public class User : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

    }
}