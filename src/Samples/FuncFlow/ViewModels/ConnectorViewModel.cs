using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VFlow;

namespace FuncFlow
{
    public class ConnectorViewModel:VFlowObservableObject
    {
        private string? _title;
        public string? Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private object _value;
        public object Value
        {
            get => _value;
            set => SetProperty(ref _value, value);
        }

        private bool _isConnected;
        public bool IsConnected
        {
            get => _isConnected;
            set => SetProperty(ref _isConnected, value);
        }

        private bool _isInput;
        public bool IsInput
        {
            get => _isInput;
            set => SetProperty(ref _isInput, value);
        }

        private Point _anchor;
        public Point Anchor
        {
            get => _anchor;
            set => SetProperty(ref _anchor, value);
        }

        private FuncItemViewModel _funcItem = default!;
        public FuncItemViewModel FuncItem
        {
            get => _funcItem;
            set => SetProperty(ref _funcItem, value);
        }
    }
}
