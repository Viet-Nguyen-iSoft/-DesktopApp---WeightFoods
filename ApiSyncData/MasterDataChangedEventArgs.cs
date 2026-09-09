namespace ApiSyncData
{
  public sealed class MasterDataChangedEventArgs : EventArgs
  {
    public MasterDataChangedEventArgs(
      Type entityType,
      IReadOnlyList<Guid> addedIds,
      IReadOnlyList<Guid> updatedIds,
      IReadOnlyList<Guid> deletedIds,
      int affectedRows)
    {
      EntityType = entityType;
      AddedIds = addedIds;
      UpdatedIds = updatedIds;
      DeletedIds = deletedIds;
      AffectedRows = affectedRows;
    }

    public Type EntityType { get; }
    public IReadOnlyList<Guid> AddedIds { get; }
    public IReadOnlyList<Guid> UpdatedIds { get; }
    public IReadOnlyList<Guid> DeletedIds { get; }
    public int AffectedRows { get; }
  }
}
