using MovieReviewApp.Areas.Admin.Dtos.Actor;
using MovieReviewApp.Areas.Admin.Dtos.User;
using MovieReviewApp.Models;

namespace MovieReviewApp.Areas.Admin.Mappers
{
    public static class ActorMapper
    {
        public static UpdateActorDto ActorToUpdateActorDto(this Actor actor)
        {
            return new UpdateActorDto
            {
                Id = actor.Id,
                Bio = actor.Bio,
                BirthDate = actor.BirthDate,
                FullName = actor.FullName,
                Image = actor.Image,
                Nationality = actor.Nationality,
            };
        }
    }
}
