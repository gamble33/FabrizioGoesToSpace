using UnityEngine;

namespace Spawnables
{
    public class SpawnableBehaviour : MonoBehaviour
    {
        void Update()
        {
            if (Mathf.Abs(transform.position.x) > 69f) Destroy(gameObject);
        }
    }
}