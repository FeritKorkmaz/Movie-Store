using AutoMapper;
using WebApi.Application.ActorOperations.Commands.CreateActor;
using WebApi.Application.ActorOperations.Queries.GetActors;
using WebApi.Application.CustomerOperations.Commands.CreateCustomer;
using WebApi.Application.CustomerOperations.Queries.GetCustomers;
using WebApi.Application.DirectorOperations.Commands.CreateDirector;
using WebApi.Application.DirectorOperations.Queries.GetDirectors;
using WebApi.Application.MovieOperations.Commands.CreateMovie;
using WebApi.Application.MovieOperations.Queries.GetMovies;
using WebApi.Application.PurchaseOperation.Commands;
using WebApi.Entities;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // MOVIES
            CreateMap<CreateMovieModel, Movie>()
                .ForMember(dest => dest.ActorsMovies, opt => opt.MapFrom(src => src.ActorsId.Select(a => new ActorMovie { ActorId = a })));
            CreateMap<Movie, MoviesViewModel>()
                .ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.Name + " " + src.Director.Surname))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                .ForMember(dest => dest.ActorsMovies, opt => opt.MapFrom(src => src.ActorsMovies.Select(m => m.Actor.Name + " " + m.Actor.Surname)));

            // DIRECTORS
            CreateMap<Director, DirectorsViewModel>()
                .ForMember(dest => dest.Movies, opt => opt.MapFrom(src => src.Movies.Select(m => m.Title)));
            CreateMap<CreateDirectorModel, Director>();


            // ACTORS
            CreateMap<Actor, ActorsViewModel>()
                .ForMember(dest => dest.ActorsMovies, opt => opt.MapFrom(src => src.ActorsMovies.Select(m => m.Movie.Title)));
            CreateMap<CreateActorModel, Actor>();


            // CUSTOMERS
            CreateMap<Customer, CustomersViewModel>()
                .ForMember(dest => dest.PurchasedMovies, opt => opt.MapFrom(src => src.CustomersMovies.Select(m => m.Movie.Title)));
            CreateMap<CreateCustomerModel, Customer>(); 


            CreateMap<PurchasingProcessModel, CustomerMovie>();   

     
            
         
                  
            




            // CreateMap<CreateGenreModel, Genre>();
            // CreateMap<Genre, GenresViewModel>();
            // CreateMap<Genre, GenreDetailViewModel>();

            // CreateMap<CreateAuthorModel, Author>();            
            // CreateMap<Author, AuthorsViewModel>();
            // CreateMap<Author, AuthorDetailViewModel>();

            // CreateMap<CreateUserModel, User>();  

        }

    }
}