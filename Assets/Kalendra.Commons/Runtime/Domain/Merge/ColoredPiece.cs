namespace Kalendra.Commons.Runtime.Domain.Merge
{
    public class ColoredPiece
    {
        public int Tier { get; }
        public string PieceID { get; }
        public string ColorID { get; }

        public ColoredPiece(int tier, string pieceID, string colorID)
        {
            Tier = tier;
            PieceID = pieceID;
            ColorID = colorID;
        }

        public override bool Equals(object obj)
        {
            return obj is ColoredPiece other &&
                   Tier == other.Tier &&
                   PieceID == other.PieceID &&
                   ColorID == other.ColorID;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Tier;
                hashCode = (hashCode * 397) ^ (PieceID != null ? PieceID.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ColorID != null ? ColorID.GetHashCode() : 0);
                return hashCode;
            }
        }
    }

    public class NullColoredPiece : ColoredPiece
    {
        public NullColoredPiece() : base(0, "", "") { }
    }
}