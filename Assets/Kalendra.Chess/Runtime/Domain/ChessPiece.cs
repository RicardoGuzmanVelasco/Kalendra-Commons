﻿using Kalendra.BoardSystem.Runtime.Domain.Entities;

namespace Kalendra.Chess.Runtime.Domain
{
    internal interface IChessPiece : ITileContent
    {
        ChessSet Set { get; }
        ChessAvailableMovements ListAvailableMovements(Board board, ITile tile);
    }

    internal enum ChessSet
    {
        White,
        Black
    }
}