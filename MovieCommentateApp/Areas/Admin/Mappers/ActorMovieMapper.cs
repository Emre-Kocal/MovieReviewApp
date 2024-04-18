using MovieReviewApp.Areas.Admin.Dtos.ActorMovie;
using MovieReviewApp.Areas.Admin.Dtos.Genre;
using MovieReviewApp.Models;

namespace MovieReviewApp.Areas.Admin.Mappers
{
    public static class ActorMovieMapper
    {
        public static ActorMovie ActorMovieToCreateDto(this ActorMovieDto model)
        {
            return new ActorMovie
            {
                ActorId=model.ActorId,
                MovieId=model.MovieId
            };
        }
    }
}
