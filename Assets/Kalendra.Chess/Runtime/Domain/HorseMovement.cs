using Kalendra.BoardSystem.Runtime.Domain.Entities;

namespace Kalendra.Chess.Runtime.Domain
{
    internal class HorseMovement
    {
        ChessAvailableMovements availableMovements;
        IBoard board;
        (int x, int y) tileCoords;

        public ChessAvailableMovements ListAvailableMovements(Board board, ITile tile)
        {
            availableMovements = new ChessAvailableMovements();
            this.board = board;
            tileCoords = tile.Coords;
            
            TryToAddCoords(tileCoords.x - 1, tileCoords.y - 2);
            TryToAddCoords(tileCoords.x - 1, tileCoords.y + 2);
            TryToAddCoords(tileCoords.x - 2, tileCoords.y - 1);
            TryToAddCoords(tileCoords.x - 2, tileCoords.y + 1);
            TryToAddCoords(tileCoords.x + 1, tileCoords.y - 2);
            TryToAddCoords(tileCoords.x + 1, tileCoords.y + 2);
            TryToAddCoords(tileCoords.x + 2, tileCoords.y - 1);
            TryToAddCoords(tileCoords.x + 2, tileCoords.y + 1);
            
            return availableMovements;
        }

        void TryToAddCoords(int x, int y)
        {
            if(!board.HasTile(x, y))
                return;
            
            //TODO: other piece? same team?
            
            availableMovements.AddNewTrajectory(board[x, y]);
        }
    }
}