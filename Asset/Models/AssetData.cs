namespace Asset.Models
{
    public class AssetData(Guid id, string assetType, int cost)
    {
        public Guid Id { get; } = id;
        public string AssetType { get; } = assetType;
        public int Cost { get; } = cost;
    }
}
