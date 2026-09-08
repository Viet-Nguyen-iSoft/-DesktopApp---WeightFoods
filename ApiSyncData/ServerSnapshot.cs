using ApiSyncData.Resp;
using iSoft.Database.Models;

namespace ApiSyncData
{
  internal static class ServerSnapshot
  {
    internal static void Validate<T>(List<T>? rows, int? total) where T : IServerRecord
    {
      if (rows == null || total != rows.Count)
        throw new InvalidOperationException($"{typeof(T).Name}: cần ListData đầy đủ và TotalRecord khớp.");
      var ids = new HashSet<Guid>();
      foreach (var row in rows)
      {
        if (row == null || !row.Id.HasValue || row.Id == Guid.Empty || !ids.Add(row.Id.Value))
          throw new InvalidOperationException($"{typeof(T).Name}: Id thiếu, không hợp lệ hoặc trùng lặp.");
        if (row.IsDelete == true)
          throw new InvalidOperationException($"{typeof(T).Name}: danh sách phải chỉ chứa bản ghi chưa xóa.");
      }
    }

    internal static List<TEntity> Apply<TSource, TEntity>(
      List<TSource> rows, List<TEntity> locals, Action<TSource, TEntity> map,
      CancellationToken token)
      where TSource : IServerRecord
      where TEntity : BaseModel, new()
    {
      var linked = locals.Where(x => x.IdSrc.HasValue && x.IdSrc != Guid.Empty).ToList();
      var byId = linked.ToDictionary(x => x.IdSrc!.Value);
      var ids = new HashSet<Guid>();
      var added = new List<TEntity>();
      foreach (var row in rows)
      {
        token.ThrowIfCancellationRequested();
        var id = row.Id!.Value;
        ids.Add(id);
        if (!byId.TryGetValue(id, out var local))
        {
          local = new TEntity { IdSrc = id };
          byId.Add(id, local);
          added.Add(local);
        }
        map(row, local);
        // PostgreSQL lưu timestamp tới microsecond; chuẩn hóa để EF không nhận
        // phần tick dư là một thay đổi mới trong mọi chu kỳ đồng bộ.
        local.CreatedAt = NormalizeTimestamp(row.CreatedAt);
        local.UpdatedAt = NormalizeTimestamp(row.UpdatedAt);
        local.DeletedFlag = false;
      }
      foreach (var local in linked)
      {
        token.ThrowIfCancellationRequested();
        if (!ids.Contains(local.IdSrc!.Value) && !local.DeletedFlag)
        {
          local.DeletedFlag = true;
          local.UpdatedAt = DateTime.UtcNow;
        }
      }
      return added;
    }

    private static DateTime? NormalizeTimestamp(DateTime? value)
    {
      if (!value.HasValue)
        return null;

      const long ticksPerMicrosecond = 10;
      var dateTime = value.Value;
      var normalizedTicks = dateTime.Ticks - dateTime.Ticks % ticksPerMicrosecond;
      return new DateTime(normalizedTicks, dateTime.Kind);
    }
  }
}
