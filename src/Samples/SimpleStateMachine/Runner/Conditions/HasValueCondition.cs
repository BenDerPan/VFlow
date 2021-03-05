using System.Threading.Tasks;

namespace SimpleStateMachine
{
    [BlackboardItem("Has Value")]
    public class HasValueCondition : IBlackboardCondition
    {
        [BlackboardProperty(BlackboardKeyType.Object)]
        public BlackboardKey Key { get; set; }

        public Task<bool> Evaluate(Blackboard blackboard)
            => Task.FromResult(blackboard.GetObject(Key) != null);
    }
}
