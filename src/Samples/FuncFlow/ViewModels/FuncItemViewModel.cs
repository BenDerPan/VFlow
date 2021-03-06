using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VFlow;

namespace FuncFlow
{
    public class FuncItemViewModel:VFlowObservableObject
    {
        public FuncItemViewModel()
        {
            Input.WhenAdded(x =>
            {
                x.FuncItem = this;
                x.IsInput = true;
                x.PropertyChanged += OnInputValueChanged;
            })
            .WhenRemoved(x =>
            {
                x.PropertyChanged -= OnInputValueChanged;
            });
        }

        private void OnInputValueChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ConnectorViewModel.Value))
            {
                OnInputValueChanged();
            }
        }

        private Point _location;
        public Point Location
        {
            get => _location;
            set => SetProperty(ref _location, value);
        }

        private string? _title;
        public string? Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }

        private IFunc? _func;
        public IFunc? Func
        {
            get => _func;
            set => SetProperty(ref _func, value)
                .Then(OnInputValueChanged);
        }

        public VFlowObservableCollection<ConnectorViewModel> Input { get; } = new VFlowObservableCollection<ConnectorViewModel>();

        private ConnectorViewModel? _output;
        public ConnectorViewModel? Output
        {
            get => _output;
            set
            {
                if (SetProperty(ref _output, value) && _output != null)
                {
                    _output.FuncItem = this;
                }
            }
        }

        protected virtual void OnInputValueChanged()
        {
            if (Output != null && Func != null)
            {
                try
                {
                    var input = Input.Select(i => i.Value).ToArray();
                    Output.Value = Func?.Execute(input) ?? 0;
                }
                catch
                {

                }
            }
        }
    }
}
