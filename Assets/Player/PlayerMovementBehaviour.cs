using System;
using UnityEngine;

namespace Player
{
    public class PlayerMovementBehaviour : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float damping;
        
        private Vector2 _vel;
        private Vector2 _accel;
        private void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            _accel = new Vector2(horizontal, vertical) * speed;
            _vel += _accel * Time.deltaTime;
            _vel = Vector2.Lerp(_vel, Vector2.zero, Time.deltaTime);
            transform.Translate(_vel * Time.deltaTime);
        }
    }
}
