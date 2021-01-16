﻿using Kalendra.BoardSystem.Runtime.Domain.Entities;

namespace Kalendra.Chess.Runtime.Domain
{
    public interface IChessMovementStrategy
    {
        ChessAvailableMovements ListAvailableMovements(IBoard board, ITile tile);
    }
}