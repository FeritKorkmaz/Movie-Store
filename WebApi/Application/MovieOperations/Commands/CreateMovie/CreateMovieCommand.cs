using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;
namespace WebApi.Application.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommand
    {
        public CreateMovieModel Model { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateMovieCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public void Handle()
        {
            var movie = _dbContext.Movies.SingleOrDefault(x => x.Title == Model.Title);
            if (movie is not null)
            {
                throw new InvalidOperationException("Film zaten mevcut");
            }                
            movie = _mapper.Map<Movie>(Model);
            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
        }
    }

    public class CreateMovieModel
    {
        public string? Title { get; set; }       
        public DateTime Year { get; set; }
        public int GenreId { get; set; }
        public int DirectorId { get; set; }
        public List<int>? ActorsId { get; set; }
        public string? Price { get; set; }
    }
}