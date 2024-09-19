using SampleRPG.Item;
using UnityEngine;

namespace SampleRPG.Pickup
{
    public class PickupCoin : PickupItem
    {
        [SerializeField]
        private Coin _coinPrefab;

        public override void Pickup(BasePlayerCharacter player)
        {
            base.Pickup(player);
            if (_coinPrefab != null)
            {
                int coinValue = _coinPrefab.GetValue();
                player.AddCoins(coinValue);
            }
        }
    }
}