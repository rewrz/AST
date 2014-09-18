namespace AST
{
    partial class ast
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ast));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.hide = new System.Windows.Forms.Button();
            this.show = new System.Windows.Forms.Button();
            this.Chias_link = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 52);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(260, 21);
            this.textBox1.TabIndex = 0;
            // 
            // hide
            // 
            this.hide.Location = new System.Drawing.Point(12, 226);
            this.hide.Name = "hide";
            this.hide.Size = new System.Drawing.Size(75, 23);
            this.hide.TabIndex = 2;
            this.hide.Text = "隐藏";
            this.hide.UseVisualStyleBackColor = true;
            this.hide.Click += new System.EventHandler(this.hide_Click);
            // 
            // show
            // 
            this.show.Location = new System.Drawing.Point(197, 226);
            this.show.Name = "show";
            this.show.Size = new System.Drawing.Size(75, 23);
            this.show.TabIndex = 3;
            this.show.Text = "显示";
            this.show.UseVisualStyleBackColor = true;
            this.show.Click += new System.EventHandler(this.show_Click);
            // 
            // Chias_link
            // 
            this.Chias_link.AutoSize = true;
            this.Chias_link.Location = new System.Drawing.Point(219, 9);
            this.Chias_link.Name = "Chias_link";
            this.Chias_link.Size = new System.Drawing.Size(53, 12);
            this.Chias_link.TabIndex = 4;
            this.Chias_link.TabStop = true;
            this.Chias_link.Text = "By:Chias";
            this.Chias_link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Chias_link_LinkClicked);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 118);
            this.label1.TabIndex = 5;
            this.label1.Text = "你这么屌，你妹妹知道吗？\r\n\r\n强烈建议：文件夹名最好含有数字、符号或字母。";
            // 
            // ast
            // 
            this.AcceptButton = this.hide;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Chias_link);
            this.Controls.Add(this.show);
            this.Controls.Add(this.hide);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ast";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "一键品春秋";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button hide;
        private System.Windows.Forms.Button show;
        private System.Windows.Forms.LinkLabel Chias_link;
        private System.Windows.Forms.Label label1;
    }
}

