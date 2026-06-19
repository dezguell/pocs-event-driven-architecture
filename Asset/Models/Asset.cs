namespace Asset.Models
{
    public class Asset
    {
        public Guid Id { get; }
        public string AssetType { get; }
        public int Cost { get; }

        public Asset(Guid id, string assetType, int cost)
        {
            Id = id;
            AssetType = assetType;
            Cost = cost;
        }
    }
}
