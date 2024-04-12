using Microsoft.AspNetCore.Identity;

namespace MovieReviewApp.Models
{
    public class AppUser:IdentityUser
    {
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
