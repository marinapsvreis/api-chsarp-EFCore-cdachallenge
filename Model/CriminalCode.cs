namespace API_DOTNET.Model
{
  public class CriminalCode
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Decimal Penalty { get; set; }
    public int PrisionTime { get; set; }
    public int StatusId { get; set; }
    public virtual Status Status { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public int CreateUserId { get; set; }
    public int UpdateUserId { get; set; }
    public virtual User CreateUser { get; set; }
    public virtual User UpdateUser { get; set; }
  }
}