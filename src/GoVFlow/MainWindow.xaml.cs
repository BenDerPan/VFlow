using Northwoods.GoXam;
using Northwoods.GoXam.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GoVFlow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            overview.Observed = myDiagram;
            var model = new GraphLinksModel<MyNodeData, String, String, MyLinkData>();

            model.NodesSource = new ObservableCollection<MyNodeData>()
            {
                  new MyNodeData() { Key="Alpha", Color="LightBlue" },
                  new MyNodeData() { Key="Beta", Color="Orange" },
                  new MyNodeData() { Key="Gamma", Color="LightGreen" },
                  new MyNodeData() { Key="Delta", Color="Pink" }
             };

            model.LinksSource = new ObservableCollection<MyLinkData>()
            {
                new MyLinkData() { From="Alpha", To="Beta" },
                new MyLinkData() { From="Alpha", To="Gamma" },
                new MyLinkData() { From="Beta", To="Beta" },
                new MyLinkData() { From="Gamma", To="Delta" },
                new MyLinkData() { From="Delta", To="Alpha" }
            };

            model.Modifiable = true;
            model.HasUndoManager = true;

            myDiagram.Model = model;
            myDiagram.AllowDrop = true;

            myPalette.Model = new GraphLinksModel<MyNodeData, String, String, MyLinkData>();
            myPalette.Model.NodesSource = new List<MyNodeData>()
            {
                new MyNodeData() { Key="One", Color="PapayaWhip" },
                new MyNodeData() { Key="Two", Color="Lavender" },
                new MyNodeData() { Key="Three", Color="PaleGreen" },
            };
        }

        private void NodeMenuClick(object sender, RoutedEventArgs e)
        {
            var elt = sender as FrameworkElement;
            if (elt != null && elt.DataContext != null)
            {
                var data = ((PartManager.PartBinding)elt.DataContext).Data as MyNodeData;
                MessageBox.Show("Node color: " + data.Color);
            }
        }

        private void LinkMenuClick(object sender, RoutedEventArgs e)
        {
            var elt = sender as FrameworkElement;
            if (elt != null && elt.DataContext != null)
            {
                var data = ((PartManager.PartBinding)elt.DataContext).Data as MyLinkData;
                MessageBox.Show("Link: " + data.ToString());
            }
        }

        private void BackgroundMenuClick(object sender, RoutedEventArgs e)
        {
            Point p = myDiagram.LastMousePointInModel;
            MessageBox.Show("Clicked at: " + p.ToString());
        }



    }

    [Serializable]  // serializable in WPF to support the clipboard
    public class MyNodeData : GraphLinksModelNodeData<String>
    {
        public String Color
        {
            get { return _Color; }
            set
            {
                if (_Color != value)
                {
                    String old = _Color;
                    _Color = value;
                    RaisePropertyChanged("Color", old, value);
                }
            }
        }
        private String _Color = "White";
    }

    // Define custom link data; the node key is of type String,
    // the port key should be of type String but is unused in this app.
    [Serializable]  // serializable in WPF to support the clipboard
    public class MyLinkData : GraphLinksModelLinkData<String, String>
    {
        // nothing to add
    }

}
