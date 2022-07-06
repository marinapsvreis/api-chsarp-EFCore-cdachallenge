using API_DOTNET.Repository;

namespace API_DOTNET.Filters
{
  public class CriminalCodeFilterDb : PagedBaseRequest
  {
    public string Name { get; set; }
  }
}