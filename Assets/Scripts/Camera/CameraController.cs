using SampleRPG.Scripts;
using System;
using UnityEngine;

namespace SampleRPG.Camera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        private Vector3 _followCameraOffset = new Vector3(0, 5, -10);
        [SerializeField]
        private float _rotationSpeed = 100f;

        [SerializeField]
        private WarriorPlayerCharacter _player;

        private float _currentAngleRotation = 0f;

        protected void Awake()
        {
            if (_player == null)
                throw new NullReferenceException($"Follow camera can't follow null player - {nameof(_player)}");
        }

        protected void LateUpdate()
        {
            HandleCameraRotation();

            Vector3 targetPosition = _player.transform.position + Quaternion.Euler(0, _currentAngleRotation, 0) * _followCameraOffset;
            transform.position = targetPosition;

            transform.LookAt(_player.transform.position + Vector3.up * 1.5f);
        }

        private void HandleCameraRotation()
        {
            float horizontalInput = Input.GetAxis("Mouse X");
            _currentAngleRotation += horizontalInput * _rotationSpeed * Time.deltaTime;
        }
    }
}