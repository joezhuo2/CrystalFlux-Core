using UnityEngine;

namespace CrystalFlux.Core
{
    public enum AttackType { Basic, Skill, Ultimate, Technique, Additional }

    public abstract class AttackAsset : ScriptableObject
    {
        public AttackType type;

        public abstract bool IsRuntimeCopy { get; }
        public abstract void DeepClone();
    }
}
