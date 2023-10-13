using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.CustomerOperations.Commands.CreateCustomer;
using WebApi.Application.CustomerOperations.Commands.DeleteCustomer;
using WebApi.Application.CustomerOperations.Queries.GetCustomers;
using WebApi.Application.PurchaseOperation.Commands;
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
        public IActionResult GetActors()
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

            // CreateBookCommandValidator validator = new CreateBookCommandValidator();
            // validator.ValidateAndThrow(command);

            command.Handle();                        
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer (int id)
        {
            DeleteCustomerCommand command = new DeleteCustomerCommand(_context);
            command.CustomerId = id;
            
            // DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            // validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();            
        }      
        
        
        [HttpPost("Purchase")]
        public IActionResult AddCustomer([FromBody] PurchasingProcessModel newPurchasingProcess)
        {
            PurchasingProcess command = new PurchasingProcess(_context, _mapper);           
            command.Model = newPurchasingProcess;

            // CreateBookCommandValidator validator = new CreateBookCommandValidator();
            // validator.ValidateAndThrow(command);

            command.Handle();                        
            return Ok();
        }
    }
}