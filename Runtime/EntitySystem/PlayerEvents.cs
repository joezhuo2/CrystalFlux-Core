using System;

namespace CrystalFlux.Core
{
    /// <summary>Player-wide notifications an entity system raises for other systems to observe.</summary>
    public static class PlayerEvents
    {
        public static event Action<IDamageable> OnPlayerTakeDamage;
        public static event Action<IDamageable> OnPlayerDamaged;

        public static void RaisePlayerTakeDamage(IDamageable player) => OnPlayerTakeDamage?.Invoke(player);
        public static void RaisePlayerDamaged(IDamageable player) => OnPlayerDamaged?.Invoke(player);
    }
}
