using UnityEngine;

namespace GOAP
{
    public class Order : ScriptableObject
    {
        public new string name;
        [TextArea]
        public string description;
        public Sprite icon;

        public GOAP.ActionKey goal;
        public byte priority = 0;
    }
}
