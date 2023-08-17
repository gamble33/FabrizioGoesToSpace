using UnityEngine;

namespace Spawning
{
    [CreateAssetMenu(fileName = "SpawnableAttributes", menuName = "Spawnables/SpawnableAttributes", order = 1)]
    public class SpawnableAttributes : ScriptableObject
    {
        public new string name;
        
        /// <summary>
        /// If not 0, this spawnable will spawn above or below what the camera can see
        /// </summary>
        public float rangeAboveCameraView;

        /// <summary>
        /// How far this spawnable will spawn past what the camera can see
        /// </summary>
        public float distancePastCamera;

        public int minSpawnAmount;
        public int maxSpawnAmount;

        public GameObject prefab;
    }
}