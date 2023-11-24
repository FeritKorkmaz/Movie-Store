using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.OrderOperations;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    
    [ApiController]
    [Route("[controller]s")]
    public class OrderController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        
        public OrderController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            GetOrdersQuery query = new GetOrdersQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }
    }
}