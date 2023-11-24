using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.OrderOperations
{
    public class GetOrdersQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetOrdersQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<OrdersViewModel> Handle()
        {
            var orderList = _dbContext.CustomersMovies.Include(x => x.Customer).Include(x => x.Movie). OrderBy(x => x.Id).ToList<CustomerMovie>();
            List<OrdersViewModel> vm = _mapper.Map<List<OrdersViewModel>>(orderList);
            return vm;                               
        }
    }
    public class OrdersViewModel
    {   
        public string? BuyingCustomerName { get; set; }
        public string? PurchasedMovie { get; set; }
        public string? PurchasedDate { get; set; }
        public string? Price { get; set; }
        
      
    }
}