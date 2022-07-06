using API_DOTNET.Data;
using API_DOTNET.Model;

using Microsoft.EntityFrameworkCore;

namespace API_DOTNET.Data
{
  public class ApplicationContext : DbContext
  {
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new UserMapping());
      modelBuilder.ApplyConfiguration(new CriminalCodeMapping());
      modelBuilder.ApplyConfiguration(new StatusMapping());
      base.OnModelCreating(modelBuilder);
    }

    public DbSet<User> User { get; set; }
    public DbSet<CriminalCode> CriminalCode { get; set; }
    public DbSet<Status> Status { get; set; }
  }
}
