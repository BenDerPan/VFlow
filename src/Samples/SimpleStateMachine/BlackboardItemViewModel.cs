using System;
using VFlow;

namespace SimpleStateMachine
{
    public class BlackboardItemViewModel : VFlowObservableObject
    {
        private string? _name;
        public string? Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private Type? _type;
        public Type? Type
        {
            get => _type;
            set => SetProperty(ref _type, value);
        }

        private VFlowObservableCollection<BlackboardKeyViewModel> _input = new VFlowObservableCollection<BlackboardKeyViewModel>();
        public VFlowObservableCollection<BlackboardKeyViewModel> Input
        {
            get => _input;
            set
            {
                if (value == null)
                {
                    value = new VFlowObservableCollection<BlackboardKeyViewModel>();
                }

                SetProperty(ref _input!, value);
            }
        }

        private VFlowObservableCollection<BlackboardKeyViewModel> _output = new VFlowObservableCollection<BlackboardKeyViewModel>();
        public VFlowObservableCollection<BlackboardKeyViewModel> Output
        {
            get => _output;
            set
            {
                if (value == null)
                {
                    value = new VFlowObservableCollection<BlackboardKeyViewModel>();
                }

                SetProperty(ref _output!, value);
            }
        }
    }
}
