using UnityEngine;

namespace Fabrizio.Camera
{
    public class CameraFollowBehaviour : MonoBehaviour
    {
        [SerializeField] private float damping;
        [SerializeField] private Transform target;

        private Vector3 _velocity = Vector3.zero;

        private void LateUpdate()
        {
            Vector3 cameraPosition = transform.position;
            Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, -10f);
            cameraPosition = Vector3.SmoothDamp(
                cameraPosition,
                desiredPosition,
                ref _velocity,
                damping
            );

            cameraPosition.z = -10f;
            transform.position = cameraPosition;
        }
    }
}