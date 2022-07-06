using API_DOTNET.Model;
using API_DOTNET.Data;
using Microsoft.EntityFrameworkCore;

namespace API_DOTNET.Repository
{
  public class UserRepository : IUserRepository
  {
    private readonly ApplicationContext _context;

    public UserRepository(ApplicationContext context)
    {
      _context = context;
    }
    public void Adicionar(User user)
    {
      _context.User.Add(user);
    }

    public void Commit()
    {
      _context.SaveChanges();
    }

    public async Task<User> ObterAsync(string userName)
    {
      var teste = await _context.User.FirstOrDefaultAsync(u => u.UserName == userName);
      return teste;
    }
  }
}