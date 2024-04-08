using MovieReviewApp.Dtos.Comment;
using MovieReviewApp.Dtos.Movie;
using MovieReviewApp.Models;

namespace MovieReviewApp.Mappers
{
    public static class CommentMappers
    {
        public static Comment CommentDtoToComment(this CommentDto model)
        {
            return new Comment
            {
                MovieId = model.MovieId,
                Rating = model.Rating,
                Text = model.Text,
                UserId = model.UserId
            };
        }
    }
}
