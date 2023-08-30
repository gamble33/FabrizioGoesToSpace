using UnityEngine;

namespace Fabrizio.Entity
{
    public class EntityBehaviour : MonoBehaviour
    {
        [SerializeField] private float maxHealth;
        protected float Health;

        public virtual void TakeDamage(float amount)
        {
            Health -= amount;
            if (Health <= 0) Die();
        }

        protected virtual void Die()
        {
            Destroy(gameObject);       
        }

        private void Awake()
        {
            Health = maxHealth;
        }
    }
}
