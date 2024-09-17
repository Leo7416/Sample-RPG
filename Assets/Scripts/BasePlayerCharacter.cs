using SampleRPG.Movement;
using SampleRPG.Weapon;
using UnityEngine;

namespace SampleRPG
{
    public abstract class BasePlayerCharacter : MonoBehaviour
    {
        [SerializeField]
        private float _health = 100f;

        [SerializeField]
        protected Transform _hand;

        private IMovementDirectionSource _movementDirectionSource;

        private CharacterMovementController _characterMovementController;

        protected virtual void Awake()
        {
            _movementDirectionSource = GetComponent<IMovementDirectionSource>();

            _characterMovementController = GetComponent<CharacterMovementController>();
        }

        protected virtual void Start() {}

        protected virtual void Update()
        {
            var direction = _movementDirectionSource.MovementDirection;
            var lookDirection = direction;

            _characterMovementController.MovementDirection = direction;
            _characterMovementController.LookDirection = lookDirection;
        }

        protected abstract void EquipWeapon();
    }
}