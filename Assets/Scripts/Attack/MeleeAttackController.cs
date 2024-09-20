using SampleRPG.Enemy;
using SampleRPG.Weapon;
using UnityEngine;

namespace SampleRPG.Attack
{
    public class MeleeAttackController : MonoBehaviour, IAttackSource
    {
        [SerializeField]
        private Transform attackPoint;

        private MeleeWeapon _meleeWeapon;

        private float _nextAttackTime = 0f;

        public bool IsAttack { get; set; }

        protected void Update()
        {
            if (IsAttack) 
            {
                if (Time.time >= _nextAttackTime)
                {
                    Attack();
                    _nextAttackTime = Time.time + 1f / _meleeWeapon.AttackRate;
                    IsAttack = false;
                }
            }
        }

        public void Attack()
        {
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, _meleeWeapon.AttackRange, LayerUtils.EnemyMask);

            foreach (Collider enemy in hitEnemies)
            {
                enemy.GetComponent<BaseEnemyCharacter>().TakeDamage(_meleeWeapon.AttackDamage);
            }
        }

        public void SetWeapon(MeleeWeapon weaponPrefab, Transform hand)
        {
            _meleeWeapon = Instantiate(weaponPrefab, hand);
            _meleeWeapon.transform.localPosition = Vector3.zero;
            _meleeWeapon.transform.localRotation = Quaternion.identity;
        }
    }
}