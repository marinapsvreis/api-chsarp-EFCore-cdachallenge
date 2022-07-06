using Microsoft.EntityFrameworkCore;
using API_DOTNET.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_DOTNET.Data
{
  public class UserMapping : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder.ToTable("tb_user");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Id).ValueGeneratedOnAdd();
      builder.Property(x => x.UserName);
      builder.Property(x => x.Password);
    }
  }
}