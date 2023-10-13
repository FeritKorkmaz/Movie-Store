using WebApi.DBOperations;
namespace WebApi.Application.CustomerOperations.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand
    {
        public int CustomerId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;

        public DeleteCustomerCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var customer = _dbContext.Customers.SingleOrDefault(x => x.Id == CustomerId);
            if (customer is null)
            {
                throw new InvalidOperationException("Musteri bulunamadi");
            }
            _dbContext.Customers.Remove(customer);
            _dbContext.SaveChanges();
        }

    }
}