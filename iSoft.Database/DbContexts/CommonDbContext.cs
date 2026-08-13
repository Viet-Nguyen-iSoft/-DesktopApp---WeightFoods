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
    public virtual DbSet<Material>? Materials { get; set; }
    public virtual DbSet<ProductionOrder>? ProductionOrders { get; set; }
    public virtual DbSet<Production>? Productions { get; set; }
    public virtual DbSet<MaterialSetting>? MaterialSettings { get; set; }
    public virtual DbSet<DatalogWeight>?  DatalogWeights { get; set; }
    public virtual DbSet<DatalogDelivery>? DatalogDeliveries { get; set; }
    public virtual DbSet<CategoryTare>? CategoryTares { get; set; }

    public virtual DbSet<Factory>? Factories { get; set; }
    public virtual DbSet<Machine>? Machines { get; set; }

    public virtual DbSet<Connection>? Connections { get; set; }

    public virtual DbSet<Employee>? Employees { get; set; }
    public virtual DbSet<Department>? Departments { get; set; }

    public virtual DbSet<Warning>? Warnings { get; set; }

    public virtual DbSet<AppConfig>? AppConfigs { get; set; }
    public virtual DbSet<LogAction>? LogActions { get; set; }

    public virtual DbSet<SettingLabel>? SettingLabels { get; set; }
    public virtual DbSet<MaterialTare>? MaterialTares { get; set; }
    public virtual DbSet<MaterialGroup>? MaterialGroups { get; set; }
    public virtual DbSet<DeliverySchedule>? DeliverySchedules { get; set; }
    public virtual DbSet<DeliveryScheduleMaterial>? DeliveryScheduleMaterials { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      //foreach (var entityType in modelBuilder.Model.GetEntityTypes())
      //{
      //  foreach (var property in entityType.GetProperties()
      //               .Where(p => p.ClrType == typeof(DateTime) || p.ClrType == typeof(DateTime?)))
      //  {
      //    property.SetValueConverter(new ValueConverter<DateTime, DateTime>(
      //        v => v.Kind == DateTimeKind.Utc ? v : v.ToUniversalTime(),
      //        v => DateTime.SpecifyKind(v, DateTimeKind.Utc)));
      //  }
      //}
      modelBuilder.HasPostgresExtension("unaccent");
      modelBuilder.ConfigureDateTimeProperties("timestamp with time zone");

      AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);



      ////ProductionOrder <->Material(N - N)
      //modelBuilder.Entity<ProductionOrder>()
      //    .HasMany(p => p.Materials)
      //    .WithMany(m => m.ProductionOrders)
      //    .UsingEntity(j => j.ToTable("ProductionOrderMaterials"));

      //ProductionOrder <->Productions(N - N)
      modelBuilder.Entity<ProductionOrder>()
          .HasMany(p => p.Productions)
          .WithMany(m => m.ProductionOrders)
          .UsingEntity(j => j.ToTable("REF_ProductionOrder_Production"));

      //ProductionOrder <->Material(N - N)
      modelBuilder.Entity<ProductionOrder>()
          .HasMany(p => p.Materials)
          .WithMany(m => m.ProductionOrders)
          .UsingEntity(j => j.ToTable("REF_ProductionOrder_Material"));

      //ProductionOrder <->Productions(N - N)
      modelBuilder.Entity<Production>()
          .HasMany(p => p.Materials)
          .WithMany(m => m.Productions)
          .UsingEntity(j => j.ToTable("REF_Production_Material"));

      //ProductionOrder <->Productions(N - N)
      //modelBuilder.Entity<Department>()
      //    .HasMany(p => p.Employees)
      //    .WithMany(m => m.Departments)
      //    .UsingEntity(j => j.ToTable("REF_Department_Employee"));
      modelBuilder.Entity<Employee>()
         .HasMany(p => p.Departments)
         .WithMany(m => m.Employees)
         .UsingEntity(j => j.ToTable("REF_Employee_Department"));

      //Employee <-> Machine(N - N)
      modelBuilder.Entity<Employee>()
          .HasMany(p => p.Machines)
          .WithMany(m => m.Employees)
          .UsingEntity(j => j.ToTable("REF_Employee_Machine"));

      //Material <->CategoryTare(N - N)
      modelBuilder.Entity<Material>()
          .HasMany(p => p.CategoryTares)
          .WithMany(m => m.Materials)
          .UsingEntity(j => j.ToTable("REF_Material_CategoryTare"));


      //Employee
      modelBuilder.Entity<DatalogDelivery>()
             .HasOne(l => l.EmployeeDeliver)
             .WithMany(u => u.DatalogDeliveries)
             .HasForeignKey(l => l.EmployeeDeliverId)
             .OnDelete(DeleteBehavior.Restrict);

      modelBuilder.Entity<DatalogDelivery>()
         .HasOne(l => l.EmployeeReceive)
         .WithMany(u => u.DatalogReceives)
         .HasForeignKey(l => l.EmployeeReceiveId)
         .OnDelete(DeleteBehavior.Restrict);

      modelBuilder.Entity<DatalogDelivery>()
         .HasOne(l => l.EmployeeQC)
         .WithMany(u => u.DatalogQCes)
         .HasForeignKey(l => l.EmployeeQCId)
         .OnDelete(DeleteBehavior.Restrict);





      modelBuilder.Entity<DatalogWeight>()
        .HasOne(x => x.Material)
        .WithMany(x => x.DatalogWeights)
        .HasForeignKey(x => x.MaterialId)
        .OnDelete(DeleteBehavior.Restrict);

      modelBuilder.Entity<DatalogWeight>()
          .HasOne(x => x.MaterialDefect)
          .WithMany(x => x.DatalogWeightDefects)
          .HasForeignKey(x => x.MaterialDefectId)
          .OnDelete(DeleteBehavior.Restrict);


      //// ProductionOrder <-> RawMaterial (N-N)
      //modelBuilder.Entity<ProductionOrder>()
      //    .HasMany(p => p.RawMaterials)
      //    .WithMany(r => r.ProductionOrders)
      //    .UsingEntity(j => j.ToTable("ProductionOrderRawMaterials"));

      //  // N-N: ProductionOrder <-> Material
      //  modelBuilder.Entity<ProductionOrder>()
      //      .HasMany(p => p.Materials)
      //      .WithMany(m => m.ProductionOrders)
      //      .UsingEntity(j => j.ToTable("ProductionOrderMaterials"));

      //  // N-N: ProductionOrder <-> RawMaterial
      //  modelBuilder.Entity<ProductionOrder>()
      //      .HasMany(p => p.RawMaterials)
      //      .WithMany(r => r.ProductionOrders)
      //      .UsingEntity(j => j.ToTable("ProductionOrderRawMaterials"));

      //  // Record -> ProductionOrder
      //  modelBuilder.Entity<LaborProductivityRecognition>()
      //      .HasOne(r => r.ProductionOrder)
      //      .WithMany(p => p.Records)
      //      .HasForeignKey(r => r.ProductionOrderId);

      //  // Record -> Material
      //  modelBuilder.Entity<LaborProductivityRecognition>()
      //      .HasOne(r => r.Material)
      //      .WithMany(m => m.Records)
      //      .HasForeignKey(r => r.MaterialId)
      //      .OnDelete(DeleteBehavior.Restrict);

      //  // Record -> RawMaterial
      //  modelBuilder.Entity<LaborProductivityRecognition>()
      //      .HasOne(r => r.RawMaterial)
      //      .WithMany(rm => rm.Records)
      //      .HasForeignKey(r => r.RawMaterialId)
      //      .OnDelete(DeleteBehavior.Restrict);


      //  modelBuilder.Entity<DatalogWeight>()
      //.HasOne(x => x.Material)
      //.WithMany(x => x.MaterialSettings)
      //.HasForeignKey(x => x.MaterialId)
      //.OnDelete(DeleteBehavior.Restrict);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
     
    }
  }
}
