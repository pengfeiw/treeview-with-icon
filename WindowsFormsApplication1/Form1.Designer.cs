namespace WindowsFormsApplication1
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("节点3");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("节点0", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("节点1");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("节点2");
            this.customTreeView1 = new WindowsFormsApplication1.CustomTreeView();
            this.SuspendLayout();
            // 
            // customTreeView1
            // 
            this.customTreeView1.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.customTreeView1.FullRowSelect = true;
            this.customTreeView1.ItemHeight = 30;
            this.customTreeView1.Location = new System.Drawing.Point(0, 3);
            this.customTreeView1.Name = "customTreeView1";
            treeNode1.Name = "节点3";
            treeNode1.Text = "节点3";
            treeNode2.Name = "节点0";
            treeNode2.Text = "节点0";
            treeNode3.Name = "节点1";
            treeNode3.Text = "节点1";
            treeNode4.Name = "节点2";
            treeNode4.Text = "节点2";
            this.customTreeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3,
            treeNode4});
            this.customTreeView1.ShowLines = false;
            this.customTreeView1.Size = new System.Drawing.Size(181, 261);
            this.customTreeView1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 322);
            this.Controls.Add(this.customTreeView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private CustomTreeView customTreeView1;
    }
}

