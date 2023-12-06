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
                if (context.Movies.Any() || context.Directors.Any() || context.Genres.Any() || context.Actors.Any() || context.Customers.Any() || context.ActorsMovies.Any() || context.CustomersMovies.Any())
                {
                    return; // Data was already seeded
                } 
                
                  
                context.Movies.AddRange(
                    new Movie{                        
                        Title = "The Dark Knight",
                        GenreId = 2,
                        DirectorId = 1,                        
                        Year = new DateTime(2000, 01, 01),
                        Price = 9.99
                    },
                    new Movie{
                        
                        Title = "Harry Potter and the Philosopher's Stone",
                        GenreId = 1,
                        DirectorId = 2,                       
                        Year = new DateTime(2000, 01, 01),                        
                        Price = 9.99
                    },
                    new Movie{                        
                        Title = "The Matrix Revolution",
                        GenreId = 3,
                        DirectorId = 1,                       
                        Year = new DateTime(2000, 01, 01),                                              
                        Price = 9.99
                    },
                    new Movie{
                        Title = "The Dark Knight Rises",
                        GenreId = 2,
                        DirectorId = 2,
                        Year = new DateTime(2000, 01, 01),
                        Price = 9.99
                    },
                    new Movie{
                        Title = "The Prestige",
                        GenreId = 1,
                        DirectorId = 3,
                        Year = new DateTime(2000, 01, 01),
                        Price = 9.99
                    },
                    new Movie{
                        Title = "The Godfather",
                        GenreId = 4,
                        DirectorId = 3,
                        Year = new DateTime(2000, 01, 01),
                        Price = 9.99
                    },
                  
                    new Movie{
                        Title = "The Lord of the Rings: The Return of the King",
                        GenreId = 5,
                        DirectorId = 4,
                        Year = new DateTime(2000, 01, 01),
                        Price = 9.99
                    },
                    new Movie{
                        Title = "The Lord of the Rings: The Two Towers",
                        GenreId = 5,
                        DirectorId = 4,
                        Year = new DateTime(2000, 01, 01),
                        Price = 9.99
                    },
                    new Movie{
                        Title = "The Lord of the Rings: The Fellowship of the Ring",
                        GenreId = 5,
                        DirectorId = 5,
                        Year = new DateTime(2000, 01, 01),
                        Price = 9.99
                    },
                    new Movie{
                        Title = "The Good, the Bad and the Ugly",
                        GenreId = 4,
                        DirectorId = 5,
                        Year = new DateTime(2000, 01, 01),
                        Price = 9.99
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
                    },
                    new Actor{
                        Name = "Heath",
                        Surname = "Ledger",
                    },
                    new Actor{
                        Name = "Tom",
                        Surname = "Hanks",
                    },
                    new Actor{
                        Name = "Morgan",
                        Surname = "Freeman",
                    },
                    new Actor{
                        Name = "Brad",
                        Surname = "Pitt",
                    },
                    new Actor{
                        Name = "Kevin",
                        Surname = "Spacey",
                    },
                    new Actor{
                        Name = "Jack",
                        Surname = "Nicholson",
                    },
                    new Actor{
                        Name = "Mark",
                        Surname = "Hamill",
                    },
                    new Actor{
                        Name = "Harrison",
                        Surname = "Ford",
                    },
                    new Actor{
                        Name = "Carrie",
                        Surname = "Fisher",
                    },
                    new Actor{
                        Name = "Alec",
                        Surname = "Guinness",
                    },
                    new Actor{
                        Name = "Sean",
                        Surname = "Connery",
                    }
                );

                context.ActorsMovies.AddRange(
                    // 1. Movie
                    new ActorMovie{
                        ActorId = 1,
                        MovieId = 1
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
                        // 2. Movie
                    new ActorMovie{
                        ActorId = 19,
                        MovieId = 2
                    },
                    new ActorMovie{
                        ActorId = 20,
                        MovieId = 2
                    },
                    new ActorMovie{
                        ActorId = 15,
                        MovieId = 2
                    },
                    new ActorMovie{
                        ActorId = 16,
                        MovieId = 2
                    },
                        // 3. Movie
                    new ActorMovie{
                        ActorId = 2,
                        MovieId = 3
                    },
                    new ActorMovie{
                        ActorId = 3,
                        MovieId = 3
                    },
                    new ActorMovie{
                        ActorId = 4,
                        MovieId = 3
                    },
                    new ActorMovie{
                        ActorId = 5,
                        MovieId = 3
                    },
                        // 4. Movie
                    new ActorMovie{
                        ActorId = 11,
                        MovieId = 4
                    },
                    new ActorMovie{
                        ActorId = 12,
                        MovieId = 4
                    },
                    new ActorMovie{
                        ActorId = 5,
                        MovieId = 4
                    },
                    new ActorMovie{
                        ActorId = 6,
                        MovieId = 4
                    },
                        // 5. Movie
                    new ActorMovie{
                        ActorId = 4,
                        MovieId = 5
                    },
                    new ActorMovie{
                        ActorId = 5,
                        MovieId = 5
                    },
                    new ActorMovie{
                        ActorId = 6,
                        MovieId = 5
                    },
                    new ActorMovie{
                        ActorId = 7,
                        MovieId = 5
                    },
                        // 6. Movie
                    new ActorMovie{
                        ActorId = 5,
                        MovieId = 6
                    },
                    new ActorMovie{
                        ActorId = 6,
                        MovieId = 6
                    },
                    new ActorMovie{
                        ActorId = 7,
                        MovieId = 6
                    },
                    new ActorMovie{
                        ActorId = 8,
                        MovieId = 6
                    },
                        // 7. Movie
                    new ActorMovie{
                        ActorId = 6,
                        MovieId = 7
                    },
                    new ActorMovie{
                        ActorId = 7,
                        MovieId = 7
                    },
                    new ActorMovie{
                        ActorId = 8,
                        MovieId = 7
                    },
                    new ActorMovie{
                        ActorId = 9,
                        MovieId = 7
                    },
                        // 8. Movie
                    new ActorMovie{
                        ActorId = 7,
                        MovieId = 8
                    },
                    new ActorMovie{
                        ActorId = 8,
                        MovieId = 8
                    },
                    new ActorMovie{
                        ActorId = 9,
                        MovieId = 8
                    },
                    new ActorMovie{
                        ActorId = 10,
                        MovieId = 8
                    },
                        // 9. Movie
                    new ActorMovie{
                        ActorId = 11,
                        MovieId = 9
                    },
                    new ActorMovie{
                        ActorId = 12,
                        MovieId = 9
                    },
                    new ActorMovie{
                        ActorId = 13,
                        MovieId = 9
                    },
                    new ActorMovie{
                        ActorId = 14,
                        MovieId = 9
                    },
                        // 10. Movie
                    new ActorMovie{
                        ActorId = 15,
                        MovieId = 10
                    },
                    new ActorMovie{
                        ActorId = 16,
                        MovieId = 10
                    },
                    new ActorMovie{
                        ActorId = 17,
                        MovieId = 10
                    },
                    new ActorMovie{
                        ActorId = 18,
                        MovieId = 10
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
                    },
                    new CustomerMovie{
                        CustomerId = 2,
                        MovieId = 4
                    },
                    new CustomerMovie{
                        CustomerId = 2,
                        MovieId = 5
                    },
                    new CustomerMovie{
                        CustomerId = 3,
                        MovieId = 4
                    },
                    new CustomerMovie{
                        CustomerId = 3,
                        MovieId = 6
                    },
                    new CustomerMovie{
                        CustomerId = 4,
                        MovieId = 7
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
                    },
                    new Director{
                        Name = "Peter",
                        Surname = "Jackson",
                    },
                    new Director{
                        Name = "Quentin",
                        Surname = "Tarantino",
                    },
                    new Director{
                        Name = "James",
                        Surname = "Cameron",
                    }
                );



                context.Genres.AddRange(
                    new Genre{
                        Name = "Action"
                    },
                    new Genre{
                        Name = "Adventure"
                    },
                    new Genre{
                        Name = "Drama"
                    },
                    new Genre{
                        Name = "Family"
                    },
                    new Genre{
                        Name = "Fantasy"
                    }
                 
                );

               

                context.Customers.AddRange(
                    new Customer{
                        Name = "John",
                        Surname = "Doe",
                        Email = "john@doe",
                        Password = "12345"
                        
                    },
                    new Customer{
                        Name = "Jane",
                        Surname = "Doe",
                        Email = "jane@doe",
                        Password = "12345"
                    },
                    new Customer{
                        Name = "Jack",
                        Surname = "Doe",
                        Email = "jack@doe",
                        Password = "12345"
                    },
                    new Customer{
                        Name = "Jill",
                        Surname = "Doe",
                        Email = "jill@doe",
                        Password = "12345"
                    },
                    new Customer{
                        Name = "Jim",
                        Surname = "Doe",
                        Email = "jim@doe",
                        Password = "12345"
                    }
                );

                

                

                
                context.SaveChanges();

            }
        }
    }
}