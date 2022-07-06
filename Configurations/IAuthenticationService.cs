using API_DOTNET.View;

namespace API_DOTNET.Configurations
{
  public interface IAuthenticationService
  {
    string GerarToken(UserViewOutput userViewOutput);
  }
}