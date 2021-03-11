using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace VFlow
{
    public partial class FormMain : Form
    {
        private readonly ToolStripRenderer _toolStripProfessionalRenderer = new ToolStripProfessionalRenderer();
        bool _saveLayout = true;

        DeserializeDockContent _deserializeDockContent;

        ToolBoxWindow _winToolBox;
        EditorWindow _winEditor;
        DebugWindow _winDebug;
        OutputWindow _winOutput;

        public FormMain()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;

            Load += FormMain_Load;
            FormClosing += FormMain_FormClosing;
            

            _winToolBox = new ToolBoxWindow();
            _winDebug = new DebugWindow();
            _winOutput = new OutputWindow();

            _deserializeDockContent = new DeserializeDockContent(GetContentFromPersistString);
            vsToolStripExtender1.DefaultRenderer = _toolStripProfessionalRenderer;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");
            if (_saveLayout)
            {
                dockPanel.SaveAsXml(configFile);
            }
            else if (File.Exists(configFile))
            {
                File.Delete(configFile);
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            SetSchema(this.vS2015LightTheme1, null);

            string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");

            if (File.Exists(configFile))
            {
                dockPanel.LoadFromXml(configFile, _deserializeDockContent);
            }
            else
            {
                //初始化位置
                _winToolBox.Show(dockPanel, DockState.DockLeft);
                _winDebug.Show(dockPanel, DockState.DockRight);
                _winOutput.Show(dockPanel, DockState.DockBottom);
            }
        }

        private void SetSchema(object sender, System.EventArgs e)
        {
            // Persist settings when rebuilding UI
            string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.temp.config");

            dockPanel.SaveAsXml(configFile);
            CloseAllWindows();

            if (sender == this.vS2015LightTheme1)
            {
                this.dockPanel.Theme = this.vS2015LightTheme1;
                this.EnableVSRenderer(VisualStudioToolStripExtender.VsVersion.Vs2015, vS2015LightTheme1);
            }
            else if (sender == this.vS2015BlueTheme1)
            {
                this.dockPanel.Theme = this.vS2015BlueTheme1;
                this.EnableVSRenderer(VisualStudioToolStripExtender.VsVersion.Vs2015, vS2015BlueTheme1);
            }
            else if (sender == this.vS2015DarkTheme1)
            {
                this.dockPanel.Theme = this.vS2015DarkTheme1;
                this.EnableVSRenderer(VisualStudioToolStripExtender.VsVersion.Vs2015, vS2015DarkTheme1);
            }
            
            btnSkinLight.Checked = (sender == btnSkinLight);
            btnSkinBlue.Checked = (sender == btnSkinBlue);
            btnSkinDark.Checked = (sender == btnSkinDark);
            if (dockPanel.Theme.ColorPalette != null)
            {
                statusBar.BackColor = dockPanel.Theme.ColorPalette.MainWindowStatusBarDefault.Background;
            }

            if (File.Exists(configFile))
                dockPanel.LoadFromXml(configFile, _deserializeDockContent);
        }

        private void EnableVSRenderer(VisualStudioToolStripExtender.VsVersion version, ThemeBase theme)
        {
            vsToolStripExtender1.SetStyle(menuBar, version, theme);
            vsToolStripExtender1.SetStyle(toolBar, version, theme);
            vsToolStripExtender1.SetStyle(statusBar, version, theme);
        }


        IDockContent GetContentFromPersistString(string persistString)
        {
            if (persistString == typeof(ToolBoxWindow).ToString())
            {
                return _winToolBox;
            }
            else if (persistString == typeof(OutputWindow).ToString())
            {
                return _winOutput;
            }
            else if (persistString == typeof(DebugWindow).ToString())
            {
                return _winDebug;
            }
            else if (persistString == typeof(EditorWindow).ToString())
            {
                return new EditorWindow();
            }
            return null;
        }

        void CloseAllWindows()
        {
            _winToolBox.DockPanel = null;
            _winOutput.DockPanel = null;
            _winDebug.DockPanel = null;

            CloseAllDocuments();

            //释放所有浮动窗口
            foreach (var win in dockPanel.FloatWindows.ToList())
            {
                win.Dispose();
            }
        }

        void CloseAllDocuments()
        {
            if (dockPanel.DocumentStyle == DocumentStyle.DockingMdi)
            {
                foreach (Form form in MdiChildren)
                {
                    form.Close();
                }
            }
            else
            {
                foreach (IDockContent doc in dockPanel.DocumentsToArray())
                {
                    doc.DockHandler.DockPanel = null;
                    doc.DockHandler.Close();
                }
            }
        }

        private IDockContent FindDocument(string text)
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                foreach (Form form in MdiChildren)
                {
                    if (form.Text == text)
                    { 
                        return form as IDockContent; 
                    }
                }

                return null;
            }
            else
            {
                foreach (IDockContent content in dockPanel.Documents)
                {
                    if (content.DockHandler.TabText == text)
                    {
                        return content;
                    }
                }

                return null;
            }
        }

        private EditorWindow CreateNewDocument()
        {
            EditorWindow dummyDoc = new EditorWindow();

            int count = 1;
            string text = $"Document{count}";
            while (FindDocument(text) != null)
            {
                count++;
                text = $"Document{count}";
            }

            dummyDoc.Text = text;
            return dummyDoc;
        }

        private EditorWindow CreateNewDocument(string text)
        {
            EditorWindow dummyDoc = new EditorWindow();
            dummyDoc.Text = text;
            return dummyDoc;
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var editor= CreateNewDocument();
            if (dockPanel.DocumentStyle==DocumentStyle.SystemMdi)
            {
                editor.MdiParent = this;
                editor.Show();
            }
            else
            {
                editor.Show(dockPanel);
            }
        }

        private void toolboxWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _winToolBox.Show(dockPanel);
        }

        private void outputWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _winOutput.Show(dockPanel);
        }

        private void debugWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _winDebug.Show(dockPanel);
        }
    }
}
