using UnityEngine;

namespace CrystalFlux.Core
{
    public interface ISummonTrigger
    {
        bool TrySummon(Vector2 position);
    }
}
