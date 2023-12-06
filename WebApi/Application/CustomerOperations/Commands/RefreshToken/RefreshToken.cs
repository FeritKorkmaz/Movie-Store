using WebApi.Application.TokenOperations.Models;
using WebApi.DBOperations;

namespace WebApi.Application.CustomerOperations.Commands.RefreshToken
{
    public class RefreshTokenCommand
    {
        public string RefreshToken { get; set; }
        private readonly IMovieStoreDbContext _dbContext;      
        private readonly IConfiguration _configuration;
        public RefreshTokenCommand(IMovieStoreDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var customer = _dbContext.Customers.FirstOrDefault(x => x.RefreshToken == RefreshToken && x.RefreshTokenEndDate > DateTime.Now);
            if (customer != null)
            {
                TokenHandler tokenHandler = new TokenHandler(_configuration);
                Token token = tokenHandler.CreateAccessToken(customer);

                customer.RefreshToken = token.RefreshToken;
                customer.RefreshTokenEndDate = token.Expiration.AddMinutes(5);
                _dbContext.SaveChanges();

                return token;
            }
            else
            {
                throw new InvalidOperationException("Valid bir refresh token bulunamadi");
            }

        }
    }
}