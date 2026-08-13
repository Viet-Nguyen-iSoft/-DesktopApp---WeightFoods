using iSoft.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace iSoft.Database.DbContexts
{
  public class CommonDbContext : DbContext
  {
    public virtual DbSet<ProductGroup>? MaterialGroups { get; set; }
    public virtual DbSet<Product>? Products { get; set; }
    public virtual DbSet<CategoryTare>? CategoryTares { get; set; }


    public virtual DbSet<Employee>? Employees { get; set; }
    public virtual DbSet<Department>? Departments { get; set; }


    public virtual DbSet<RecordFoods>?  RecordFoods { get; set; }
    
    public virtual DbSet<Station>? Machines { get; set; }
    public virtual DbSet<Connection>? Connections { get; set; }
    public virtual DbSet<AppConfig>? AppConfigs { get; set; }
    public virtual DbSet<LogAction>? LogActions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.HasPostgresExtension("unaccent");
      modelBuilder.ConfigureDateTimeProperties("timestamp with time zone");

      AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
     
    }
  }
}
