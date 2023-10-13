using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;
using WebApi.Application.DirectorOperations.Queries.GetDirectors;
using WebApi.Application.DirectorOperations.Commands.CreateDirector;
using WebApi.Application.DirectorOperations.Commands.UpdateDirector;
using WebApi.Application.DirectorOperations.Commands.DeleteDirector;

namespace WebApi.Controllers
{
    
    [ApiController]
    [Route("[controller]s")]
    public class DirectorController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public DirectorController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetDirectors()
        {
            GetDirectorsQuery query = new GetDirectorsQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);  
        } 

        //Post
        [HttpPost]
        public IActionResult AddDirector([FromBody] CreateDirectorModel newDirector)
        {
            CreateDirectorCommand command = new CreateDirectorCommand(_context, _mapper);           
            command.Model = newDirector;

            // CreateBookCommandValidator validator = new CreateBookCommandValidator();
            // validator.ValidateAndThrow(command);

            command.Handle();                        
            return Ok();
        }


        //Put
        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] UpdateDirectorModel updateDirector)
        {       
        
            UpdateDirectorCommand command = new UpdateDirectorCommand(_context);   
            command.DirectorId = id;
            command.Model = updateDirector;

            // UpdateBooksQueryValidator validator = new UpdateBooksQueryValidator();
            // validator.ValidateAndThrow(command);
            command.Handle();
    
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            DeleteDirectorCommand command = new DeleteDirectorCommand(_context);
            command.DirectorId = id;
            
            // DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            // validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();            
        }      
    }
}