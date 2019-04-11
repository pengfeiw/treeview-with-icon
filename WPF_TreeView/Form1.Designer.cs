namespace WPF_TreeView
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("节点0");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("节点1");
            this.wpfTreeView1 = new WPF_TreeView.WpfTreeView();
            this.SuspendLayout();
            // 
            // wpfTreeView1
            // 
            this.wpfTreeView1.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.wpfTreeView1.FullRowSelect = true;
            this.wpfTreeView1.ItemHeight = 30;
            this.wpfTreeView1.Location = new System.Drawing.Point(-3, 12);
            this.wpfTreeView1.Name = "wpfTreeView1";
            treeNode1.Name = "节点0";
            treeNode1.Text = "节点0";
            treeNode2.Name = "节点1";
            treeNode2.Text = "节点1";
            this.wpfTreeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.wpfTreeView1.ShowLines = false;
            this.wpfTreeView1.Size = new System.Drawing.Size(122, 91);
            this.wpfTreeView1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.wpfTreeView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private WpfTreeView wpfTreeView1;
    }
}

