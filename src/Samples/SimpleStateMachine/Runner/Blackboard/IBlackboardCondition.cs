using System.Threading.Tasks;

namespace SimpleStateMachine
{
    public interface IBlackboardCondition
    {
        Task<bool> Evaluate(Blackboard blackboard);
    }
}
