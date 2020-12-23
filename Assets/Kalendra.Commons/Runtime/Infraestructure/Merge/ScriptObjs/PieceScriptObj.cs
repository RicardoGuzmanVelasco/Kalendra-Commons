using Kalendra.Commons.Runtime.Domain.Merge.DataModel;
using Kalendra.Commons.Runtime.Infraestructure.Merge.DataModel;
using UnityEngine;

namespace Kalendra.Commons.Runtime.Infraestructure.Merge.ScriptObjs
{
    [CreateAssetMenu(fileName = "Piece", menuName = "Kalendra/Merge/Piece", order = 0)]
    public class PieceScriptObj : ScriptableObject
    {
        [SerializeField] PieceDataModel dataModel;
        [SerializeField] PieceVisualModel visualModel;

        public static implicit operator PieceDataModel(PieceScriptObj scriptObj) => scriptObj.dataModel;
        public static implicit operator PieceVisualModel(PieceScriptObj scriptObj) => scriptObj.visualModel;
    }
}