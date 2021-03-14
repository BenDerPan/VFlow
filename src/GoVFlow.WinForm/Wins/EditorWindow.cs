using Northwoods.Go;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace VFlow
{
    public partial class EditorWindow : BaseWindow
    {
        readonly ResourceManager rm;
        public EditorWindow()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;
            DockAreas = DockAreas.Document | DockAreas.Float;
            rm = Properties.Resources.ResourceManager;//new ResourceManager("GoVFlow.WinForm.Resources", Assembly.GetExecutingAssembly());
            GenerateTest();
        }

        public void GenerateTest()
        {
            Dictionary<int, VNode> dictNodes = new Dictionary<int, VNode>();
            for (int i = 0; i < 10; i++)
            {
                var node = new VNode();
                node.Initialize(rm, "terminal", $"Flow {i}");
                flowEditor.InsertNode(PointF.Empty, node);
                dictNodes.Add(i, node);
            }

            for (int i = 0; i < 9; i++)
            {
                flowEditor.InsertLink(dictNodes[i], dictNodes[i + 1], "");
            }
            flowEditor.ForceLayout();
            flowEditor.ZoomToFit();
        }
    }
}
