using SampleRPG.Pickup;
using UnityEngine;

namespace SampleRPG.Enemy
{
    public class BaseEnemyCharacter : MonoBehaviour
    {
        [SerializeField]
        private PickupCoin _coinPrefab;

        [SerializeField]
        private float _health = 100;

        private float _currentHealth;

        void Start()
        {
            _currentHealth = _health;
        }

        public void TakeDamage(float damage)
        {
            _currentHealth -= damage;

            Debug.Log($"Health: {_currentHealth}");

            if (_currentHealth <= 0)
            {
                Die();
            }
        }

        void Die()
        {
            Destroy(gameObject);
            if (_coinPrefab != null)
            {
                Instantiate(_coinPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}