using System;

namespace Kalendra.MergeSystem.Runtime.Domain.Entities.DataModel
{
    [Serializable]
    public class ColorDataModel
    {
        public string colorID;

        public override string ToString() => $"{nameof(colorID)}: {colorID}";
    }
}