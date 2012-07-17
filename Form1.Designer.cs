namespace CocosBuilder
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
            this.txtclassName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtheadFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtcppFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCanel = new System.Windows.Forms.Button();
            this.txtParentScene = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtcode_cpp = new System.Windows.Forms.TextBox();
            this.txtcode_h = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtclassName
            // 
            this.txtclassName.Location = new System.Drawing.Point(25, 32);
            this.txtclassName.Name = "txtclassName";
            this.txtclassName.Size = new System.Drawing.Size(121, 21);
            this.txtclassName.TabIndex = 0;
            this.txtclassName.Text = "Demo";
            this.txtclassName.TextChanged += new System.EventHandler(this.txtclassName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 999;
            this.label1.Text = "类名：";
            // 
            // txtheadFile
            // 
            this.txtheadFile.Location = new System.Drawing.Point(152, 32);
            this.txtheadFile.Name = "txtheadFile";
            this.txtheadFile.Size = new System.Drawing.Size(121, 21);
            this.txtheadFile.TabIndex = 1;
            this.txtheadFile.Text = "Demo.h";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 999;
            this.label2.Text = ".h 文件";
            // 
            // txtcppFile
            // 
            this.txtcppFile.Location = new System.Drawing.Point(279, 32);
            this.txtcppFile.Name = "txtcppFile";
            this.txtcppFile.Size = new System.Drawing.Size(121, 21);
            this.txtcppFile.TabIndex = 2;
            this.txtcppFile.Text = "Demo.cpp";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(282, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 999;
            this.label3.Text = ".cpp 文件";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(247, 429);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "生成";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCanel
            // 
            this.btnCanel.Enabled = false;
            this.btnCanel.Location = new System.Drawing.Point(328, 429);
            this.btnCanel.Name = "btnCanel";
            this.btnCanel.Size = new System.Drawing.Size(75, 23);
            this.btnCanel.TabIndex = 2;
            this.btnCanel.Text = "导出";
            this.btnCanel.UseVisualStyleBackColor = true;
            // 
            // txtParentScene
            // 
            this.txtParentScene.Location = new System.Drawing.Point(25, 82);
            this.txtParentScene.Name = "txtParentScene";
            this.txtParentScene.Size = new System.Drawing.Size(121, 21);
            this.txtParentScene.TabIndex = 3;
            this.txtParentScene.Text = "SysMenu";
            this.txtParentScene.TextChanged += new System.EventHandler(this.txtclassName_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 999;
            this.label5.Text = "父场景:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(25, 122);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(378, 301);
            this.tabControl1.TabIndex = 999;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtcode_h);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(370, 275);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = ".h";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtcode_cpp);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(370, 275);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = ".cpp";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtcode_cpp
            // 
            this.txtcode_cpp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtcode_cpp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(0)))));
            this.txtcode_cpp.Location = new System.Drawing.Point(3, 3);
            this.txtcode_cpp.Multiline = true;
            this.txtcode_cpp.Name = "txtcode_cpp";
            this.txtcode_cpp.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtcode_cpp.Size = new System.Drawing.Size(364, 269);
            this.txtcode_cpp.TabIndex = 5;
            // 
            // txtcode_h
            // 
            this.txtcode_h.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtcode_h.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(0)))));
            this.txtcode_h.Location = new System.Drawing.Point(3, 3);
            this.txtcode_h.Multiline = true;
            this.txtcode_h.Name = "txtcode_h";
            this.txtcode_h.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtcode_h.Size = new System.Drawing.Size(364, 269);
            this.txtcode_h.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 464);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCanel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtcppFile);
            this.Controls.Add(this.txtheadFile);
            this.Controls.Add(this.txtParentScene);
            this.Controls.Add(this.txtclassName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "CocosBuilder";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtclassName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtheadFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtcppFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCanel;
        private System.Windows.Forms.TextBox txtParentScene;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtcode_h;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtcode_cpp;
    }
}

