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
        }
    }
}
