using UnityEngine;

namespace SampleRPG.Movement
{
    public class PlayerMovementDirectionController : MonoBehaviour, IMovementDirectionSource
    {
        private UnityEngine.Camera _camera;

        public Vector3 MovementDirection { get; private set; }

        protected void Awake()
        {
            _camera = UnityEngine.Camera.main;
        }

        protected void Update()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            var inputDirection = new Vector3(horizontal, 0, vertical);
            if (inputDirection.magnitude > 0.1f)
            {
                Vector3 cameraForward = _camera.transform.forward;
                cameraForward.y = 0;

                Quaternion cameraRotation = Quaternion.LookRotation(cameraForward);
                MovementDirection = cameraRotation * inputDirection.normalized;
            }
            else
            {
                MovementDirection = Vector3.zero;
            }
        }
    }
}