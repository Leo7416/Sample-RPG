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

        [SerializeField]
        private float _dashCooldown;

        private CharacterMovementController _moveController;

        private bool _canDash = true;

        protected void Start()
        {
            _moveController = GetComponent<CharacterMovementController>();
        }

        protected void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && _canDash)
            {
                StartCoroutine(Dash());
            }
        }

        IEnumerator Dash()
        {
            _canDash = false;
            float startTime = Time.time;

            while(Time.time < startTime + _dashTime)
            {
                _moveController.CharacterController.Move(_moveController.MovementDirection * _dashSpeed * Time.deltaTime);

                yield return null;
            }

            yield return new WaitForSeconds(_dashCooldown);
            _canDash = true;
        }
    }
}