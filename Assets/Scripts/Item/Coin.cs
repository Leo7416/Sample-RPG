using UnityEngine;

namespace SampleRPG.Item
{
    public class Coin : MonoBehaviour
    {
        [SerializeField]
        private int _value = 5;

        public int GetValue()
        {
            return _value;
        }
    }
}