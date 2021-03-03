using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VFlow
{

    public delegate void PendingConnectionEventHandler(object sender, PendingConnectionEventArgs e);


    public class PendingConnectionEventArgs : RoutedEventArgs
    {
        public PendingConnectionEventArgs(object sourceConnector)
            => SourceConnector = sourceConnector;


        public Point Anchor { get; set; }


        public object SourceConnector { get; }


        public object? TargetConnector { get; set; }


        public double OffsetX { get; set; }


        public double OffsetY { get; set; }


        public bool Canceled { get; set; }
    }
}
