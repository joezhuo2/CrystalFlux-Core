using UnityEngine;

namespace CrystalFlux.Core
{
    public interface IOrbitRegister
    {
        void RegisterOrbitingProjectile(Projectile p);
        void UnregisterOrbitingProjectile(Projectile p);
        int Count { get; }
    }
}
