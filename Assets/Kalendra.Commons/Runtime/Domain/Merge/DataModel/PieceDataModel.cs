using System;

namespace Kalendra.Commons.Runtime.Domain.Merge.DataModel
{
    [Serializable]
    public class PieceDataModel
    {
        public string pieceID;
        public int tier;

        public override string ToString() => $"{nameof(pieceID)}: {pieceID}, {nameof(tier)}: {tier}";
    }
}