using System;

namespace CrystalFlux.Core
{
    /// <summary>Player-wide notifications an entity system raises for other systems to observe.</summary>
    public static class PlayerEvents
    {
        public static event Action<IDamageable> OnPlayerTakeDamage;

        public static void RaisePlayerTakeDamage(IDamageable player) => OnPlayerTakeDamage?.Invoke(player);
    }
}
