using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;
namespace WebApi.Application.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommand
    {
        public UpdateActorrModel Model { get; set; }
        public int ActorId { get; set; }
        private readonly IMovieStoreDbContext _dbcontext;
        private readonly IMapper _mapper;


        public UpdateActorCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }
        public void Handle()
        {
            var actor = _dbcontext.Actors.SingleOrDefault(x => x.Id == ActorId);
            if (actor is null)
            {
                throw new InvalidOperationException("Oyuncu bulunamadi");
            }
            
            _mapper.Map(Model, actor);
            _dbcontext.SaveChanges();
            
        }
    }

    public class UpdateActorrModel
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
    }
       
}