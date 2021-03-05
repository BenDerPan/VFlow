using System;
using System.Threading.Tasks;

namespace SimpleStateMachine
{
    public class Transition
    {
        public Transition(Guid from, Guid to, IBlackboardCondition? condition = default)
        {
            From = from;
            To = to;
            Condition = condition;
        }

        public Guid From { get; }
        public Guid To { get; }
        public IBlackboardCondition? Condition { get; }

        public virtual Task<bool> CanActivate(Blackboard blackboard)
            => Condition?.Evaluate(blackboard) ?? Task.FromResult(true);
    }
}
