using UnityEngine;

namespace GOAP
{
    [System.Serializable]
    public class Order
    {
        public string name;
        public GOAP.ActionKey goal;
        public byte priority = 0;
    }
}
