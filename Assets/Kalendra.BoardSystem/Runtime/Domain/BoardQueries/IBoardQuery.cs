﻿using Kalendra.BoardSystem.Runtime.Domain.Entities;

namespace Kalendra.BoardSystem.Runtime.Domain.BoardQueries
{
    public interface IBoardQuery<out T> where T : IBoardQueryResult 
    {
        T Request(IBoard board);
    }
}