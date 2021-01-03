using System.Linq;
using Kalendra.Commons.Runtime.Infraestructure.Merge.DataModel;
using Kalendra.MergeSystem.Runtime.Domain.Entities;
using Kalendra.MergeSystem.Runtime.Domain.Entities.DataModel;
using UnityEngine;

namespace Kalendra.Commons.Runtime.Infraestructure.Merge.ScriptObjs
{
    [CreateAssetMenu(fileName = "Color", menuName = "Kalendra/Merge/Color", order = 0)]
    public class ColorScriptObj : ScriptableObject
    {
        [SerializeField] ColorDataModel dataModel;
        [SerializeField] ColorVisualModel visualModel;

        public ColorDataModel DataModel => dataModel;

        public static implicit operator ColorDataModel(ColorScriptObj obj) => obj.dataModel;
        public static implicit operator ColorVisualModel(ColorScriptObj obj) => obj.visualModel;
    }
    
    [CreateAssetMenu(fileName = "ColorProduction", menuName = "Kalendra/Merge/ColorProduction", order = 0)]
    public class ColorProductionScriptObj : ScriptableObject
    {
        [SerializeField] ColorScriptObj[] originalColors;
        [SerializeField] ColorScriptObj resultColor;

        public static implicit operator ColorProduction(ColorProductionScriptObj obj)
        {
            var originalColorIDs = obj.originalColors.Select(scriptObj => scriptObj.DataModel.colorID);
            var resultColorID = obj.resultColor.DataModel.colorID;
            
            return new ColorProduction(originalColorIDs.ToArray(), resultColorID);
        }
    }
}