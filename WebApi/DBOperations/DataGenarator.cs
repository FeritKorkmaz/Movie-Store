using System.Collections;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class DataGenarator
    {
       

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
            {
                // Look for any book.
                if (context.Movies.Any())
                {
                    return; // Data was already seeded
                } 
                if (context.Directors.Any())
                {
                    return; // Data was already seeded
                }               
                  
                context.Movies.AddRange(
                    new Movie{                        
                        Title = "Batman",
                        GenreId = 1,
                        DirectorId = 1,                        
                        Year = new DateTime(2000, 01, 01),
                        Price = "9.99"
                    },
                    new Movie{
                        
                        Title = "Harry Potter",
                        GenreId = 1,
                        DirectorId = 2,                       
                        Year = new DateTime(2000, 01, 01),                        
                        Price = "9.99"
                    },
                    new Movie{                        
                        Title = "The Matrix",
                        GenreId = 1,
                        DirectorId = 1,                       
                        Year = new DateTime(2000, 01, 01),                                              
                        Price = "9.99"
                    }                
                );

                context.Actors.AddRange(
                    new Actor{
                        Name = "Christian",
                        Surname = "Bale",
                    },
                    new Actor{
                        Name = "Michael",
                        Surname = "Caine",
                    },
                    new Actor{
                        Name = "Heath",
                        Surname = "Ledger",
                    },
                    new Actor{
                        Name = "Daniel",
                        Surname = "Radcliffe",
                    },
                    new Actor{
                        Name = "Emma",
                        Surname = "Watson",
                    },
                    new Actor{
                        Name = "Rupert",
                        Surname = "Grint",
                    },                                
                    new Actor{
                        Name = "Keanu",
                        Surname = "Reeves",
                    },
                    new Actor{
                        Name = "Laurence",
                        Surname = "Fishburne",
                    },
                    new Actor{
                        Name = "Carrie-Anne",
                        Surname = "Moss",
                    }
                );

                context.ActorsMovies.AddRange(
                    new ActorMovie{
                        ActorId = 1,
                        MovieId = 1
                    },
                     new ActorMovie{
                        ActorId = 1,
                        MovieId = 2
                    },
                     new ActorMovie{
                        ActorId = 1,
                        MovieId = 3
                    },
                    new ActorMovie{
                        ActorId = 2,
                        MovieId = 1
                    },
                    new ActorMovie{
                        ActorId = 3,
                        MovieId = 1
                    },
                    new ActorMovie{
                        ActorId = 4,
                        MovieId = 1
                    },
                    new ActorMovie{
                        ActorId = 4,
                        MovieId = 2
                    },                  
                    new ActorMovie{
                        ActorId = 4,
                        MovieId = 3
                    },
                    new ActorMovie{
                        ActorId = 5,
                        MovieId = 2
                    },
                    new ActorMovie{
                        ActorId = 6,
                        MovieId = 2
                    },
                    new ActorMovie{
                        ActorId = 7,
                        MovieId = 1
                    },
                    new ActorMovie{
                        ActorId = 7,
                        MovieId = 2
                    },
                    new ActorMovie{
                        ActorId = 7,
                        MovieId = 3
                    },
                    new ActorMovie{
                        ActorId = 8,
                        MovieId = 3
                    },
                    new ActorMovie{
                        ActorId = 9,
                        MovieId = 3
                    }            
                );

                context.CustomersMovies.AddRange(
                    new CustomerMovie{
                        CustomerId = 1,
                        MovieId = 1
                    },                  
                    new CustomerMovie{
                        CustomerId = 1,
                        MovieId = 2
                    },
                    new CustomerMovie{
                        CustomerId = 1,
                        MovieId = 3
                    }
                );
                
            
                             

                context.Directors.AddRange(
                    new Director{
                        Name = "Christopher",
                        Surname = "Nolan"                                                                                          
                    },
                    new Director{
                        Name = "David",
                        Surname = "Fincher",                                  
                    }
                );



                context.Genres.AddRange(
                    new Genre{
                        Name = "Action"
                    },
                    new Genre{
                        Name = "Fantasy"
                    },
                    new Genre{
                        Name = "Drama"
                    }
                );

               

                context.Customers.AddRange(
                    new Customer{
                        Name = "John",
                        Surname = "Doe",
                        
                    },
                    new Customer{
                        Name = "Jane",
                        Surname = "Doe",
                    }
                );

                

                

                
                context.SaveChanges();

            }
        }
    }
}