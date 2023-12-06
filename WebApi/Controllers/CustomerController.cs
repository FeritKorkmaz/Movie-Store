using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.CustomerOperations.Commands.CreateCustomer;
using WebApi.Application.CustomerOperations.Commands.CreateToken;
using WebApi.Application.CustomerOperations.Commands.DeleteCustomer;
using WebApi.Application.CustomerOperations.Commands.PurchasingProcess;
using WebApi.Application.CustomerOperations.Commands.RefreshToken;
using WebApi.Application.CustomerOperations.Commands.RemovePursahedMovie;
using WebApi.Application.CustomerOperations.Queries;
using WebApi.Application.TokenOperations.Models;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    
    [ApiController]
    [Route("[controller]s")]
    public class CustomerController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        readonly IConfiguration _configuration;

        public CustomerController(IMovieStoreDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult GetCustomers()
        {
            GetCustomersQuery query = new GetCustomersQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }
      

        [HttpPost]
        public ActionResult AddCustomer([FromBody] CreateCustomerModel newCustomer)
        {
            CreateCustomerCommand command = new CreateCustomerCommand(_context, _mapper);           
            command.Model = newCustomer;

            CreateCustomerCommandValidator validator = new CreateCustomerCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();                        
            return Ok();
        }

        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel model)
        {
            CreateTokenCommand command = new CreateTokenCommand(_context, _mapper, _configuration);
            command.Model = model;
            var token = command.Handle();
            return token;
        
        }

        [HttpGet("refreshToken")]
        public ActionResult<Token> RefreshToken([FromQuery] string token)
        {
            RefreshTokenCommand command = new RefreshTokenCommand(_context, _configuration);
            command.RefreshToken = token;
            var resultToken = command.Handle();
            return resultToken;
        
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer (int id)
        {
            DeleteCustomerCommand command = new DeleteCustomerCommand(_context);
            command.CustomerId = id;
            
            DeleteCustomerCommandValidator validator = new DeleteCustomerCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();            
        }
        [HttpDelete("RemovePurchasedMovie")]
        public ActionResult RemovePursahedMovie(int customerId, int movieId)
        {
            RemovePursahedMovie command = new RemovePursahedMovie(_context);
            
            command.CustomerId = customerId;
            command.MovieId = movieId;            
           
            RemovePursahedMovieValidator validator = new RemovePursahedMovieValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [Authorize]
        [HttpPost("Purchase")]
        public ActionResult Purchase([FromBody] PurchasingProcessModel newPurchasingProcess)
        {
            int userId = Convert.ToInt32(HttpContext.User.FindFirst("userId").Value); // Örneğin token'da "userId" adında bir claim bulunuyorsa

            PurchasingProcess command = new PurchasingProcess(_context, _mapper);           
            command.Model = newPurchasingProcess;
             command.UserId = userId; 

            PurchasingProcessValidator validator = new PurchasingProcessValidator();
            validator.ValidateAndThrow(command);

            command.Handle();                        
            return Ok();
        }
    }
}