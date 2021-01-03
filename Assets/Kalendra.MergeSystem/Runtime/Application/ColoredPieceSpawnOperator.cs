using System.Threading.Tasks;
using Kalendra.Commons.Runtime.Application.BoardSystem;
using Kalendra.Commons.Runtime.Architecture.Gateways;
using Kalendra.Commons.Runtime.Architecture.Services;
using Kalendra.Commons.Runtime.Domain.BoardSystem;
using Kalendra.Commons.Runtime.Domain.Merge;
using Kalendra.Commons.Runtime.Domain.Merge.DataModel;

namespace Kalendra.Commons.Runtime.Application.Merge
{
    /// <summary>
    /// Policy:
    /// Selects a random empty tile from board.
    /// Spawns a <see cref="ColoredPieceTileContent"/> with tier 1, random piece and color.
    /// </summary>
    public class ColoredPieceSpawnOperator : ISpawnOperatorPolicy
    {
        readonly IRandomService randomService;
        readonly IReadOnlyRepository<ColorDataModel> colorsGateway;
        readonly IReadOnlyRepository<PieceDataModel> piecesGateway;

        public ColoredPieceSpawnOperator(IRandomService randomService, IReadOnlyRepository<ColorDataModel> colorsGateway, IReadOnlyRepository<PieceDataModel> piecesGateway)
        {
            this.randomService = randomService;
            this.colorsGateway = colorsGateway;
            this.piecesGateway = piecesGateway;
        }

        #region ISpawnOperatorPolicy implementation
        public ITile SelectTileWhereSpawn(IBoard board)
        {
            var (x, y) = SelectRandomTileWhereSpawn(board);
            return board.GetTile(x, y);
        }

        public async Task<ITileContent> SpawnContent()
        {
            const int tier = 1;
            var piece = await SelectRandomPiece();
            var color = await SelectRandomColor();

            var coloredPiece = new ColoredPiece(tier, piece.pieceID, color.colorID);

            return new ColoredPieceTileContent(coloredPiece);
        }
        #endregion
        
        #region Random selection
        (int, int) SelectRandomTileWhereSpawn(IBoard board)
        {
            return randomService.GetRandom(board.ListAllEmptyTiles);
        }

        async Task<ColorDataModel> SelectRandomColor()
        {
            var allColors = await colorsGateway.LoadAll();
            return randomService.GetRandom(allColors);
        }

        async Task<PieceDataModel> SelectRandomPiece()
        {
            var allPieces = await piecesGateway.LoadAll();
            return randomService.GetRandom(allPieces);
        }
        #endregion
    }
}