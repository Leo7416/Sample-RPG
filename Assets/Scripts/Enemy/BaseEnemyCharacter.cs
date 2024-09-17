using UnityEngine;

namespace SampleRPG.Enemy
{
    public class BaseEnemyCharacter : MonoBehaviour
    {
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
        }
    }
}