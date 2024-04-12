
using MovieReviewApp.Areas.Admin.Dtos.User;
using MovieReviewApp.Models;

namespace MovieReviewApp.Areas.Admin.Mappers
{
    public static class UserMapper
    {
        public static UserDto AppUserToUserDto(this AppUser model)
        {
            return new UserDto
            {
                Id=model.Id,
                Username = model.UserName,
                Comments=model.Comments
            };
        }
    }
}
