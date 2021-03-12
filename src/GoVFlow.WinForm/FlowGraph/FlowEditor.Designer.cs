
namespace VFlow.FlowGraph
{
    partial class FlowEditor
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.goView = new Northwoods.Go.GoView();
            this.SuspendLayout();
            // 
            // goView
            // 
            this.goView.ArrowMoveLarge = 10F;
            this.goView.ArrowMoveSmall = 1F;
            this.goView.BackColor = System.Drawing.Color.White;
            this.goView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.goView.Location = new System.Drawing.Point(0, 0);
            this.goView.Name = "goView";
            this.goView.Size = new System.Drawing.Size(841, 519);
            this.goView.TabIndex = 0;
            this.goView.Text = "goView1";
            // 
            // FlowEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.goView);
            this.Name = "FlowEditor";
            this.Size = new System.Drawing.Size(841, 519);
            this.ResumeLayout(false);

        }

        #endregion

        private Northwoods.Go.GoView goView;
    }
}
