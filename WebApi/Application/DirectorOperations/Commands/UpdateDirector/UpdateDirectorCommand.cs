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
       
        public UpdateDirectorCommand(IMovieStoreDbContext dbContext)
        {
            _dbcontext = dbContext;            
        }
        public void Handle()
        {
            var director = _dbcontext.Directors.SingleOrDefault(x => x.Id == DirectorId);
            if (director is null)
            {
                throw new InvalidOperationException("Film bulunamadi");
            }
            director.Name = Model.Name != default ? Model.Name : director.Name;
            director.Surname = Model.Surname != default ? Model.Surname : director.Surname;
            
          
            _dbcontext.SaveChanges();
            
        }
    }

    public class UpdateDirectorModel
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
    }
       
}