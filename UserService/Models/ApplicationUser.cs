using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserService.Models
{
    public class ApplicationUser : IdentityUser
    {
        public  string FullName { get; set; } = string.Empty;
    }
}
