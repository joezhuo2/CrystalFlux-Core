using System;
using UnityEngine;

namespace CrystalFlux.Core
{
    /// <summary>Spawn hook an entity system registers so other systems can spawn enemies without referencing it.</summary>
    public static class EnemySpawning
    {
        public static Func<GameObject, Vector2, float, int, GameObject> Spawn;

        public static GameObject SpawnEnemy(GameObject prefab, Vector2 location, float radius, int level)
            => Spawn?.Invoke(prefab, location, radius, level);
    }
}
