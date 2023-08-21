using UnityEngine;

namespace Spawnables
{
    public class SpawnableBehaviour : MonoBehaviour
    {
        void Update()
        {
            if (Mathf.Abs(transform.position.x) > 45f) Destroy(gameObject);
        }
    }
}