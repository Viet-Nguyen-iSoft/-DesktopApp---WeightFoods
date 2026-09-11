using HSF.Database.Entities;
using iSoft.DatabaseServer.Models;
using Microsoft.EntityFrameworkCore;

namespace iSoft.DatabaseServer.DbContexts
{
  public class CommonDbContext : DbContext
  {
    public virtual DbSet<MaterialEntity>? MaterialEntities { get; set; }
    //public virtual DbSet<MaterialEntityTrans>? MaterialTrans { get; set; }

    public virtual DbSet<ProductionOrderEntity>? ProductionOrderEntities { get; set; }
    public virtual DbSet<ProductEntity>? ProductionEntities { get; set; }
    public virtual DbSet<MaterialSettingEntity>? ProductionWeightEntities { get; set; }
    public virtual DbSet<WarningEntity>? WarningEntities { get; set; }
    //public virtual DbSet<ProductionOrderEntityTrans>? ProductionOrderEntityTrans { get; set; }

    public virtual DbSet<LaborProductivityRecognitionEntity>?  LaborProductivityRecognitionEntities { get; set; }
    public virtual DbSet<WeightTicketEntities>? WeightTickets { get; set; }

    public virtual DbSet<FactoryEntity>? FactoryEntities { get; set; }

    public virtual DbSet<MachineEntity>? MachineEntities { get; set; }
    //public virtual DbSet<MaterialEntityTrans>? MaterialEntityTrans { get; set; }

    public virtual DbSet<UserEntity>? EmployeeEntities { get; set; }

    public virtual DbSet<UserGroupEntity>? DepartmentEntities { get; set; }

