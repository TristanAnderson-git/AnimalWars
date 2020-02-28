using System.Collections.Generic;
using UnityEngine;

namespace GOAP
{
    public class Planner
    {
        private class Node
        {
            public Node parent;
            public float runningCost;
            public HashSet<KeyValuePair<GOAP.ActionKey, object>> state;
            public GOAP.Action action;

            public Node(Node parent, float runningCost, HashSet<KeyValuePair<GOAP.ActionKey, object>> state, GOAP.Action action)
            {
                this.parent = parent;
                this.runningCost = runningCost;
                this.state = state;
                this.action = action;
            }
        }

        public Queue<GOAP.Action> Plan(GameObject agent, HashSet<GOAP.Action> availableActions, HashSet<KeyValuePair<GOAP.ActionKey, object>> worldState, HashSet<KeyValuePair<GOAP.ActionKey, object>> goal)
        {
            HashSet<GOAP.Action> usableActions = new HashSet<GOAP.Action>();
            foreach (GOAP.Action action in availableActions)
            {
                action.Reset();

                if (action.CheckPreconditions(agent))
                {
                    _ = usableActions.Add(action);
                }
            }

            List<Node> leaves = new List<Node>();

            Node start = new Node(null, 0, worldState, null);
            bool success = BuildGraph(start, leaves, usableActions, goal);

            if (!success)
                return null;

            Node cheapest = null;
            foreach (Node leaf in leaves)
            {
                if (cheapest == null || leaf.runningCost < cheapest.runningCost)
                {
                    cheapest = leaf;
                }
            }

            List<GOAP.Action> result = new List<GOAP.Action>();
            Node n = cheapest;
            while (n != null)
            {
                if (n.action != null)
                {
                    result.Insert(0, n.action);
                }
                n = n.parent;
            }

            Queue<GOAP.Action> queue = new Queue<Action>();
            foreach (GOAP.Action action in result)
            {
                queue.Enqueue(action);
            }

            return queue;
        }

        private bool BuildGraph(Node parent, List<Node> leaves, HashSet<GOAP.Action> usableActions, HashSet<KeyValuePair<GOAP.ActionKey, object>> goal)
        {
            bool foundPath = false;

            foreach (GOAP.Action action in usableActions)
            {
                if (InState(action.Precondition, parent.state))
                {
                    HashSet<KeyValuePair<GOAP.ActionKey, object>> currentState = PopulateState(parent.state, action.Effects);
                    Node node = new Node(parent, parent.runningCost + action.cost, currentState, action);

                    if (InState(goal, currentState))
                    {
                        leaves.Add(node);
                        foundPath = true;
                    }
                    else
                    {
                        HashSet<GOAP.Action> subset = ActionSubset(usableActions, action);
                        bool found = BuildGraph(node, leaves, subset, goal);
                        if (found)
                        {
                            foundPath = true;
                        }
                    }
                }
            }
            return foundPath;
        }

        private HashSet<GOAP.Action> ActionSubset(HashSet<GOAP.Action> actions, GOAP.Action toRemove)
        {
            HashSet<GOAP.Action> subset = new HashSet<GOAP.Action>();
            foreach(GOAP.Action action in actions)
            {
                if (!action.Equals(toRemove))
                {
                    _ = subset.Add(action);
                }
            }
            return subset;
        }

        private bool InState(HashSet<KeyValuePair<GOAP.ActionKey, object>> test, HashSet<KeyValuePair<GOAP.ActionKey, object>> state)
        {
            bool allMatch = true;
            foreach(KeyValuePair<GOAP.ActionKey, object> t in test)
            {
                bool match = false;
                foreach(KeyValuePair<GOAP.ActionKey, object> s in state)
                {
                    if (s.Equals(t))
                    {
                        match = true;
                        break;
                    }
                }
                if (!match)
                {
                    allMatch = false;
                }
            }
            return allMatch;
        }

        private HashSet<KeyValuePair<GOAP.ActionKey, object>> PopulateState(HashSet<KeyValuePair<GOAP.ActionKey, object>> currentState, HashSet<KeyValuePair<GOAP.ActionKey, object>> stateChange)
        {
            HashSet<KeyValuePair<GOAP.ActionKey, object>> state = new HashSet<KeyValuePair<GOAP.ActionKey, object>>();
            foreach(KeyValuePair<GOAP.ActionKey, object> s in currentState)
            {
                _ = state.Add(new KeyValuePair<GOAP.ActionKey, object>(s.Key, s.Value));
            }

            foreach(KeyValuePair<GOAP.ActionKey, object> change in stateChange)
            {
                bool exists = false;

                foreach(KeyValuePair<GOAP.ActionKey, object> s in state)
                {
                    if (s.Equals(change))
                    {
                        exists = true;
                        break;
                    }
                }

                if (exists)
                {
                    _ = state.RemoveWhere((KeyValuePair<GOAP.ActionKey, object> kvp) => { return kvp.Key.Equals(change.Key); });
                    KeyValuePair<GOAP.ActionKey, object> update = new KeyValuePair<GOAP.ActionKey, object>(change.Key, change.Value);
                    _ = state.Add(update);
                }
                else
                {
                    _ = state.Add(new KeyValuePair<GOAP.ActionKey, object>(change.Key, change.Value));
                }
            }
            return state;
        }
    }
}