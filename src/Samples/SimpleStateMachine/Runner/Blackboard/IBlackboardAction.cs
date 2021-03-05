using System.Threading.Tasks;

namespace SimpleStateMachine
{
    public interface IBlackboardAction
    {
        Task Execute(Blackboard blackboard);
    }
}
