using AutoMapper;
using WebApi.Application.TokenOperations.Models;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.CustomerOperations.Commands.CreateToken
{
    public class CreateTokenCommand
    {
        public CreateTokenModel Model { get; set; }
        public int CustomerId { get; set; }

        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;


        public CreateTokenCommand(IMovieStoreDbContext dbContext, IMapper mapper, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _configuration = configuration;
        }

       

        public Token Handle()
        {
            var customer = _dbContext.Customers.FirstOrDefault(x =>x.Email == Model.Email && x.Password == Model.Password);
            if(customer is not null)
            {
                CustomerId = customer.Id;
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(customer);
                customer.RefreshToken = token.RefreshToken;
                customer.RefreshTokenEndDate = token.Expiration.AddMinutes(5);
                _dbContext.SaveChanges();
                return token;
            }
            else
            {
                throw new InvalidOperationException("Kullanici Adi veya Sifre hatali");
            }
                                    
        }
     
    }

    public class CreateTokenModel
    {      
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
