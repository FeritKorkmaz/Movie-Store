using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;
using WebApi.Application.MovieOperations.Queries.GetMovies;
using WebApi.Application.MovieOperations.Commands.CreateMovie;
using WebApi.Application.MovieOperations.Commands.DeleteMovie;
using WebApi.Application.MovieOperations.Commands.UpdateMovie;

namespace WebApi.Controllers
{
    
    [ApiController]
    [Route("[controller]s")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public MovieController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            GetMoviesQuery query = new GetMoviesQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);  
        } 

        //Post
        [HttpPost]
        public IActionResult AddMovie([FromBody] CreateMovieModel newMovie)
        {
            CreateMovieCommand command = new CreateMovieCommand(_context, _mapper);           
            command.Model = newMovie;

            // CreateBookCommandValidator validator = new CreateBookCommandValidator();
            // validator.ValidateAndThrow(command);

            command.Handle();                        
            return Ok();
        }


        //Put
        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieModel updateMovie)
        {       
        
            UpdateMovieCommand command = new UpdateMovieCommand(_context);   
            command.MovieId = id;
            command.Model = updateMovie;

            // UpdateBooksQueryValidator validator = new UpdateBooksQueryValidator();
            // validator.ValidateAndThrow(command);
            command.Handle();
    
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            DeleteMovieCommand command = new DeleteMovieCommand(_context);
            command.MovieId = id;
            
            // DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            // validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();            
        }      
    }
}