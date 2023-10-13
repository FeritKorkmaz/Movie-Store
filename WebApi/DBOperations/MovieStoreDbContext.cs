using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class MovieStoreDbContext : DbContext, IMovieStoreDbContext
    {
        public MovieStoreDbContext(DbContextOptions<MovieStoreDbContext> options): base(options)
        { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }       
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<ActorMovie> ActorsMovies { get; set; }
        public DbSet<CustomerMovie> CustomersMovies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorMovie>()
                .HasKey(am => new { am.ActorId, am.MovieId });
                
            modelBuilder.Entity<ActorMovie>()
                .HasOne(am => am.Actor)
                .WithMany(a => a.ActorsMovies)
                .HasForeignKey(am => am.ActorId);

            modelBuilder.Entity<ActorMovie>()
                .HasOne(am => am.Movie)
                .WithMany(m => m.ActorsMovies)
                .HasForeignKey(am => am.MovieId);


            modelBuilder.Entity<CustomerMovie>()
                .HasKey(cm => new { cm.CustomerId, cm.MovieId });

            modelBuilder.Entity<CustomerMovie>()
                .HasOne(cm => cm.Customer)
                .WithMany(c => c.CustomersMovies)
                .HasForeignKey(cm => cm.CustomerId);
                
            modelBuilder.Entity<CustomerMovie>()
                .HasOne(cm => cm.Movie)
                .WithMany(m => m.CustomersMovies)
                .HasForeignKey(cm => cm.MovieId);      
        }
       


              

        public override int SaveChanges()

        {
            return base.SaveChanges();
        }

                
    }
    
     
}
