using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MyStore.Models
{
    public class AppUser : IdentityUser
    {
        [Length (minimumLength:5,maximumLength:50,ErrorMessage ="The Address Length must Be Between 5 and 50")]
        [Required]
        public string Address { get; set; }
        public string Tel { get; set; }
        public string? AvatarUrl { get; set; }
        public bool IsActive { get; set; }=true;
       
    }
}
