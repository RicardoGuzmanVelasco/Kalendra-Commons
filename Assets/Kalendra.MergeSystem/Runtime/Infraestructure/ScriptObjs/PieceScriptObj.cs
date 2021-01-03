using Kalendra.Commons.Runtime.Infraestructure.Merge.DataModel;
using Kalendra.MergeSystem.Runtime.Domain.Entities.DataModel;
using UnityEngine;

namespace Kalendra.Commons.Runtime.Infraestructure.Merge.ScriptObjs
{
    [CreateAssetMenu(fileName = "Piece", menuName = "Kalendra/Merge/Piece", order = 0)]
    public class PieceScriptObj : ScriptableObject
    {
        [SerializeField] PieceDataModel dataModel;
        [SerializeField] PieceVisualModel visualModel;

        public static explicit operator PieceDataModel(PieceScriptObj scriptObj) => scriptObj.dataModel;
        public static explicit operator PieceVisualModel(PieceScriptObj scriptObj) => scriptObj.visualModel;
    }
}