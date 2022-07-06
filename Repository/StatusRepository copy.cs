using API_DOTNET.Model;
using API_DOTNET.Data;
using Microsoft.EntityFrameworkCore;

namespace API_DOTNET.Repository
{
  public class StatusRepository : IStatusRepository
  {

    private readonly ApplicationContext _context;

    public StatusRepository(ApplicationContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<Status>> GetStatuss()
    {
      return await _context.Status.ToListAsync();
    }

    public async Task<Status> GetStatus(int Id)
    {
      return await _context.Status.Where(x => x.Id == Id).FirstOrDefaultAsync();
    }

    public void AddStatus(Status status)
    {
      _context.Add(status);
    }

    public void UpdateStatus(Status status)
    {
      _context.Update(status);
    }

    public void DeleteStatus(Status status)
    {
      _context.Remove(status);
    }

    public async Task<bool> SaveChangesAsync()
    {
      return await _context.SaveChangesAsync() > 0;
    }
  }
}