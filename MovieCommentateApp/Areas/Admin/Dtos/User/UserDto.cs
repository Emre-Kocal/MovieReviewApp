using MovieReviewApp.Models;

namespace MovieReviewApp.Areas.Admin.Dtos.User
{
    public class UserDto
    {
        public string Id { get; set; }=string.Empty;
        public string Username { get; set; }=string.Empty;
        public List<Comment> Comments { get; set; }=new List<Comment>();
    }
}
