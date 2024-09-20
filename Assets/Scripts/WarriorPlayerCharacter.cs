using SampleRPG.Attack;
using SampleRPG.Weapon;
using UnityEngine;

namespace SampleRPG.Scripts
{
    public class WarriorPlayerCharacter : BasePlayerCharacter
    {
        [SerializeField]
        private MeleeWeapon _weaponPrefab;

        private MeleeAttackController _meleeAttackController;

        protected override void Awake()
        {
            base.Awake();
            _meleeAttackController = GetComponent<MeleeAttackController>();
        }

        protected override void Start()
        {
            EquipWeapon();
        }

        protected override void EquipWeapon()
        {
            if (_weaponPrefab != null)
            {
                _meleeAttackController.SetWeapon(_weaponPrefab, _hand);
            }
        }

        protected override void Update()
        {
            base.Update();

            if (Input.GetButtonDown("Fire1"))
            {
                _meleeAttackController.IsAttack = true;
            }
        }
    }
}