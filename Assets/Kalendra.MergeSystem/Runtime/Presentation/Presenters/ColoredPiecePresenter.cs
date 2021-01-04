using Kalendra.Commons.Runtime.Architecture.Boundaries;
using UnityEngine;

public class ColoredPiecePresenter : MonoBehaviour, IBoundaryOutputPort<ColoredPieceDTO>
{
    public void Response(ColoredPieceDTO pieceToDraw)
    {
        //TODO: data from DTO to view 
        Debug.Log(pieceToDraw);
    }
}

public class ColoredPieceDTO : IBoundaryResponseDTO
{
    public int tier;
    public string pieceID;
    public string colorID;

    public override string ToString()
    {
        return $"{nameof(tier)}: {tier}, {nameof(pieceID)}: {pieceID}, {nameof(colorID)}: {colorID}";
    }
}
