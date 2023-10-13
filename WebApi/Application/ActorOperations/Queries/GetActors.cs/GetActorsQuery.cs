using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Application.MovieOperations.Queries.GetMovies;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.ActorOperations.Queries.GetActors
{
    public class GetActorsQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetActorsQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<ActorsViewModel> Handle()
        {
            var actorList = _dbContext.Actors.Include(x=> x.ActorsMovies).ThenInclude(x=> x.Movie).OrderBy(x => x.Id).ToList<Actor>();
            List<ActorsViewModel> vm = _mapper.Map<List<ActorsViewModel>>(actorList);
            return vm;                               
        }
    }

    public class ActorsViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }        
        public List<string> ActorsMovies { get; set; }
    }
}
