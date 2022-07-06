using API_DOTNET.Model;

namespace API_DOTNET.Repository
{
  public interface IUserRepository
  {
    void Adicionar(User user);
    void Commit();
    Task<User> ObterAsync(string userName);
  }
}