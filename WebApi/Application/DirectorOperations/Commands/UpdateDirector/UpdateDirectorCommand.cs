using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;
namespace WebApi.Application.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommand
    {
        public UpdateDirectorModel Model { get; set; }
        public int DirectorId { get; set; }
        private readonly IMovieStoreDbContext _dbcontext;
        private readonly IMapper _mapper;

        public UpdateDirectorCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }
        public void Handle()
        {
            var director = _dbcontext.Directors.SingleOrDefault(x => x.Id == DirectorId);
            if (director is null)
            {
                throw new InvalidOperationException("Film bulunamadi");
            }
            
            _mapper.Map(Model, director);           
            _dbcontext.SaveChanges();
            
        }
    }

    public class UpdateDirectorModel
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
    }
       
}