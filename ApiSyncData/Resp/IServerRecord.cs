namespace ApiSyncData.Resp
{
  public interface IServerRecord
  {
    Guid? Id { get; }
    DateTime? CreatedAt { get; }
    DateTime? UpdatedAt { get; }
    bool? IsDelete { get; }
  }
}
