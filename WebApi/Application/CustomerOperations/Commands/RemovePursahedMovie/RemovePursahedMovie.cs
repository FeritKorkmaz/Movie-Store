using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.Application.CustomerOperations.Commands.RemovePursahedMovie
{
    public class RemovePursahedMovie
    {
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        

        public RemovePursahedMovie(IMovieStoreDbContext dbContext )
        {
            _dbContext = dbContext;
            
        }

        public void Handle()
        {   
            var customer = _dbContext.Customers.Include(x => x.CustomersMovies).FirstOrDefault(x => x.Id == CustomerId);
            if (customer is null)
            {
                throw new InvalidOperationException("Musteri bulunamadi");
            }
            var customermovie = customer.CustomersMovies.Where(x => x.IsActive).FirstOrDefault(x => x.MovieId == MovieId);
            if (customermovie is null)
            {
                throw new InvalidOperationException("Film bulunamadi");
            }

            customermovie.IsActive = false;           
            _dbContext.SaveChanges();
        }

       
    }
}
