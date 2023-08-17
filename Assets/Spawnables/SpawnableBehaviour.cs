using UnityEngine;

namespace Spawnables
{
    public class SpawnableBehaviour : MonoBehaviour
    {
        void Update()
        {
            if (transform.position.x < -45f) Destroy(gameObject);
        }
    }
}