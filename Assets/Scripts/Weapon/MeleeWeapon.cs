using UnityEngine;

namespace SampleRPG.Weapon
{
    public class MeleeWeapon : MonoBehaviour
    {
        [field:SerializeField]
        public float AttackRange { get; private set; } = 1f;

        [field: SerializeField]
        public float AttackDamage { get; private set; } = 40;

        [field: SerializeField]
        public float AttackRate { get; private set; } = 2f;
    }
}