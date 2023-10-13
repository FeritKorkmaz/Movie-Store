using WebApi.DBOperations;
using WebApi.Entities;
namespace WebApi.Application.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommand
    {
        public UpdateActorrModel Model { get; set; }
        public int ActorId { get; set; }
        private readonly IMovieStoreDbContext _dbcontext;
       
        public UpdateActorCommand(IMovieStoreDbContext dbContext)
        {
            _dbcontext = dbContext;            
        }
        public void Handle()
        {
            var actor = _dbcontext.Actors.SingleOrDefault(x => x.Id == ActorId);
            if (actor is null)
            {
                throw new InvalidOperationException("Oyuncu bulunamadi");
            }
            actor.Name = Model.Name != default ? Model.Name : actor.Name;
            actor.Surname = Model.Surname != default ? Model.Surname : actor.Surname;
            
          
            _dbcontext.SaveChanges();
            
        }
    }

    public class UpdateActorrModel
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
    }
       
}