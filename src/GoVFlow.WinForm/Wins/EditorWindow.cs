using Northwoods.Go;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace VFlow
{
    public partial class EditorWindow : BaseWindow
    {
       
        public EditorWindow()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;
            DockAreas = DockAreas.Document | DockAreas.Float;

            GenerateTest();
        }

        public void GenerateTest()
        {
            Dictionary<int, GoNode> dictNodes = new Dictionary<int, GoNode>();
            for (int i = 0; i < 10; i++)
            {
                var node= flowEditor.InsertNode(PointF.Empty, $"Task Flow {i}");
                dictNodes.Add(i, node);
            }

            for (int i = 0; i < 9; i++)
            {
                flowEditor.InsertLink(dictNodes[i], dictNodes[i + 1],"");
            }
            flowEditor.ForceLayout();
            flowEditor.ZoomToFit();
        }
    }
}
