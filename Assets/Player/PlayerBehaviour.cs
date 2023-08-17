using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PlayerBehaviour : MonoBehaviour
    {
        public UnityEvent<float> onTakeDamage = new();
        
        private float _health = 100;

        private void OnCollisionEnter2D(Collision2D col)
        {
            Debug.Log("Collision Occured");
            if (col.collider.CompareTag("Enemy"))
            {
                _health -= 25f;
                onTakeDamage.Invoke(_health);
            }
        }
    }
}