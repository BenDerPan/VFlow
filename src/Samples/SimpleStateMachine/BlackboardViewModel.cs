using System.Linq;
using VFlow;

namespace SimpleStateMachine
{
    public class BlackboardViewModel : VFlowObservableObject
    {
        private VFlowObservableCollection<BlackboardKeyViewModel> _keys = new VFlowObservableCollection<BlackboardKeyViewModel>();
        public VFlowObservableCollection<BlackboardKeyViewModel> Keys
        {
            get => _keys;
            set => SetProperty(ref _keys, value);
        }

        private VFlowObservableCollection<BlackboardItemReferenceViewModel> _actions = new VFlowObservableCollection<BlackboardItemReferenceViewModel>();
        public VFlowObservableCollection<BlackboardItemReferenceViewModel> Actions
        {
            get => _actions;
            set => SetProperty(ref _actions, value);
        }

        private VFlowObservableCollection<BlackboardItemReferenceViewModel> _conditions = new VFlowObservableCollection<BlackboardItemReferenceViewModel>();
        public VFlowObservableCollection<BlackboardItemReferenceViewModel> Conditions
        {
            get => _conditions;
            set => SetProperty(ref _conditions, value);
        }

        public INodifyCommand AddKeyCommand { get; }
        public INodifyCommand RemoveKeyCommand { get; }

        public BlackboardViewModel()
        {
            AddKeyCommand = new DelegateCommand(() => Keys.Add(new BlackboardKeyViewModel
            {
                Name = "New Key "
            }));

            RemoveKeyCommand = new DelegateCommand<BlackboardKeyViewModel>(key => Keys.Remove(key));

            Keys.WhenAdded(key =>
            {
                var existingKeyNames = Keys.Where(k => k != key).Select(k => k.Name).ToList();
                key.Name = existingKeyNames.GetUnique(key.Name);
            });
        }
    }
}
