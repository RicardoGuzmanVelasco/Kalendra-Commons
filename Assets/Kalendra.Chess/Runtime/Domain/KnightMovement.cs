using Kalendra.BoardSystem.Runtime.Domain.Entities;

namespace Kalendra.Chess.Runtime.Domain
{
    internal class KnightMovement : IChessMovementStrategy
    {
        ChessAvailableMovements availableMovements;
        IBoard board;
        (int x, int y) tileCoords;

        public ChessAvailableMovements ListAvailableMovements(IBoard board, ITile tile)
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

            if(CoordsAreOccupiedBySameChessSet(x, y))
                return;

            availableMovements.AddNewTrajectory(board[x, y]);
        }

        bool CoordsAreOccupiedBySameChessSet(int x, int y)
        {
            //TODO: da problemas si selfPiece es nula (no está metida en el tablero).
            return board[x, y].Content is IChessPiece targetPiece &&
                   board[tileCoords.x, tileCoords.y].Content is IChessPiece selfPiece &&
                   targetPiece.Set == selfPiece.Set;
        }
    }
}