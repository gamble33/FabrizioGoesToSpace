using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullet
{
    public class BulletBehaviour : MonoBehaviour
    {
        [SerializeField] private float speed;
        void Update()
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            if (transform.position.x > 42f) Destroy(gameObject);
        }
    }
}
