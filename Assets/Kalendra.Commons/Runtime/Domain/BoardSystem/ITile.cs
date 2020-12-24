namespace Kalendra.Commons.Runtime.Domain.BoardSystem
{
    public interface ITile
    {
        (int x, int y) Coords { get; }
        ITileContent Content { get; }
    }

    public class NullTile : ITile
    {
        public (int x, int y) Coords { get; }
        public ITileContent Content { get; }
    }
}