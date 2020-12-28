﻿using System;

namespace Kalendra.Commons.Runtime.Domain.Merge.DataModel
{
    [Serializable]
    public class ColorDataModel
    {
        public string colorID;

        public override string ToString() => $"{nameof(colorID)}: {colorID}";
    }
}