using UnityEngine;

namespace CrystalFlux.Core
{
    public interface IKnockbackable
    {
        void ApplyKnockback(Vector2 direction, float force, float duration);
    }
}
