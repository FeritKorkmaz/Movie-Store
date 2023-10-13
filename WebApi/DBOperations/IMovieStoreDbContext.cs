using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
   public interface IMovieStoreDbContext
   {
       DbSet<Movie> Movies { get; set; }
       DbSet<Director> Directors { get; set; }
       DbSet<Customer> Customers { get; set; }  
       DbSet<Genre> Genres { get; set; }
       DbSet<Actor> Actors { get; set; }
       DbSet<ActorMovie> ActorsMovies { get; set; }
       DbSet<CustomerMovie> CustomersMovies { get; set; }
       
        

       int SaveChanges();
   } 
}