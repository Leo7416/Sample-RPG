using System.Collections;
using UnityEngine;

namespace SampleRPG.Movement
{
    public class PlayerDashController : MonoBehaviour
    {
        [SerializeField]
        private float _dashSpeed;

        [SerializeField]
        private float _dashTime;

        private CharacterMovementController _moveController;

        protected void Start()
        {
            _moveController = GetComponent<CharacterMovementController>();
        }

        protected void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                StartCoroutine(Dash());
            }
        }

        IEnumerator Dash()
        {
            float startTime = Time.time;

            while(Time.time < startTime + _dashTime)
            {
                _moveController.CharacterController.Move(_moveController.MovementDirection * _dashSpeed * Time.deltaTime);

                yield return null;
            }
        }
    }
}