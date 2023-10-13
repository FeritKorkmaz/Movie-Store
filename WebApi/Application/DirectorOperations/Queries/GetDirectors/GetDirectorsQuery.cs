using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.DirectorOperations.Queries.GetDirectors
{
    public class GetDirectorsQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetDirectorsQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<DirectorsViewModel> Handle()
        {
            var directorList = _dbContext.Directors.Include(x=> x.Movies).OrderBy(x => x.Id).ToList<Director>();
            List<DirectorsViewModel> vm = _mapper.Map<List<DirectorsViewModel>>(directorList);
            return vm;                               
        }
    }

    public class DirectorsViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }        
        public List<string>? Movies { get; set; }
    }
}
