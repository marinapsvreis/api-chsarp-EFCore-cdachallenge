using API_DOTNET.Model;
using API_DOTNET.Data;
using Microsoft.EntityFrameworkCore;
using API_DOTNET.Filters;

namespace API_DOTNET.Repository
{

  public class CriminalCodeRepository : ICriminalCodeRepository
  {

    private readonly ApplicationContext _context;

    public CriminalCodeRepository(ApplicationContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<CriminalCode>> GetCriminalCodes()
    {
      return await _context.CriminalCode.ToListAsync();
    }

    public async Task<CriminalCode> GetCriminalCode(int Id)
    {
      return await _context.CriminalCode.Where(x => x.Id == Id).FirstOrDefaultAsync();
    }

    public void AddCriminalCode(CriminalCode criminalCode)
    {

      _context.Add(criminalCode);
    }

    public void UpdateCriminalCode(CriminalCode criminalCode)
    {
      _context.Update(criminalCode);
    }

    public void DeleteCriminalCode(CriminalCode criminalCode)
    {
      _context.Remove(criminalCode);
    }

    public async Task<bool> SaveChangesAsync()
    {
      return await _context.SaveChangesAsync() > 0;
    }

    public async Task<PagedBaseResponse<CriminalCode>> GetPagedAsync(CriminalCodeFilterDb request)
    {
      var criminalCode = _context.CriminalCode.AsQueryable();
      if (!string.IsNullOrEmpty(request.Name))
      {
        criminalCode = criminalCode.Where(x => x.Name.Contains(request.Name));
      }

      return await PagedBaseResponseHelper
      .GetResponseAsync<PagedBaseResponse<CriminalCode>, CriminalCode>(criminalCode, request);
    }
  }
}