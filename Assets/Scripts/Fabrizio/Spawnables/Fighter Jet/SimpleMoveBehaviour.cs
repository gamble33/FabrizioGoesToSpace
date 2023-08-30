using UnityEngine;

namespace Fabrizio.Spawnables.Fighter_Jet
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class SimpleMoveBehaviour : MonoBehaviour
    {
        [SerializeField] private float speed;

        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.velocity = -transform.right * speed;
        }

    }
}