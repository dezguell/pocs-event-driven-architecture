namespace Asset.Models
{
    public class AssetData
    {
        public Guid Id { get; }
        public string AssetType { get; }
        public int Cost { get; }

        public AssetData(Guid id, string assetType, int cost)
        {
            Id = id;
            AssetType = assetType;
            Cost = cost;
        }
    }
}
