
namespace VFlow
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.fileFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.viewVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skinSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSkinBlue = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSkinLight = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSkinDark = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.toolBar = new System.Windows.Forms.ToolStrip();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.vS2015LightTheme1 = new WeifenLuo.WinFormsUI.Docking.VS2015LightTheme();
            this.vS2015DarkTheme1 = new WeifenLuo.WinFormsUI.Docking.VS2015DarkTheme();
            this.vS2015BlueTheme1 = new WeifenLuo.WinFormsUI.Docking.VS2015BlueTheme();
            this.vsToolStripExtender1 = new WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender(this.components);
            this.toolboxWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBar.SuspendLayout();
            this.toolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuBar
            // 
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileFToolStripMenuItem,
            this.viewVToolStripMenuItem});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Padding = new System.Windows.Forms.Padding(5, 1, 0, 1);
            this.menuBar.Size = new System.Drawing.Size(883, 24);
            this.menuBar.TabIndex = 0;
            this.menuBar.Text = "menuBar";
            // 
            // fileFToolStripMenuItem
            // 
            this.fileFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExit});
            this.fileFToolStripMenuItem.Name = "fileFToolStripMenuItem";
            this.fileFToolStripMenuItem.Size = new System.Drawing.Size(53, 22);
            this.fileFToolStripMenuItem.Text = "File(&F)";
            // 
            // btnExit
            // 
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(112, 22);
            this.btnExit.Text = "Exit(&X)";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // viewVToolStripMenuItem
            // 
            this.viewVToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.skinSettingsToolStripMenuItem,
            this.toolboxWindowToolStripMenuItem,
            this.outputWindowToolStripMenuItem,
            this.debugWindowToolStripMenuItem});
            this.viewVToolStripMenuItem.Name = "viewVToolStripMenuItem";
            this.viewVToolStripMenuItem.Size = new System.Drawing.Size(63, 22);
            this.viewVToolStripMenuItem.Text = "View(&V)";
            // 
            // skinSettingsToolStripMenuItem
            // 
            this.skinSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSkinBlue,
            this.btnSkinLight,
            this.btnSkinDark});
            this.skinSettingsToolStripMenuItem.Name = "skinSettingsToolStripMenuItem";
            this.skinSettingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.skinSettingsToolStripMenuItem.Text = "Skin Settingss";
            // 
            // btnSkinBlue
            // 
            this.btnSkinBlue.Name = "btnSkinBlue";
            this.btnSkinBlue.Size = new System.Drawing.Size(180, 22);
            this.btnSkinBlue.Text = "Blue";
            this.btnSkinBlue.Click += new System.EventHandler(this.SetSchema);
            // 
            // btnSkinLight
            // 
            this.btnSkinLight.Name = "btnSkinLight";
            this.btnSkinLight.Size = new System.Drawing.Size(180, 22);
            this.btnSkinLight.Text = "Light";
            this.btnSkinLight.Click += new System.EventHandler(this.SetSchema);
            // 
            // btnSkinDark
            // 
            this.btnSkinDark.Name = "btnSkinDark";
            this.btnSkinDark.Size = new System.Drawing.Size(180, 22);
            this.btnSkinDark.Text = "Dark";
            this.btnSkinDark.Click += new System.EventHandler(this.SetSchema);
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 499);
            this.statusBar.Name = "statusBar";
            this.statusBar.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.statusBar.Size = new System.Drawing.Size(883, 22);
            this.statusBar.TabIndex = 1;
            this.statusBar.Text = "statusBar";
            // 
            // toolBar
            // 
            this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew});
            this.toolBar.Location = new System.Drawing.Point(0, 24);
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(883, 25);
            this.toolBar.TabIndex = 2;
            this.toolBar.Text = "toolBar";
            // 
            // btnNew
            // 
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(84, 22);
            this.btnNew.Text = "New Flow";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // dockPanel
            // 
            this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel.DockBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.dockPanel.Location = new System.Drawing.Point(0, 49);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.Padding = new System.Windows.Forms.Padding(6);
            this.dockPanel.ShowAutoHideContentOnHover = false;
            this.dockPanel.Size = new System.Drawing.Size(883, 450);
            this.dockPanel.TabIndex = 3;
            this.dockPanel.Theme = this.vS2015LightTheme1;
            // 
            // vsToolStripExtender1
            // 
            this.vsToolStripExtender1.DefaultRenderer = null;
            // 
            // toolboxWindowToolStripMenuItem
            // 
            this.toolboxWindowToolStripMenuItem.Name = "toolboxWindowToolStripMenuItem";
            this.toolboxWindowToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.toolboxWindowToolStripMenuItem.Text = "Toolbox Window";
            this.toolboxWindowToolStripMenuItem.Click += new System.EventHandler(this.toolboxWindowToolStripMenuItem_Click);
            // 
            // outputWindowToolStripMenuItem
            // 
            this.outputWindowToolStripMenuItem.Name = "outputWindowToolStripMenuItem";
            this.outputWindowToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.outputWindowToolStripMenuItem.Text = "Output Window";
            this.outputWindowToolStripMenuItem.Click += new System.EventHandler(this.outputWindowToolStripMenuItem_Click);
            // 
            // debugWindowToolStripMenuItem
            // 
            this.debugWindowToolStripMenuItem.Name = "debugWindowToolStripMenuItem";
            this.debugWindowToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.debugWindowToolStripMenuItem.Text = "Debug Window";
            this.debugWindowToolStripMenuItem.Click += new System.EventHandler(this.debugWindowToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 521);
            this.Controls.Add(this.dockPanel);
            this.Controls.Add(this.toolBar);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menuBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuBar;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VFlow";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            this.toolBar.ResumeLayout(false);
            this.toolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuBar;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStrip toolBar;
        private System.Windows.Forms.ImageList imageList;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel;
        private WeifenLuo.WinFormsUI.Docking.VS2015LightTheme vS2015LightTheme1;
        private WeifenLuo.WinFormsUI.Docking.VS2015DarkTheme vS2015DarkTheme1;
        private WeifenLuo.WinFormsUI.Docking.VS2015BlueTheme vS2015BlueTheme1;
        private System.Windows.Forms.ToolStripMenuItem fileFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnExit;
        private System.Windows.Forms.ToolStripMenuItem viewVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skinSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnSkinBlue;
        private System.Windows.Forms.ToolStripMenuItem btnSkinLight;
        private System.Windows.Forms.ToolStripMenuItem btnSkinDark;
        private System.Windows.Forms.ToolStripButton btnNew;
        private WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender vsToolStripExtender1;
        private System.Windows.Forms.ToolStripMenuItem toolboxWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outputWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugWindowToolStripMenuItem;
    }
}

