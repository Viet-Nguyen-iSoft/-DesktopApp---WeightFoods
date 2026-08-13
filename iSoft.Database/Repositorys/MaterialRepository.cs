using iSoft.Database.DbContexts;
using iSoft.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iSoft.Database.EnumData;

namespace iSoft.Database.Repositorys
{
  public class MaterialRepository : GenericRepository<Material, CommonDbContext>
  {
    public MaterialRepository(DbContext context) : base(context)
    {

    }

    public async Task<List<Material>> GetAllAsync(bool isContainDelete = false)
    {
      if (isContainDelete)
      {
        return await this.Context.Set<Material>().AsNoTracking()
              .ToListAsync();
      }
      else
      {
        return await this.Context.Set<Material>().AsNoTracking()
              .Where(e => !e.DeletedFlag)
              .ToListAsync();
      }   
    }
    public async Task<List<Material>> GetAllAsync(EnumMaterialType eMaterialType)
    {
      if (eMaterialType == EnumMaterialType.None)
      {
        return await this.Context.Set<Material>().AsNoTracking()
              .Where(e => !e.DeletedFlag)
              .ToListAsync();
      }
      else
      {
        return await this.Context.Set<Material>().AsNoTracking()
              .Where(e => !e.DeletedFlag && e.MaterialType == (int)eMaterialType)
              .ToListAsync();
      }
    }

    

    public async Task<List<Material>> GetMaterialsDefectAsync(Material material, int type)
    {
      if (!string.IsNullOrEmpty(material.Group))
      {
        return await this.Context.Set<Material>().AsNoTracking()
              .Where(x => x.Group == material.Group && x.MaterialType == type && x.DeletedFlag == false)
              .ToListAsync();
      }
      return new List<Material>();
    }

    public async Task<Material?> GetMaterialsByIdSrcAsync(Guid? guid)
    {
      return await this.Context.Set<Material>().AsNoTracking()
                     .Where(x => x.IdSrc == guid)
                     .FirstOrDefaultAsync();
    }

    public async Task<Material?> GetMaterialsByIdAsync(long? id)
    {
      return await this.Context.Set<Material>().AsNoTracking()
                     .Where(x => x.Id == id)
                     .FirstOrDefaultAsync();
    }



    public async Task<Material?> GetAllCategoryTareByMaterialAsync(Material material)
    {
      try
      {
        return await this.Context.Set<Material>().AsNoTracking()
              .Where(x => x.Id == material.Id)
              .Include(x => x.CategoryTares).Where(x => x.DeletedFlag == false)
              .FirstOrDefaultAsync();
      }
      catch (Exception)
      {
        throw;
      }
    }

    public async Task<List<Material>> GetMaterialTaresAsync()
    {
      return await this.Context.Set<Material>().AsNoTracking()
              .Where(e => e.DeletedFlag == false && e.TareFlag == true && e.ValueTare > 0)
              .ToListAsync();
    }

    public async Task UpdateMaterial(Material material)
    {
      try
      {
        var rs = await this.Context.Set<Material>()
                                    .FirstOrDefaultAsync(x => x.Id == material.Id);
        if (rs != null)
        {
          rs.MaterialGroupId = material.MaterialGroupId;

          await Context.Database.EnsureCreatedAsync();
          await Context.Database.BeginTransactionAsync();
          Context.Set<Material>().UpdateRange(rs);
          await Context.SaveChangesAsync();
          Context.Database.CommitTransaction();
        }
      }
      catch (Exception)
      {
        Context.Database.RollbackTransaction();
        throw;
      }
    }

    public async Task UpdateMaterials(List<Material> materials)
    {
      if (materials is null || materials.Count == 0)
        return;

      // Tránh trùng Id
      var updateDict = materials
          .GroupBy(x => x.Id)
          .ToDictionary(
              group => group.Key,
              group => group.Last().MaterialGroupId
          );

      var materialIds = updateDict.Keys.ToList();

      // Chỉ query database một lần
      var entities = await Context.Set<Material>()
          .Where(x => materialIds.Contains(x.Id))
          .ToListAsync();

      foreach (var entity in entities)
      {
        var newMaterialGroupId = updateDict[entity.Id];

        if (entity.MaterialGroupId != newMaterialGroupId)
        {
          entity.MaterialGroupId = newMaterialGroupId;
        }
      }

      // SaveChanges tự tạo transaction
      await Context.SaveChangesAsync();
    }
  }
}
