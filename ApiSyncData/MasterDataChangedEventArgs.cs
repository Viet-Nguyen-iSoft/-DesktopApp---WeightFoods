namespace ApiSyncData
{
  public sealed class MasterDataChangedEventArgs : EventArgs
  {
    public MasterDataChangedEventArgs(
      Type entityType,
      IReadOnlyList<long> addedIds,
      IReadOnlyList<long> updatedIds,
      IReadOnlyList<long> deletedIds,
      int affectedRows)
    {
      EntityType = entityType;
      AddedIds = addedIds;
      UpdatedIds = updatedIds;
      DeletedIds = deletedIds;
      AffectedRows = affectedRows;
    }

    public Type EntityType { get; }
    public IReadOnlyList<long> AddedIds { get; }
    public IReadOnlyList<long> UpdatedIds { get; }
    public IReadOnlyList<long> DeletedIds { get; }
    public int AffectedRows { get; }
  }
}
