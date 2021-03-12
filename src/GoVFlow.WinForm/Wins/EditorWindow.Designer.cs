
namespace VFlow
{
    partial class EditorWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowEditor = new VFlow.FlowGraph.FlowEditor();
            this.SuspendLayout();
            // 
            // flowEditor
            // 
            this.flowEditor.BackColor = System.Drawing.Color.White;
            this.flowEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowEditor.Location = new System.Drawing.Point(0, 0);
            this.flowEditor.Name = "flowEditor";
            this.flowEditor.Size = new System.Drawing.Size(800, 450);
            this.flowEditor.TabIndex = 0;
            // 
            // EditorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowEditor);
            this.Name = "EditorWindow";
            this.Text = "EditorWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private FlowGraph.FlowEditor flowEditor;
    }
}