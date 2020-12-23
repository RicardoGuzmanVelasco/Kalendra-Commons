using System;
using UnityEngine;

namespace Kalendra.Commons.Runtime.Infraestructure.Merge.DataModel
{
    [Serializable]
    public class PieceVisualModel
    {
        public string name; //TODO: LocalizedString.
        public Sprite sprite;
    }
    
    [Serializable]
    public class ColorVisualModel
    {
        public Color color;
    }
}