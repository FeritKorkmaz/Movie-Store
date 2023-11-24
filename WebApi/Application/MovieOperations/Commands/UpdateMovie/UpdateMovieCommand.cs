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
        private readonly IMapper _mapper;

        public UpdateMovieCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }
        public void Handle()
        {
            var movie = _dbcontext.Movies.SingleOrDefault(x => x.Id == MovieId);
            if (movie is null)
            {
                throw new InvalidOperationException("Film bulunamadi");
            }
            _mapper.Map(Model, movie);
            _dbcontext.SaveChanges();
            
        }
    }

    public class UpdateMovieModel
    {
        public string? Title { get; set; }
        public int GenreId { get; set; }
        public int DirectorId { get; set; }
        public double? Price { get; set; }
    }
}