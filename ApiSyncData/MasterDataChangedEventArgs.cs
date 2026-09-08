namespace ApiSyncData
{
  public sealed class MasterDataChangedEventArgs : EventArgs
  {
    public MasterDataChangedEventArgs(
      Type entityType,
      IReadOnlyList<long> addedIds,
      IReadOnlyList<long> updatedIds,
      IReadOnlyList<long> deletedIds)
    {
      EntityType = entityType;
      AddedIds = addedIds;
      UpdatedIds = updatedIds;
      DeletedIds = deletedIds;
    }

    public Type EntityType { get; }
    public IReadOnlyList<long> AddedIds { get; }
    public IReadOnlyList<long> UpdatedIds { get; }
    public IReadOnlyList<long> DeletedIds { get; }
  }
}