    public virtual DbSet<ConnectionEntity>? ConnectionEntities { get; set; }
    public virtual DbSet<TareCategoryEntity>? TareCategoryEntities { get; set; }
    public virtual DbSet<MaterialTareEntity>? MaterialTareEntities { get; set; }
    public virtual DbSet<MaterialGroupEntity>? MaterialGroupEntities { get; set; }
    public virtual DbSet<DeliveryScheduleEntity>? DeliveryScheduleEntities { get; set; }
    public virtual DbSet<DeliveryScheduleMaterialEntity>? DeliveryScheduleMaterialEntities { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.ConfigureDateTimeProperties("datetime(6)");

      modelBuilder.Entity<LaborProductivityRecognitionEntity>()
        .HasIndex(record => new
        {
          record.IdSrc,
          record.DataMachineId,
          record.DeletedFlag,
          record.CreatedAt
        })
        .HasDatabaseName("IX_LPR_SourceMachineDate");

      modelBuilder.Entity<LaborProductivityRecognitionEntity>()
        .HasIndex(record => new
        {
          record.DeletedFlag,
          record.WeightTicketId,
          record.DataMachineId
        })
        .HasDatabaseName("IX_LPR_PendingTicket");

      modelBuilder.Entity<WeightTicketEntities>()
        .HasIndex(ticket => new
        {
          ticket.IdSrc,
          ticket.DataMachineId,
          ticket.CreatedAt
        })
        .HasDatabaseName("IX_WeightTickets_SourceMachineDate");

      modelBuilder.Entity<WeightTicketEntities>()
        .HasIndex(ticket => new { ticket.DataMachineId, ticket.DeletedFlag })
        .HasDatabaseName("IX_WeightTickets_MachineActive");

      //modelBuilder.Entity<MaterialEntity>()
      //      .HasMany(e => e.ProductionOrders)
      //      .WithMany(e => e.Materials)
      //      .UsingEntity<Dictionary<string, object>>(
      //          "REF_Material_ProductionOrder",
      //          j => j
      //              .HasOne<ProductionOrderEntity>()
      //              .WithMany()
      //              .HasForeignKey("ProductionOrderId")
      //              .OnDelete(DeleteBehavior.ClientSetNull),
      //          j => j
      //              .HasOne<MaterialEntity>()
      //              .WithMany()
      //              .HasForeignKey("MaterialId")
      //              .OnDelete(DeleteBehavior.ClientSetNull)
      //      );

      modelBuilder.Entity<MaterialEntity>()
           .HasMany(e => e.Productions)
           .WithMany(e => e.Materials)
           .UsingEntity<Dictionary<string, object>>(
               "REF_Product_Material",
               j => j
                   .HasOne<ProductEntity>()
                   .WithMany()
                   .HasForeignKey("ProductId")
                   .OnDelete(DeleteBehavior.ClientSetNull),
               j => j
                   .HasOne<MaterialEntity>()
                   .WithMany()
                   .HasForeignKey("MaterialId")
                   .OnDelete(DeleteBehavior.ClientSetNull)
           );

      modelBuilder.Entity<TareCategoryEntity>()
           .HasMany(e => e.Materials)
           .WithMany(e => e.TareCategories)
           .UsingEntity<Dictionary<string, object>>(
               "REF_Material_TareCategory",
               j => j
                   .HasOne<MaterialEntity>()
                   .WithMany()
                   .HasForeignKey("MaterialId")
                   .OnDelete(DeleteBehavior.ClientSetNull),
               j => j
                   .HasOne<TareCategoryEntity>()
                   .WithMany()
                   .HasForeignKey("TareCategoryId")
                   .OnDelete(DeleteBehavior.ClientSetNull)
           );

      modelBuilder.Entity<ProductEntity>()
           .HasMany(e => e.ProductionOrders)
           .WithMany(e => e.Productions)
           .UsingEntity<Dictionary<string, object>>(
               "REF_Product_ProductionOrder",
               j => j
                   .HasOne<ProductionOrderEntity>()
                   .WithMany()
                   .HasForeignKey("ProductionOrderId")
                   .OnDelete(DeleteBehavior.ClientSetNull),
               j => j
                   .HasOne<ProductEntity>()
                   .WithMany()
                   .HasForeignKey("ProductId")
                   .OnDelete(DeleteBehavior.ClientSetNull)
           );

      modelBuilder.Entity<MaterialEntity>()
          .HasMany(e => e.ProductionOrders)
          .WithMany(e => e.Materials)
          .UsingEntity<Dictionary<string, object>>(
              "REF_ProductionOrder_Material",
              j => j
                  .HasOne<ProductionOrderEntity>()
                  .WithMany()
                  .HasForeignKey("ProductionOrderId")
                  .OnDelete(DeleteBehavior.ClientSetNull),
              j => j
                  .HasOne<MaterialEntity>()
                  .WithMany()
                  .HasForeignKey("MaterialId")
                  .OnDelete(DeleteBehavior.ClientSetNull)
          );

      modelBuilder.Entity<UserEntity>()
           .HasMany(e => e.UserGroups)
           .WithMany(e => e.Users)
           .UsingEntity<Dictionary<string, object>>(
               "REF_User_UserGroup",
               j => j
                   .HasOne<UserGroupEntity>()
                   .WithMany()
                   .HasForeignKey("UserGroupId")
                   .OnDelete(DeleteBehavior.ClientSetNull),
               j => j
                   .HasOne<UserEntity>()
                   .WithMany()
                   .HasForeignKey("UserId")
                   .OnDelete(DeleteBehavior.ClientSetNull)
           );

      modelBuilder.Entity<UserEntity>()
           .HasMany(e => e.Machines)
           .WithMany(e => e.Users)
           .UsingEntity<Dictionary<string, object>>(
               "REF_User_Machine",
               j => j
                   .HasOne<MachineEntity>()
                   .WithMany()
                   .HasForeignKey("MachineId")
                   .OnDelete(DeleteBehavior.ClientSetNull),
               j => j
                   .HasOne<UserEntity>()
                   .WithMany()
                   .HasForeignKey("UserId")
                   .OnDelete(DeleteBehavior.ClientSetNull)
           );


      modelBuilder.Entity<LaborProductivityRecognitionEntity>()
          .HasOne(x => x.Material)
          .WithMany(x => x.Recognitions)
          .HasForeignKey(x => x.MaterialId)
          .OnDelete(DeleteBehavior.Restrict);

      modelBuilder.Entity<LaborProductivityRecognitionEntity>()
          .HasOne(x => x.MaterialLoss)
          .WithMany(x => x.RecognitionLosss)
          .HasForeignKey(x => x.MaterialLossId)
          .OnDelete(DeleteBehavior.Restrict);


      modelBuilder.Entity<MaterialEntity>().Property(e => e.Id).HasDefaultValueSql("(UUID())");
      //modelBuilder.Entity<MaterialEntityTrans>().Property(e => e.Id).HasDefaultValueSql("(UUID())");

      modelBuilder.Entity<ProductionOrderEntity>().Property(e => e.Id).HasDefaultValueSql("(UUID())");

      modelBuilder.Entity<ProductEntity>().Property(e => e.Id).HasDefaultValueSql("(UUID())");

      modelBuilder.Entity<MaterialSettingEntity>().Property(e => e.Id).HasDefaultValueSql("(UUID())");

      modelBuilder.Entity<UserGroupEntity>().Property(e => e.Id).HasDefaultValueSql("(UUID())");

      modelBuilder.Entity<UserEntity>().Property(e => e.Id).HasDefaultValueSql("(UUID())");

      modelBuilder.Entity<LaborProductivityRecognitionEntity>().Property(e => e.Id).HasDefaultValueSql("(UUID())");

      modelBuilder.Entity<WeightTicketEntities>().Property(e => e.Id).HasDefaultValueSql("(UUID())");

      modelBuilder.Entity<FactoryEntity>().Property(e => e.Id).HasDefaultValueSql("(UUID())");

      modelBuilder.Entity<MachineEntity>().Property(e => e.Id).HasDefaultValueSql("(UUID())");

      modelBuilder.Entity<ConnectionEntity>().Property(e => e.Id).HasDefaultValueSql("(UUID())");

      modelBuilder.Entity<TareCategoryEntity>().Property(e => e.Id).HasDefaultValueSql("(UUID())");







      //modelBuilder.Entity<MaterialEntityTrans>()
      //     .HasOne(e => e.Material)
      //     .WithMany(e => e.MaterialEntityTrans)
      //     .HasForeignKey(e => e.BaseId)
      //     .OnDelete(DeleteBehavior.ClientSetNull);

      //modelBuilder.Entity<ProductionOrderEntityTrans>()
      //     .HasOne(e => e.ProductionOrderEntity)
      //     .WithMany(e => e.ProductionOrderEntityTrans)
      //     .HasForeignKey(e => e.BaseId)
      //     .OnDelete(DeleteBehavior.ClientSetNull);

      //modelBuilder.Entity<DepartmentEntityTrans>()
      //     .HasOne(e => e.DepartmentEntity)
      //     .WithMany(e => e.DepartmentEntityTrans)
      //     .HasForeignKey(e => e.BaseId)
      //     .OnDelete(DeleteBehavior.ClientSetNull);

      //modelBuilder.Entity<EmployeeEntityTrans>()
      //    .HasOne(e => e.EmployeeEntity)
      //    .WithMany(e => e.EmployeeEntityTrans)
      //    .HasForeignKey(e => e.BaseId)
      //    .OnDelete(DeleteBehavior.ClientSetNull);

      //modelBuilder.Entity<LaborProductivityRecognitionEntityTrans>()
      //     .HasOne(e => e.LaborProductivityRecognitionEntity)
      //     .WithMany(e => e.LaborProductivityRecognitionEntityTrans)
      //     .HasForeignKey(e => e.BaseId)
      //     .OnDelete(DeleteBehavior.ClientSetNull);

      //modelBuilder.Entity<FactoryEntityTrans>()
      //     .HasOne(e => e.FactoryEntity)
      //     .WithMany(e => e.FactoryEntityTrans)
      //     .HasForeignKey(e => e.BaseId)
      //     .OnDelete(DeleteBehavior.ClientSetNull);

      //modelBuilder.Entity<MachineEntityTrans>()
      //     .HasOne(e => e.MachineEntity)
      //     .WithMany(e => e.MachineEntityTrans)
      //     .HasForeignKey(e => e.BaseId)
      //     .OnDelete(DeleteBehavior.ClientSetNull);


      //Employee
      modelBuilder.Entity<WeightTicketEntities>()
             .HasOne(l => l.UserDeliver)
             .WithMany(u => u.WeightTicketDeliveries)
             .HasForeignKey(l => l.UserDeliverId)
             .OnDelete(DeleteBehavior.Restrict);

      modelBuilder.Entity<WeightTicketEntities>()
         .HasOne(l => l.UserReceive)
         .WithMany(u => u.WeightTicketReceives)
         .HasForeignKey(l => l.UserReceiveId)
         .OnDelete(DeleteBehavior.Restrict);

      modelBuilder.Entity<WeightTicketEntities>()
         .HasOne(l => l.UserQC)
         .WithMany(u => u.WeightTicketQCes)
         .HasForeignKey(l => l.UserQCId)
         .OnDelete(DeleteBehavior.Restrict);
    }




  }
}
