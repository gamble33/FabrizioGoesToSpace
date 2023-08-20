using System;
using UnityEngine;

namespace Camera
{
    public class CameraFollowBehaviour : MonoBehaviour
    {
        [SerializeField] private float damping;
        [SerializeField] private Transform target;

        private Vector3 _velocity = Vector3.zero;

        private void LateUpdate()
        {
            Vector3 cameraPosition = transform.position;
            Vector2 desiredPosition = new Vector2(cameraPosition.x, target.position.y);
            cameraPosition = Vector3.Lerp(
                cameraPosition,
                desiredPosition,
                Time.deltaTime * damping
            );
            cameraPosition.z = -10f;
            transform.position = cameraPosition;
        }
    }
}