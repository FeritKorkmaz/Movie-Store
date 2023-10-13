using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.ActorOperations.Commands.CreateActor;
using WebApi.Application.ActorOperations.Commands.DeleteActor;
using WebApi.Application.ActorOperations.Commands.UpdateActor;
using WebApi.Application.ActorOperations.Queries.GetActors;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    
    [ApiController]
    [Route("[controller]s")]
    public class ActorController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public ActorController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetActors()
        {
            GetActorsQuery query = new GetActorsQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddActor([FromBody] CreateActorModel newActor)
        {
            CreateActorCommand command = new CreateActorCommand(_context, _mapper);           
            command.Model = newActor;

            // CreateBookCommandValidator validator = new CreateBookCommandValidator();
            // validator.ValidateAndThrow(command);

            command.Handle();                        
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteActor (int id)
        {
            DeleteActorCommand command = new DeleteActorCommand(_context);
            command.ActorId = id;
            
            // DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            // validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();            
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] UpdateActorrModel updateActor)
        {       
        
            UpdateActorCommand command = new UpdateActorCommand(_context);   
            command.ActorId = id;
            command.Model = updateActor;

            // UpdateBooksQueryValidator validator = new UpdateBooksQueryValidator();
            // validator.ValidateAndThrow(command);
            command.Handle();
    
            return Ok();
        }  
    }
}