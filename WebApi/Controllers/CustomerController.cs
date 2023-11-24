using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.CustomerOperations.Commands.CreateCustomer;
using WebApi.Application.CustomerOperations.Commands.DeleteCustomer;
using WebApi.Application.CustomerOperations.Commands.PurchasingProcess;
using WebApi.Application.CustomerOperations.Commands.RemovePursahedMovie;
using WebApi.Application.CustomerOperations.Queries;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    
    [ApiController]
    [Route("[controller]s")]
    public class CustomerController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        
        public CustomerController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            GetCustomersQuery query = new GetCustomersQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }
      

        [HttpPost]
        public IActionResult AddCustomer([FromBody] CreateCustomerModel newCustomer)
        {
            CreateCustomerCommand command = new CreateCustomerCommand(_context, _mapper);           
            command.Model = newCustomer;

            CreateCustomerCommandValidator validator = new CreateCustomerCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();                        
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer (int id)
        {
            DeleteCustomerCommand command = new DeleteCustomerCommand(_context);
            command.CustomerId = id;
            
            DeleteCustomerCommandValidator validator = new DeleteCustomerCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();            
        }
        [HttpDelete("RemovePurchasedMovie")]
        public IActionResult RemovePursahedMovie(int customerId, int movieId)
        {
            RemovePursahedMovie command = new RemovePursahedMovie(_context);
            
            command.CustomerId = customerId;
            command.MovieId = movieId;            
           
            RemovePursahedMovieValidator validator = new RemovePursahedMovieValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        
        [HttpPost("Purchase")]
        public IActionResult Purchase([FromBody] PurchasingProcessModel newPurchasingProcess)
        {
            PurchasingProcess command = new PurchasingProcess(_context, _mapper);           
            command.Model = newPurchasingProcess;

            PurchasingProcessValidator validator = new PurchasingProcessValidator();
            validator.ValidateAndThrow(command);

            command.Handle();                        
            return Ok();
        }
    }
}