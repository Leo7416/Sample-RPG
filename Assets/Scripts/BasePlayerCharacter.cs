using SampleRPG.Movement;
using SampleRPG.Pickup;
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

        private int _coinCount = 0;

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

        protected void OnTriggerEnter(Collider other)
        {
            var pickupItem = other.gameObject.GetComponent<PickupItem>();
            if (pickupItem != null)
            {
                pickupItem.Pickup(this);
                Destroy(other.gameObject);
            }
        }

        protected abstract void EquipWeapon();

        public void AddCoins(int amount)
        {
            _coinCount += amount;
            Debug.Log("Coins: " + _coinCount);
        }
    }
}