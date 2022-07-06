using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API_DOTNET.View;
using Microsoft.IdentityModel.Tokens;

namespace API_DOTNET.Configurations
{
  public class JwtService : IAuthenticationService
  {
    private readonly IConfiguration _configuration;
    public JwtService(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    public string GerarToken(UserViewOutput userViewOutput)
    {
      var secret = Encoding.ASCII.GetBytes(_configuration.GetSection("JwtConfigurations:Secret").Value);
      var symmetricSecurityKey = new SymmetricSecurityKey(secret);
      var securityTokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new Claim[]
          {
                    new Claim(ClaimTypes.NameIdentifier, userViewOutput.UserId.ToString()),
                    new Claim(ClaimTypes.Name, userViewOutput.UserName)
          }),
        Expires = DateTime.UtcNow.AddDays(1),
        SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
      };
      var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
      var tokenGenerated = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
      var token = jwtSecurityTokenHandler.WriteToken(tokenGenerated);

      return token;
    }
  }
}