using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VFlow
{
    public delegate void ConnectorEventHandler(object sender, ConnectorEventArgs e);


    public class ConnectorEventArgs : RoutedEventArgs
    {
        public ConnectorEventArgs(object connector)
            => Connector = connector;


        public Point Anchor { get; set; }


        public object Connector { get; }
    }
}
