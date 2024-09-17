using SampleRPG.Enemy;
using SampleRPG.Weapon;
using UnityEngine;

namespace SampleRPG.Attack
{
    public class MeleeAttackController : MonoBehaviour
    {
        [SerializeField]
        private Transform attackPoint;

        private MeleeWeapon _meleeWeapon;

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