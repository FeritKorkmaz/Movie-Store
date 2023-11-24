using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.CustomerOperations.Commands.PurchasingProcess
{
    public class PurchasingProcess
    {
        public PurchasingProcessModel Model { get; set; }

        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public PurchasingProcess(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {           
            var customerMovie = _mapper.Map<CustomerMovie>(Model);          
            _dbContext.CustomersMovies.Add(customerMovie);
            _dbContext.SaveChanges();                           
        }
    }

    public class PurchasingProcessModel
    {         
        public int CustomerId  { get; set; }
        public int MovieId { get; set; }
    }
}
