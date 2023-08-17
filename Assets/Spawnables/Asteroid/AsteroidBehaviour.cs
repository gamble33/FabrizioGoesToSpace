using UnityEngine;

namespace Spawning
{
    public class AsteroidBehaviour : MonoBehaviour
    {
        
        private void Update()
        {
            transform.Translate(Vector2.left * 5f * Time.deltaTime);
            if (transform.position.x < -45f) Destroy(gameObject);
        }
    }
}