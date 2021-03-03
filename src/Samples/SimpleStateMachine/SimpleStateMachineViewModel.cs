using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFlow;

namespace SimpleStateMachine
{
    public class SimpleStateMachineViewModel: ObservableObject
    {
        private NodifyObservableCollection<StateViewModel> _states = new NodifyObservableCollection<StateViewModel>();
        public NodifyObservableCollection<StateViewModel> States
        {
            get => _states;
            set => SetProperty(ref _states, value);
        }

        private NodifyObservableCollection<StateViewModel> _selectedStates = new NodifyObservableCollection<StateViewModel>();
        public NodifyObservableCollection<StateViewModel> SelectedStates
        {
            get => _selectedStates;
            set => SetProperty(ref _selectedStates, value);
        }

        private NodifyObservableCollection<TransitionViewModel> _connections = new NodifyObservableCollection<TransitionViewModel>();
        public NodifyObservableCollection<TransitionViewModel> Transitions
        {
            get => _connections;
            set => SetProperty(ref _connections, value);
        }

        private StateViewModel? _selectedState;
        public StateViewModel? SelectedState
        {
            get => _selectedState;
            set => SetProperty(ref _selectedState, value);
        }

        public TransitionViewModel PendingTransition { get; }

        public SimpleStateMachineViewModel()
        {
            PendingTransition = new TransitionViewModel();

            Transitions.WhenAdded(c => c.Source.Transitions.Add(c.Target))
           .WhenRemoved(c => c.Source.Transitions.Remove(c.Target))
           .WhenCleared(c => c.ForEach(i =>
           {
               i.Source.Transitions.Clear();
               i.Target.Transitions.Clear();
           }));

            States.WhenAdded(x => x.Graph = this)
                 .WhenRemoved(x => DisconnectState(x))
                 .WhenCleared(x =>
                 {
                     Transitions.Clear();
                     OnCreateDefaultNodes();
                 });

        }

        public void DisconnectState(StateViewModel state)
        {
            var transitions = Transitions.Where(t => t.Source == state || t.Target == state).ToList();
            transitions.ForEach(t => Transitions.Remove(t));
        }

        protected virtual void OnCreateDefaultNodes()
        {
            States.Insert(0, new StateViewModel
            {
                Name = "状态A",
                IsEditable = false
            });

            States.Add(new StateViewModel
            {
                Name = "状态B",
            });


            States.Add(new StateViewModel
            {
                Name = "状态C",
            });


            States.Add(new StateViewModel
            {
                Name = "状态D",
            });

            States.Add(new StateViewModel
            {
                Name = "状态E",
            });


            Transitions.Add(new TransitionViewModel
            {
                Source = States[0],
                Target = States[1],
            });


            Transitions.Add(new TransitionViewModel
            {
                Source = States[1],
                Target = States[2],
            });

            Transitions.Add(new TransitionViewModel
            {
                Source = States[2],
                Target = States[3]
            });

            Transitions.Add(new TransitionViewModel
            {
                Source = States[3],
                Target = States[4]
            });

            Transitions.Add(new TransitionViewModel
            {
                Source = States[4],
                Target = States[1]
            });
        }

    }
}
