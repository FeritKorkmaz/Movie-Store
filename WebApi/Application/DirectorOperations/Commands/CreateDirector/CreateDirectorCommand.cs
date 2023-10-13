using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorCommand
    {
        public CreateDirectorModel Model { get; set; }

        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateDirectorCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var director = _dbContext.Directors.SingleOrDefault(x =>x.Name == Model.Name && x.Surname == Model.Surname);
            if(director is not null)
            {
                throw new InvalidOperationException("Yonetmen zaten mevcut");
            }
            director = _mapper.Map<Director>(Model);
            _dbContext.Directors.Add(director);
            _dbContext.SaveChanges();
                                        
        }
    }

    public class CreateDirectorModel
    {      
        public string? Name { get; set; }
        public string? Surname { get; set; }     
        
    }
}
