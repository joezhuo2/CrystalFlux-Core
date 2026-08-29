using System.Collections.Generic;
using UnityEngine;

namespace CrystalFlux.Core
{
    public abstract class UpgradeAsset : ScriptableObject
    {
        public string upgradeName;
        /// <summary>Appends human-readable description lines for this upgrade; the owning system decides what to show.</summary>
        public abstract void GetTooltipLines(List<string> lines);
    }
}
