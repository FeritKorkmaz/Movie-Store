using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Application.ActorOperations.Queries.GetActors;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.MovieOperations.Queries.GetMovies
{
    public class GetMoviesQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetMoviesQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<MoviesViewModel> Handle()
        {
            var movieList = _dbContext.Movies.Include(x=> x.Director).Include(x=> x.Genre).Include(x=> x.ActorsMovies).ThenInclude(x=> x.Actor).OrderBy(x => x.Id).ToList<Movie>();
            List<MoviesViewModel> vm = _mapper.Map<List<MoviesViewModel>>(movieList);
            return vm;                               
        }
    }

    public class MoviesViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Year { get; set; }
        public string? Genre { get; set; }
        public string? Director { get; set; }
        public List<string>? ActorsMovies { get; set; }
        public string? Price { get; set; }
        
    }
}
