using System.Collections.Generic;
using UnityEngine;

namespace GOAP
{
    public abstract class Action : MonoBehaviour
    {
        public HashSet<KeyValuePair<ActionKey, object>> Precondition { get; }
        public HashSet<KeyValuePair<ActionKey, object>> Effects { get; }

        public GameObject target;
        public float minExecDist;
        public byte cost = 1;
        [HideInInspector]
        public bool inRange = false;

        public Action()
        {
            Precondition = new HashSet<KeyValuePair<ActionKey, object>>();
            Effects = new HashSet<KeyValuePair<ActionKey, object>>();
        }

        public void AddPrecondition(ActionKey key, object value)
        {
            _ = Precondition.Add(new KeyValuePair<ActionKey, object>(key, value));
        }
        public void RemovePrecondition(ActionKey key)
        {
            foreach (KeyValuePair<ActionKey, object> kvp in Precondition)
            {
                if (kvp.Key.Equals(key))
                    _ = Precondition.Remove(kvp);
            }
        }

        public void AddEffect(ActionKey key, object value)
        {
            _ = Effects.Add(new KeyValuePair<ActionKey, object>(key, value));
        }
        public void RemoveEffect(ActionKey key)
        {
            foreach (KeyValuePair<ActionKey, object> kvp in Effects)
            {
                if (kvp.Key.Equals(key))
                    _ = Effects.Remove(kvp);
            }
        }

        public virtual void Reset()
        {
            inRange = false;
            //target = null;
        }

        public abstract bool RequiresInRange();
        public abstract bool CheckPreconditions(GameObject agent);
        public abstract bool Perform(GameObject agent);
        public abstract bool IsDone();

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (target != null)
            {
                Gizmo.DrawCircle(target.transform.position, 16, minExecDist, Color.blue);
                Gizmo.DrawCircle(target.transform.position, 16, minExecDist / 2, Color.red);

                Gizmo.DrawText(target.transform.position, GetType().Name);
            }
        }
#endif
    }
}