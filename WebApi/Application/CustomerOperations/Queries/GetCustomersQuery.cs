using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.CustomerOperations.Queries
{
    public class GetCustomersQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetCustomersQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<CustomersViewModel> Handle()
        {
            var customerList = _dbContext.Customers.Include(x => x.CustomersMovies).ThenInclude(x=> x.Movie).OrderBy(x => x.Id).ToList<Customer>();
            List<CustomersViewModel> vm = _mapper.Map<List<CustomersViewModel>>(customerList);
            return vm;                               
        }
    }
    public class CustomersViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }       
        public List<string>? PurchasedMovies { get; set; }
    }
}