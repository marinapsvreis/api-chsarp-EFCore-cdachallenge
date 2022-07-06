using API_DOTNET.Model;

namespace API_DOTNET.Repository
{
  public class PagedBaseResponseOutput<T>
  {
    public PagedBaseResponseOutput(int totalRegisters, List<T> data)
    {
      TotalRegisters = totalRegisters;
      Data = data;
    }

    public PagedBaseResponseOutput(int totalRegisters, List<CriminalCode> data)
    {
      TotalRegisters = totalRegisters;
      Data1 = data;
    }

    public int TotalRegisters { get; set; }
    public List<T> Data { get; set; }
    public List<CriminalCode> Data1 { get; }
  }
}