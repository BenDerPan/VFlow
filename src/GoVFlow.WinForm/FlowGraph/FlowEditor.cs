using Northwoods.Go;
using Northwoods.Go.Layout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VFlow.FlowGraph
{
    public partial class FlowEditor : UserControl
    {
        public readonly GoOverview Overview = new GoOverview();
        public readonly ContextMenuStrip OverviewContextMenuStrip = new ContextMenuStrip();
        public GoView View => goView;

        Timer _timerLinkAnimate, _timerShakeBorder;

        public FlowEditor()
        {
            InitializeComponent();

            _timerLinkAnimate = new Timer() { Interval = 50 };
            _timerLinkAnimate.Tick += timerLinkAnimate_Tick;
            _timerLinkAnimate.Enabled = true;

            _timerShakeBorder = new Timer() { Interval = 500 };
            _timerShakeBorder.Tick += timerShakeBorder_Tick;
            _timerShakeBorder.Enabled = false;

            // Customize the standard kind of link that is drawn.
            goView.NewLinkPrototype = new AnimatedLink();
            // enable undo and redo
            goView.Document.UndoManager = new GoUndoManager();
            goView.LinkCreated += goView_LinkCreated;

            //增加鹰眼视图Overview
            Overview.BackColor = View.BackColor;
            Overview.Size = new Size(300, 180);
            Overview.Location = new Point(this.Width - Overview.Width-20, this.Height - Overview.Height-20);

            //跟随大小变更
            this.SizeChanged += DiagramViewer_SizeChanged;

            //图形刷新，同步鹰眼图
            goView.Document.Changed += GoViewDocument_Changed; ;

            this.Controls.Add(Overview);
            //鹰眼图显示到最上层
            Overview.BringToFront();

            //增加Overview快捷菜单
            OverviewContextMenuStrip.Items.AddRange(new[] {
                new ToolStripMenuItem("Reset",null,(sender,e)=>{
                ZoomToFit();
                })
            });

            Overview.ContextMenuStrip = OverviewContextMenuStrip;
        }

        public void SetNodeFlashing(bool shouldFlashing = false)
        {
            _timerShakeBorder.Enabled = shouldFlashing;
        }

        public void SetLinkFlashing(bool shouldFlashing = false)
        {
            _timerLinkAnimate.Enabled = shouldFlashing;
        }

        private void GoViewDocument_Changed(object sender, GoChangedEventArgs e)
        {
            RefreshOverview();
        }

        private void DiagramViewer_SizeChanged(object sender, EventArgs e)
        {
            Overview.Location = new Point(this.Width - Overview.Width-20, this.Height - Overview.Height-20);
        }

        public void RefreshOverview()
        {
            Overview.Observed = View;
            Overview.RescaleToFit();
        }

        private void goView_LinkCreated(object sender, Northwoods.Go.GoSelectionEventArgs e)
        {
            GoLink link = e.GoObject as GoLink;
            if (link != null)
            {
                Color c = Color.Black;
                link.PenColor = c;
                link.PenWidth = 2;
                link.BrushColor = c;
            }
        }

        private void timerLinkAnimate_Tick(object sender, EventArgs e)
        {
            goView.Document.SkipsUndoManager = true;
            foreach (GoObject obj in goView.Document)
            {
                AnimatedLink link = obj as AnimatedLink;
                if (link != null) link.Step();
            }
            goView.Document.SkipsUndoManager = false;
        }

        private void timerShakeBorder_Tick(object sender, System.EventArgs e)
        {
            goView.Document.SkipsUndoManager = true;
            foreach (GoObject obj in goView.Document)
            {
                GoBasicNode n = obj as GoBasicNode;
                if (n != null)
                {
                    if (n.Shape.PenWidth == 2)
                        n.Shape.PenWidth = 4;
                    else
                        n.Shape.PenWidth = 2;
                }
            }
            goView.Document.SkipsUndoManager = false;
        }


        public void ForceLayout()
        {
            GoLayoutForceDirected layout = new GoLayoutForceDirected();
            layout.Document = goView.Document;
            layout.Document.StartTransaction();
            layout.PerformLayout();
            layout.Document.FinishTransaction("ForceLayout Finished");
            ZoomToFit();
        }

        public void ZoomToFit()
        {
            goView.Document.StartTransaction();
            goView.Document.Bounds = goView.Document.ComputeBounds();
            goView.RescaleToFit();
            goView.Document.FinishTransaction("Zoom to fit finished");
        }

        public GoBasicNode InsertNode(PointF pt, string title, GoShape shape = null, int userFlag = 0, Object userObj = null)
        {
            if (shape == null)
            {
                shape = new GoRectangle();
            }
            GoDocument doc = goView.Document;
            doc.StartTransaction();
            GoBasicNode n = new GoBasicNode();
            n.UserFlags = userFlag;
            n.UserObject = userObj;
            n.LabelSpot = GoObject.Middle;
            n.Text = title;
            n.Shape = shape;

            // specify the position and colors
            n.Location = pt;
            n.Brush = new SolidBrush(Color.White);
            n.Shape.PenColor = Color.Red;
            n.Shape.PenWidth = 2;
            // allow the user to edit the text in-place
            n.Label.Editable = true;
            doc.Add(n);
            doc.FinishTransaction("Insert node finished");
            return n;
        }

        public GoNode InsertNode(PointF pt, GoNode node, int userFlag = 0, Object userObj = null)
        {
            GoDocument doc = goView.Document;
            doc.StartTransaction();
            node.UserFlags = userFlag;
            node.UserObject = userObj;
            node.Location = pt;
            doc.Add(node);
            doc.FinishTransaction("Insert node finished");
            return node;
        }


        public AnimatedLink InsertLink(GoNode from, GoNode to, string relation, int userFlag = 0, Object userObj = null)
        {
            AnimatedLink link = new AnimatedLink();
            link.UserFlags = userFlag;
            link.UserObject = userObj;
            link.FromPort = from.Ports.ToList()[0];
            link.ToPort = to.Ports.ToList()[0];
            (link.MidLabel as GoText).Text = relation;
            goView.Document.LinksLayer.Add(link);
            return link;
        }



        public void Close()
        {
            _timerLinkAnimate.Dispose();
            _timerShakeBorder.Dispose();
            OverviewContextMenuStrip.Dispose();
            Overview.Dispose();
            View.Dispose();
            Dispose();
        }

    }
}
