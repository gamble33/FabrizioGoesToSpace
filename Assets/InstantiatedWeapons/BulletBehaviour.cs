using UnityEngine;
using Object = System.Object;

namespace InstantiatedWeapons
{
    public class BulletBehaviour : MonoBehaviour
    {
        [SerializeField] private float damage;

        private Vector2 _velocity;
        private GameObject _owner;

        public void Init(Vector2 velocity, GameObject owner)
        {
            _velocity = velocity;
            _owner = owner;
            transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
        }
        protected virtual void Update()
        {
            transform.Translate(_velocity * Time.deltaTime, Space.World);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Collision Occured");
            if (other.CompareTag("Entity") && !Object.ReferenceEquals(other.gameObject, _owner))
            {
                other.GetComponent<EntityBehaviour>().TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
