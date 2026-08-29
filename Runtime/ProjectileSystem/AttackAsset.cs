using System.Collections.Generic;
using UnityEngine;

namespace CrystalFlux.Core
{
    public enum AttackType { Basic, Skill, Ultimate, Technique, Additional }

    public abstract class AttackAsset : ScriptableObject
    {
        public AttackType type;

        public abstract bool IsRuntimeCopy { get; }
        public abstract void DeepClone();
        /// <summary>Appends human-readable description lines for this attack; the owning system decides what to show.</summary>
        public abstract void GetTooltipLines(List<string> lines);
    }
}
