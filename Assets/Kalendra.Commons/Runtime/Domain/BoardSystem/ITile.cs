namespace Kalendra.Commons.Runtime.Domain.BoardSystem
{
    public interface ITile
    {
    }

    internal class BoardTile : ITile
    {
        public BoardTile(int coordX, int coordY)
        {
            
        }
    }

    public class NullTile : ITile
    {
    }
}