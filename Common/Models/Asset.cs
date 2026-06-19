namespace Common.Models
{
    public class Asset
    {
        public Guid _id { get; }
        public string _assetType { get; }
        public int _cost { get; }

        public Asset(Guid id, string assetType, int cost)
        {
            _id = id;
            _assetType = assetType;
            _cost = cost;
        }
    }
}