using Microsoft.EntityFrameworkCore;
using API_DOTNET.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_DOTNET.Data
{
  public class CriminalCodeMapping : IEntityTypeConfiguration<CriminalCode>
  {
    public void Configure(EntityTypeBuilder<CriminalCode> builder)
    {
      builder.ToTable("tb_criminal_code");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Id).ValueGeneratedOnAdd();
      builder.Property(x => x.Name);
      builder.Property(x => x.Description);
      builder.Property(x => x.Penalty);
      builder.Property(x => x.PrisionTime);
      builder.Property(x => x.CreateDate);
      builder.Property(x => x.UpdateDate);
      builder.HasOne(x => x.Status).WithMany().HasForeignKey(fk => fk.StatusId);
      builder.HasOne(x => x.CreateUser).WithMany().HasForeignKey(fk => fk.CreateUserId);
      builder.HasOne(x => x.UpdateUser).WithMany().HasForeignKey(fk => fk.UpdateUserId);

    }
  }
}