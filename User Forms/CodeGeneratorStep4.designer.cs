namespace User_Forms
{
    partial class CodeGeneratorStep4
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
            this.btnGenerate = new System.Windows.Forms.Button();
            this.cbApplicationType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMidletierDll = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDomainFiles = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFindMiddletierDll = new System.Windows.Forms.Button();
            this.btnFindDomainFiles = new System.Windows.Forms.Button();
            this.btnFindUIFiles = new System.Windows.Forms.Button();
            this.txtUIFiles = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnObjectFiles = new System.Windows.Forms.Button();
            this.txtObjectFiles = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(265, 262);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbApplicationType
            // 
            this.cbApplicationType.FormattingEnabled = true;
            this.cbApplicationType.Location = new System.Drawing.Point(194, 45);
            this.cbApplicationType.Name = "cbApplicationType";
            this.cbApplicationType.Size = new System.Drawing.Size(158, 21);
            this.cbApplicationType.TabIndex = 1;
            this.cbApplicationType.Text = "Chose UI type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Enter middletier dll location";
            // 
            // txtMidletierDll
            // 
            this.txtMidletierDll.Location = new System.Drawing.Point(194, 89);
            this.txtMidletierDll.Name = "txtMidletierDll";
            this.txtMidletierDll.Size = new System.Drawing.Size(232, 20);
            this.txtMidletierDll.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Enter domain files location";
            // 
            // txtDomainFiles
            // 
            this.txtDomainFiles.Location = new System.Drawing.Point(194, 170);
            this.txtDomainFiles.Name = "txtDomainFiles";
            this.txtDomainFiles.Size = new System.Drawing.Size(232, 20);
            this.txtDomainFiles.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Chose UI type";
            // 
            // btnFindMiddletierDll
            // 
            this.btnFindMiddletierDll.Location = new System.Drawing.Point(463, 87);
            this.btnFindMiddletierDll.Name = "btnFindMiddletierDll";
            this.btnFindMiddletierDll.Size = new System.Drawing.Size(75, 23);
            this.btnFindMiddletierDll.TabIndex = 8;
            this.btnFindMiddletierDll.Text = "Find";
            this.btnFindMiddletierDll.UseVisualStyleBackColor = true;
            this.btnFindMiddletierDll.Click += new System.EventHandler(this.btnFindMiddletierDll_Click);
            // 
            // btnFindDomainFiles
            // 
            this.btnFindDomainFiles.Location = new System.Drawing.Point(463, 167);
            this.btnFindDomainFiles.Name = "btnFindDomainFiles";
            this.btnFindDomainFiles.Size = new System.Drawing.Size(75, 23);
            this.btnFindDomainFiles.TabIndex = 9;
            this.btnFindDomainFiles.Text = "Find";
            this.btnFindDomainFiles.UseVisualStyleBackColor = true;
            this.btnFindDomainFiles.Click += new System.EventHandler(this.btnFindDomainFiles_Click);
            // 
            // btnFindUIFiles
            // 
            this.btnFindUIFiles.Location = new System.Drawing.Point(463, 206);
            this.btnFindUIFiles.Name = "btnFindUIFiles";
            this.btnFindUIFiles.Size = new System.Drawing.Size(75, 23);
            this.btnFindUIFiles.TabIndex = 12;
            this.btnFindUIFiles.Text = "Find";
            this.btnFindUIFiles.UseVisualStyleBackColor = true;
            this.btnFindUIFiles.Click += new System.EventHandler(this.btnFindUIFiles_Click);
            // 
            // txtUIFiles
            // 
            this.txtUIFiles.Location = new System.Drawing.Point(194, 209);
            this.txtUIFiles.Name = "txtUIFiles";
            this.txtUIFiles.Size = new System.Drawing.Size(232, 20);
            this.txtUIFiles.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Enter UI files location";
            // 
            // btnObjectFiles
            // 
            this.btnObjectFiles.Location = new System.Drawing.Point(463, 128);
            this.btnObjectFiles.Name = "btnObjectFiles";
            this.btnObjectFiles.Size = new System.Drawing.Size(75, 23);
            this.btnObjectFiles.TabIndex = 15;
            this.btnObjectFiles.Text = "Find";
            this.btnObjectFiles.UseVisualStyleBackColor = true;
            this.btnObjectFiles.Click += new System.EventHandler(this.btnObjectFiles_Click);
            // 
            // txtObjectFiles
            // 
            this.txtObjectFiles.Location = new System.Drawing.Point(194, 131);
            this.txtObjectFiles.Name = "txtObjectFiles";
            this.txtObjectFiles.Size = new System.Drawing.Size(232, 20);
            this.txtObjectFiles.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Enter object files location";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(463, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 43);
            this.button1.TabIndex = 16;
            this.button1.Text = "Get Values from config";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // CodeGeneratorStep4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 348);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnObjectFiles);
            this.Controls.Add(this.txtObjectFiles);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnFindUIFiles);
            this.Controls.Add(this.txtUIFiles);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnFindDomainFiles);
            this.Controls.Add(this.btnFindMiddletierDll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDomainFiles);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMidletierDll);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbApplicationType);
            this.Controls.Add(this.btnGenerate);
            this.Name = "CodeGeneratorStep4";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.ComboBox cbApplicationType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMidletierDll;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDomainFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFindMiddletierDll;
        private System.Windows.Forms.Button btnFindDomainFiles;
        private System.Windows.Forms.Button btnFindUIFiles;
        private System.Windows.Forms.TextBox txtUIFiles;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnObjectFiles;
        private System.Windows.Forms.TextBox txtObjectFiles;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
    }
}

