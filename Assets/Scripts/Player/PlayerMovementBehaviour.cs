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
        private Vector2 _targetVelocity;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        
        private void Update()
        {
            _input = GetInput();
            _targetVelocity = _input * thrust;
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
            Vector2 deltaVelocity = _targetVelocity - _rb.velocity;
            _rb.AddForce(deltaVelocity);
        }
    }
}
