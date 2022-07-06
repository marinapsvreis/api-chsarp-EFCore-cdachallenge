using API_DOTNET.Model;

namespace API_DOTNET.View
{
  public class CriminalCodeViewOutput
  {
    public int CriminalCodeId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Decimal Penalty { get; set; }
    public int PrisionTime { get; set; }
    public int StatusId { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public int CreateUserId { get; set; }
    public int UpdateUserId { get; set; }
  }
}