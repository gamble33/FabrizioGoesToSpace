using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovementBehaviour : MonoBehaviour
    {
        [SerializeField] private float thrust;
        
        private Rigidbody2D _rb;
        private Vector2 _input;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        
        private void Update()
        {
            _input = GetInput();

            if (transform.position.x > 46f)
            {
                transform.position = new Vector3(-45f, transform.position.y, transform.position.z);
            } else if (transform.position.x < -46f)
            {
                
                transform.position = new Vector3(45f, transform.position.y, transform.position.z);
            }
        }

        private Vector2 GetInput()
        {
            return new Vector2(
                Input.GetAxis("Horizontal"),
                Input.GetAxis("Vertical")
            );
        }

        private void FixedUpdate()
        {
            Vector2 targetVelocity = _input * thrust;
            Vector2 deltaVelocity = targetVelocity - _rb.velocity;
            _rb.AddForce(deltaVelocity);
        }
    }
}
