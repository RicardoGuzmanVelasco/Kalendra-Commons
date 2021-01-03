using System;

namespace Kalendra.MergeSystem.Runtime.Domain.Entities.DataModel
{
    [Serializable]
    public class PieceDataModel
    {
        public string pieceID;
        public int tier;

        public override string ToString() => $"{nameof(pieceID)}: {pieceID}, {nameof(tier)}: {tier}";
    }
}