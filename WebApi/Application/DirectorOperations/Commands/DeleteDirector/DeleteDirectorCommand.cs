using WebApi.DBOperations;
namespace WebApi.Application.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommand
    {
        public int DirectorId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;

        public DeleteDirectorCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var director = _dbContext.Directors.SingleOrDefault(x => x.Id == DirectorId);
            if (director is null)
            {
                throw new InvalidOperationException("Yonetmen bulunamadi");
            }
            _dbContext.Directors.Remove(director);
            _dbContext.SaveChanges();
        }

    }
}