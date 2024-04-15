using MovieReviewApp.Areas.Admin.Dtos.Actor;
using MovieReviewApp.Dtos.Comment;
using MovieReviewApp.Models;

namespace MovieReviewApp.Mappers
{
    public static class ActorMappers
    {
        public static Actor CreateActorToActor(this CreateActorDto model)
        {
            return new Actor
            {
                FullName = model.FullName,
                BirthDate=model.BirthDate,
                Bio=model.Bio,
                Image=model.Image,
                 Nationality=model.Nationality
            };
        }
    }
}
