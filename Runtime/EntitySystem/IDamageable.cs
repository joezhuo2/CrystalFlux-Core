using System;
using UnityEngine;

namespace CrystalFlux.Core
{
    public interface IDamageable
    {
        void TakeDamage(DamagePacket packet);
        void TriggerIFrames(float duration);
        bool IsAlive { get; }
        event Action<GameObject> OnDeath;
    }
}
