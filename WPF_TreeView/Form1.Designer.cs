namespace WPFTreeView
{
    partial class Form1
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
            this.wpfTreeView1 = new WPFTreeView.WpfTreeView();
            this.SuspendLayout();
            // 
            // wpfTreeView1
            // 
            this.wpfTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wpfTreeView1.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.wpfTreeView1.FullRowSelect = true;
            this.wpfTreeView1.ItemHeight = 20;
            this.wpfTreeView1.Location = new System.Drawing.Point(0, 0);
            this.wpfTreeView1.Name = "wpfTreeView1";
            this.wpfTreeView1.Size = new System.Drawing.Size(250, 456);
            this.wpfTreeView1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 456);
            this.Controls.Add(this.wpfTreeView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private WpfTreeView wpfTreeView1;
    }
}