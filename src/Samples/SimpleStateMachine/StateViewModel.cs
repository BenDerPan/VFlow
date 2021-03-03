using System;
using System.Windows;
using VFlow;

namespace SimpleStateMachine
{
    public class StateViewModel : ObservableObject
    {
        public Guid Id { get; }

        public StateViewModel(Guid id)
            => Id = id;

        public StateViewModel() : this(Guid.NewGuid()) { }

        // TODO: Can remove when auto layout is added
        private Point _location;
        public Point Location
        {
            get => _location;
            set => SetProperty(ref _location, value);
        }

        private Point _anchor;
        public Point Anchor
        {
            get => _anchor;
            set => SetProperty(ref _anchor, value);
        }

        private Size _size;
        public Size Size
        {
            get => _size;
            set => SetProperty(ref _size, value);
        }

        private string? _name;
        public string? Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

   
      

        public bool IsEditable { get; set; } = true;
        public SimpleStateMachineViewModel Graph { get; internal set; } = default!;
        public NodifyObservableCollection<StateViewModel> Transitions { get; } = new NodifyObservableCollection<StateViewModel>();

    }
}
