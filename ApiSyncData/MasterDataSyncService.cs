using ApiSyncData.Resp;
using iSoft.Database.DbContexts;
using iSoft.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSyncData
{
  public static class MasterDataSyncService
  {
    private static readonly SemaphoreSlim SyncLock = new(1, 1);

    public static Task SyncCategoryTaresAsync(CategoryTareAPI response, CancellationToken token = default) =>
      SyncAsync<ListDatumCategoryTare, CategoryTare>(response.Data?.ListData, response.Data?.TotalRecord,
        (s, l) => { l.Name = s.Name; l.Description = s.Description; l.Value = s.WeightTare; }, token);

    public static Task SyncStationsAsync(StationAPI response, CancellationToken token = default) =>
      SyncAsync<ListDatumStation, Station>(response.Data?.ListData, response.Data?.TotalRecord,
        (s, l) => { l.Name = s.Name; l.Description = s.Description; }, token);

    public static Task SyncWarehousesAsync(WarehouseAPI response, CancellationToken token = default) =>
      SyncAsync<ListDatumWarehouse, Warehouse>(response.Data?.ListData, response.Data?.TotalRecord,
        (s, l) => { l.Name = s.Name; l.Description = s.Description; }, token);

    public static Task SyncTypeGoodsAsync(TypeGoodsAPI response, CancellationToken token = default) =>
      SyncAsync<ListDatumTypeGoods, TypeGoods>(response.Data?.ListData, response.Data?.TotalRecord,
        (s, l) => { l.Name = s.Name; l.Description = s.Description; }, token);

    public static Task SyncProductGroupsAsync(ProductGroupAPI response, CancellationToken token = default) =>
      SyncAsync<ListDatumProductGroup, ProductGroup>(response.Data?.ListData, response.Data?.TotalRecord,
        (s, l) => { l.Name = s.Name; }, token);

    public static Task SyncClientsAsync(ClientAPI response, CancellationToken token = default) =>
      SyncAsync<ListDatumClient, Client>(response.Data?.ListData, response.Data?.TotalRecord,
        (s, l) => { l.Name = s.Name; l.Description = s.Description; }, token);

    public static Task SyncProductsAsync(ProductAPI response, CancellationToken token = default)
    {
      var groups = new Dictionary<Guid, long>();
      return SyncAsync<ListDatumProduct, Product>(response.Data?.ListData, response.Data?.TotalRecord,
        (s, l) =>
        {
          Guid? groupId = s.ItemProductGroup?.Id;
          if (!string.IsNullOrWhiteSpace(s.ProductGroupId))
          {
            if (!Guid.TryParse(s.ProductGroupId, out var parsed) || parsed == Guid.Empty)
              throw new InvalidOperationException($"Product {s.Id}: ProductGroupId không hợp lệ.");
            if (groupId.HasValue && groupId != parsed)
              throw new InvalidOperationException($"Product {s.Id}: thông tin nhóm không nhất quán.");
            groupId = parsed;
          }
          long? localGroupId = null;
          if (groupId.HasValue)
          {
            if (!groups.TryGetValue(groupId.Value, out var id))
              throw new InvalidOperationException($"Product {s.Id}: chưa đồng bộ nhóm {groupId} vào local.");
            localGroupId = id;
          }
          l.Name = s.Name;
          l.Description = s.Description;
          l.ProductGroupId = localGroupId;
        }, token,
        async db =>
        {
          groups = await db.Set<ProductGroup>()
            .Where(x => x.IdSrc.HasValue && x.IdSrc != Guid.Empty && !x.DeletedFlag)
            .ToDictionaryAsync(x => x.IdSrc!.Value, x => x.Id, token).ConfigureAwait(false);
        });
    }

    private static async Task SyncAsync<TSource, TEntity>(
      List<TSource>? rows, int? total, Action<TSource, TEntity> map,
      CancellationToken token, Func<PostgresDbContext, Task>? prepare = null)
      where TSource : IServerRecord
      where TEntity : BaseModel, new()
    {
      ServerSnapshot.Validate(rows, total);
      await SyncLock.WaitAsync(token).ConfigureAwait(false);
      try
      {
        await using var db = new PostgresDbContext();
        if (prepare != null)
          await prepare(db).ConfigureAwait(false);
        var locals = await db.Set<TEntity>()
          .Where(x => x.IdSrc.HasValue && x.IdSrc != Guid.Empty)
          .ToListAsync(token).ConfigureAwait(false);
        var added = ServerSnapshot.Apply(rows!, locals, map, token);
        db.Set<TEntity>().AddRange(added);
        // Một lần SaveChanges cho cả thêm, cập nhật, xóa mềm; lỗi thì không lưu lượt này.
        await db.SaveChangesAsync(token).ConfigureAwait(false);
      }
      finally
      {
        SyncLock.Release();
      }
    }
  }
}
