using API_DOTNET.Model;

namespace API_DOTNET.Repository
{
  public interface IStatusRepository
  {
    Task<IEnumerable<Status>> GetStatuss();
    Task<Status> GetStatus(int Id);

    void AddStatus(Status status);
    void UpdateStatus(Status status);
    void DeleteStatus(Status status);

    Task<bool> SaveChangesAsync();
  }
}