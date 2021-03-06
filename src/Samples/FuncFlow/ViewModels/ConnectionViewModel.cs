using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VFlow;

namespace FuncFlow
{
    public class ConnectionViewModel:VFlowObservableObject
    {
        ConnectorViewModel _input = default!;
        public ConnectorViewModel Input
        {
            get => _input;
            set => SetProperty(ref _input, value);
        }

        ConnectorViewModel _output = default!;
        public ConnectorViewModel Output
        {
            get => _output;
            set => SetProperty(ref _output, value);
        }
    }
}
