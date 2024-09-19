using System;
using UnityEngine;

namespace SampleRPG.Pickup
{
    public abstract class PickupItem : MonoBehaviour
    {
        public event Action<PickupItem> OnPickedUp;

        public virtual void Pickup(BasePlayerCharacter player)
        {
            OnPickedUp?.Invoke(this);
        }
    }
}