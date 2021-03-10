using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VFlow
{
    public class MainViewModel:VFlowObservableObject
    {
        private VFlowObservableCollection<FunctionViewModel> _funcItems = new VFlowObservableCollection<FunctionViewModel>();
        public VFlowObservableCollection<FunctionViewModel> FuncItems
        {
            get => _funcItems;
            set => SetProperty(ref _funcItems, value);
        }

        public VFlowObservableCollection<ConnectionViewModel> Connections { get; } = new VFlowObservableCollection<ConnectionViewModel>();

        public VFlowObservableCollection<FunctionInfoViewModel> AvailableFuncItems { get; } = new VFlowObservableCollection<FunctionInfoViewModel>();

        public INodifyCommand CreateConnectionCommand { get; }
        public INodifyCommand CreateFuncItemCommand { get; }
        public INodifyCommand DisconnectConnectorCommand { get; }
        public INodifyCommand DeleteSelectionCommand { get; }

        public MainViewModel()
        {
            CreateConnectionCommand = new DelegateCommand<(object Source, object Target)>(target => CreateConnection((ConnectorViewModel)target.Source, (ConnectorViewModel)target.Target), target => CanCreateConnection((ConnectorViewModel)target.Source, target.Target as ConnectorViewModel));
            CreateFuncItemCommand = new DelegateCommand<CreateFunctionInfoViewModel>(CreateFuncItems);
            DisconnectConnectorCommand = new DelegateCommand<ConnectorViewModel>(DisconnectConnector);
            DeleteSelectionCommand = new DelegateCommand(DeleteSelection);

            Connections.WhenAdded(c =>
            {
                c.Input.IsConnected = true;
                c.Output.IsConnected = true;

                c.Input.Value = c.Output.Value;

                c.Output.PropertyChanged += (s, e) =>
                {
                    if (e.PropertyName == nameof(ConnectorViewModel.Value))
                    {
                        c.Input.Value = c.Output.Value;
                    }
                };
            })
            .WhenRemoved(c =>
            {
                var ic = Connections.Count(con => con.Input == c.Input || con.Output == c.Input);
                var oc = Connections.Count(con => con.Input == c.Output || con.Output == c.Output);

                if (ic == 0)
                {
                    c.Input.IsConnected = false;
                }

                if (oc == 0)
                {
                    c.Output.IsConnected = false;
                }
            });

            FuncItems.WhenAdded(x =>
            {
                x.Input.WhenRemoved(i =>
                {
                    var c = Connections.Where(con => con.Input == i || con.Output == i).ToArray();
                    c.ForEach(con => Connections.Remove(con));
                });
            })
            .WhenRemoved(x =>
            {
                foreach (var input in x.Input)
                {
                    DisconnectConnector(input);
                }

                if (x.Output != null)
                {
                    DisconnectConnector(x.Output);
                }
            });

            UpdateAvailableFuncItems();
        }

        private void DisconnectConnector(ConnectorViewModel connector)
        {
            var connections = Connections.Where(c => c.Input == connector || c.Output == connector).ToList();
            connections.ForEach(c => Connections.Remove(c));
        }

        private bool CanCreateConnection(ConnectorViewModel source, ConnectorViewModel? target)
            => target != null && source != target && source.FuncItem != target.FuncItem && source.IsInput != target.IsInput;

        private void CreateConnection(ConnectorViewModel source, ConnectorViewModel target)
        {
            var input = source.IsInput ? source : target;
            var output = target.IsInput ? source : target;

            DisconnectConnector(input);

            Connections.Add(new ConnectionViewModel
            {
                Input = input,
                Output = output
            });
        }

        private void CreateFuncItems(CreateFunctionInfoViewModel arg)
        {
            var input = arg.Info.Input.Select(i => new ConnectorViewModel
            {
                Title = i,
                Value = "[Empty]"
            });
            var op = new FunctionViewModel
            {
                Title = arg.Info.Title,
                Output = new ConnectorViewModel(),
                Func = arg.Info.Func,

            };
            op.Input.AddRange(input);

            op.Location = arg.Location;

            FuncItems.Add(op);
        }

        private void UpdateAvailableFuncItems()
        {
            var info = new FunctionInfoViewModel()
            {
                Title = "Logger",
                Func = new LoggerFunction(),
                MaxInput = 100,
                MinInput = 1
            };
            info.Input.Add(null);

            AvailableFuncItems.Add(info);

            var info2 = new FunctionInfoViewModel()
            {
                Title = "User Input",
                Func = new InputFunction(),
                MaxInput = 5,
                MinInput = 1
            };
            info2.Input.Add("Cmd");
            info2.Input.Add("AA");
            AvailableFuncItems.Add(info2);

            //AvailableFuncItems.AddRange(operations);
        }

        private void DeleteSelection()
        {
            var selected = FuncItems.Where(o => o.IsSelected).ToList();
            selected.ForEach(o => FuncItems.Remove(o));
        }
    }
}
