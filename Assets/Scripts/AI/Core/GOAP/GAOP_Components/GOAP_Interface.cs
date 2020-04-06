using System.Collections.Generic;

namespace GOAP
{
    public interface Interface
    {
        HashSet<KeyValuePair<GOAP.ActionKey, object>> GetWorldState();
        HashSet<KeyValuePair<GOAP.ActionKey, object>> CreateGoalState();

        void PlanFailed(HashSet<KeyValuePair<GOAP.ActionKey, object>> failedGoal);
        void PlanFound(HashSet<KeyValuePair<GOAP.ActionKey, object>> goal, Queue<GOAP.Action> actions);
        void PlanAborted(GOAP.Action aborter);

        void ActionsFinished(GOAP.Action action);

        bool MoveAgent(GOAP.Action nextAction);
    }
}
