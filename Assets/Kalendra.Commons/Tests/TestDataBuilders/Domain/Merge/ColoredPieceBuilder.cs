﻿using Kalendra.Commons.Runtime.Domain.Merge;
using Kalendra.Commons.Tests.TestDataBuilders.Builders;

namespace Kalendra.Commons.Tests.TestDataBuilders.Domain.Merge
{
    internal class ColoredPieceBuilder : Builder<ColoredPiece>
    {
        int tier;
        string pieceID;
        string colorID;

        #region Fluent API
        public ColoredPieceBuilder WithTier(int tier)
        {
            this.tier = tier;
            return this;
        }

        public ColoredPieceBuilder WithPieceID(string pieceID)
        {
            this.pieceID = pieceID;
            return this;
        }

        public ColoredPieceBuilder WithColorID(string colorID)
        {
            this.colorID = colorID;
            return this;
        }
        #endregion

        #region ObjectMother/FactoryMethods
        public static ColoredPieceBuilder New() => new ColoredPieceBuilder();
        #endregion

        #region Builder implementation
        public override ColoredPiece Build() => new ColoredPiece(tier, pieceID, colorID);
        #endregion
    }
}