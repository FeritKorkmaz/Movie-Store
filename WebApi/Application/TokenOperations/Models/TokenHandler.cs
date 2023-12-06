using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using WebApi.Entities;

namespace WebApi.Application.TokenOperations.Models
{
    public class TokenHandler
    {

        public IConfiguration Configuration { get; set; }
        public TokenHandler(IConfiguration configuration)
        {
            Configuration = configuration;
        }

 public Token CreateAccessToken(Customer customer)
{
    Token tokenmodel = new Token();

    SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"]));
    SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
    tokenmodel.Expiration = DateTime.Now.AddMinutes(15);

    var tokenDescriptor = new SecurityTokenDescriptor
    {
        Subject = new ClaimsIdentity(new[]
        {
            new Claim("userId", customer.Id.ToString()), // customer.Id kullanıcı kimliğidir
            // Diğer claim'ler...
        }),
        Expires = tokenmodel.Expiration,
        SigningCredentials = signingCredentials,
        Audience = Configuration["Token:Audience"],
        Issuer = Configuration["Token:Issuer"],
        NotBefore = DateTime.Now
    };

    JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
    JwtSecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor) as JwtSecurityToken;

    // Token Uretiliyor
    tokenmodel.AccessToken = tokenHandler.WriteToken(securityToken);
    tokenmodel.RefreshToken = CreateRefreshToken();
    return tokenmodel;
}



        public string CreateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }

 
     
    }
   
}