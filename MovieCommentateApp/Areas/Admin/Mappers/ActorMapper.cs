using MovieReviewApp.Areas.Admin.Dtos.Actor;
using MovieReviewApp.Areas.Admin.Dtos.User;
using MovieReviewApp.Models;

namespace MovieReviewApp.Areas.Admin.Mappers
{
    public static class ActorMapper
    {
        public static Actor UpdateActorToActor(this UpdateActorDto model)
        {
            return new Actor
            {
                Id = model.Id,
                Bio=model.Bio,
                BirthDate=model.BirthDate,
                FullName=model.FullName,
                Image = model.Image,
                Nationality = model.Nationality,
            };
        }
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
