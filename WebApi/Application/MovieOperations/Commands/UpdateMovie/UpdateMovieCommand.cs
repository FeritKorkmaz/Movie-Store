using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;
namespace WebApi.Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommand
    {
        public UpdateMovieModel Model { get; set; }
        public int MovieId { get; set; }
        private readonly IMovieStoreDbContext _dbcontext;
       
        public UpdateMovieCommand(IMovieStoreDbContext dbContext)
        {
            _dbcontext = dbContext;            
        }
        public void Handle()
        {
            var movie = _dbcontext.Movies.SingleOrDefault(x => x.Id == MovieId);
            if (movie is null)
            {
                throw new InvalidOperationException("Film bulunamadi");
            }
            movie.Title = Model.Title != default ? Model.Title : movie.Title;
            movie.GenreId = Model.GenreId != default ? Model.GenreId : movie.GenreId;
            movie.DirectorId = Model.DirectorId != default ? Model.DirectorId : movie.DirectorId;
            movie.Price = Model.Price != default ? Model.Price : movie.Price;
            _dbcontext.SaveChanges();
            
        }
    }

    public class UpdateMovieModel
    {
        public string? Title { get; set; }
        public int GenreId { get; set; }
        public int DirectorId { get; set; }
        public string? Price { get; set; }
    }
}