using UnityEngine;

namespace Fabrizio.ShipEditor.Camera
{
    public class CameraControls : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float sensitivity;
        [SerializeField] private float scrollSpeed;

        private Vector2 _rotation;
        private float _distanceFromTarget = 10f;
        

        private void Update()
        {
            Vector2 mouseInput = new Vector2(
                Input.GetAxis("Mouse X"),
                Input.GetAxis("Mouse Y")
            );

            float scroll = Input.GetAxis("Mouse ScrollWheel");
            _distanceFromTarget += -scroll * scrollSpeed * Time.deltaTime;

            if (Input.GetKey(KeyCode.Mouse1))
                _rotation += mouseInput * sensitivity * Time.deltaTime;
            
            transform.localEulerAngles = new Vector3(-_rotation.y, _rotation.x, 0f);
            transform.position = target.position - transform.forward * _distanceFromTarget;
        }
    }
}