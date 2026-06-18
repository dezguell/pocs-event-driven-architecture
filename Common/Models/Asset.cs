using System;

namespace Common.Models
{
    public class Asset
    {
        public Guid _id { get; }
        public string _assettype { get; }
        public int _cost { get; }

        public Asset(Guid id, string assettype, int cost)
        {
            _id = id;
            _assettype = assettype;
            _cost = cost;
        }
    }
}