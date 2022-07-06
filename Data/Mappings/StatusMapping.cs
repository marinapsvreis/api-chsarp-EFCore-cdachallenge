using Microsoft.EntityFrameworkCore;
using API_DOTNET.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_DOTNET.Data
{
  public class StatusMapping : IEntityTypeConfiguration<Status>
  {
    public void Configure(EntityTypeBuilder<Status> builder)
    {
      builder.ToTable("tb_status");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Id).ValueGeneratedOnAdd();
      builder.Property(x => x.Name);
    }
  }
}