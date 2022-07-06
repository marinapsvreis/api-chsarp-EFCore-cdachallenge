using API_DOTNET.Filters;
using API_DOTNET.Model;

namespace API_DOTNET.Repository
{
  public interface ICriminalCodeRepository
  {
    Task<IEnumerable<CriminalCode>> GetCriminalCodes();
    Task<PagedBaseRequest> GetPagedAsync(CriminalCodeFilterDb request);
    Task<CriminalCode> GetCriminalCode(int Id);

    void AddCriminalCode(CriminalCode criminalCode);
    void UpdateCriminalCode(CriminalCode criminalCode);
    void DeleteCriminalCode(CriminalCode criminalCode);

    Task<bool> SaveChangesAsync();
  }
}