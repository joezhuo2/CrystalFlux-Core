using System.Collections.Generic;
using UnityEngine;

namespace CrystalFlux.Core
{
    public class DamagePacket
    {
        private const int InstanceCapacity = 3;
        private const int MaxPooled = 64;
        private static readonly Stack<DamagePacket> pool = new();

        public List<DamageInstance> instances = new(InstanceCapacity);
        public GameObject source;
        public bool bypassIFrames = false;
        public float sizeOverride = 1f;
        private bool pooled;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void ResetPool() => pool.Clear();

        public static DamagePacket Get(GameObject source, bool bypassIFrames, float sizeOverride)
        {
            DamagePacket dp = pool.Count > 0 ? pool.Pop() : new DamagePacket();
            dp.pooled = false;
            dp.instances ??= new(InstanceCapacity);
            dp.source = source;
            dp.bypassIFrames = bypassIFrames;
            dp.sizeOverride = sizeOverride;
            return dp;
        }

        public static void Release(DamagePacket dp)
        {
            if (dp == null || dp.pooled) return;

            dp.instances?.Clear();
            dp.source = null;
            dp.bypassIFrames = false;
            dp.sizeOverride = 1f;

            if (pool.Count >= MaxPooled) return;

            dp.pooled = true;
            pool.Push(dp);
        }

        public void AddInstance(DamageType type, float amount, bool isCrit, GameObject owner)
            => instances.Add(new DamageInstance(type, amount, isCrit, default, owner));

        public void AddInstance(DamageType type, float amount, bool isCrit, Color indicatorColor, GameObject owner)
            => instances.Add(new DamageInstance(type, amount, isCrit, indicatorColor, owner));

        public float GetTotalDamage()
        {
            float total = 0f;
            foreach (var i in instances)
                total += i.amount;
            return total;
        }
    }
}
