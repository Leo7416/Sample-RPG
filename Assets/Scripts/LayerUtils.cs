using UnityEngine;

namespace SampleRPG
{
    public class LayerUtils
    {
        public const string EnemyLayerName = "Enemy";
        public const string PlayerLayerName = "Player";

        public static readonly int EnemyMask = LayerMask.GetMask(EnemyLayerName);
    }
}
