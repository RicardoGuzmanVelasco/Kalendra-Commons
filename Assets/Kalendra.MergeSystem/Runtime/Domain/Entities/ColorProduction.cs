using System.Collections.Generic;
using System.Linq;

namespace Kalendra.MergeSystem.Runtime.Domain.Entities
{
    public class ColorProduction
    {
        public string[] OriginalColors { get; }
        public string ResultColor { get; }

        public ColorProduction(string[] originalColorIDs, string colorResultID)
        {
            OriginalColors = originalColorIDs;
            ResultColor = colorResultID;
        }

        public bool CanProduce(params string[] colorIDs) => CanProduce(colorIDs.ToList());
        public bool CanProduce(IEnumerable<string> colorIDs)
        {
            return colorIDs.All(color => OriginalColors.Contains(color));
        }
    }
}