namespace User_Forms
{
    partial class CodeGeneratorStep3
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
            this.btnNext = new System.Windows.Forms.Button();
            this.cbVSversion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSolutionName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVSlocation = new System.Windows.Forms.TextBox();
            this.btnSolutionLocation = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbSolution = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(183, 225);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbVSversion
            // 
            this.cbVSversion.FormattingEnabled = true;
            this.cbVSversion.Location = new System.Drawing.Point(253, 87);
            this.cbVSversion.Name = "cbVSversion";
            this.cbVSversion.Size = new System.Drawing.Size(121, 21);
            this.cbVSversion.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(250, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Visual Studio version";
            // 
            // txtSolutionName
            // 
            this.txtSolutionName.Location = new System.Drawing.Point(34, 87);
            this.txtSolutionName.Name = "txtSolutionName";
            this.txtSolutionName.Size = new System.Drawing.Size(167, 20);
            this.txtSolutionName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Project name";
            // 
            // txtVSlocation
            // 
            this.txtVSlocation.Location = new System.Drawing.Point(34, 165);
            this.txtVSlocation.Name = "txtVSlocation";
            this.txtVSlocation.Size = new System.Drawing.Size(167, 20);
            this.txtVSlocation.TabIndex = 5;
            // 
            // btnSolutionLocation
            // 
            this.btnSolutionLocation.Location = new System.Drawing.Point(253, 162);
            this.btnSolutionLocation.Name = "btnSolutionLocation";
            this.btnSolutionLocation.Size = new System.Drawing.Size(75, 23);
            this.btnSolutionLocation.TabIndex = 6;
            this.btnSolutionLocation.Text = "Find";
            this.btnSolutionLocation.UseVisualStyleBackColor = true;
            this.btnSolutionLocation.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Visual studio location";
            // 
            // cbSolution
            // 
            this.cbSolution.AutoSize = true;
            this.cbSolution.Location = new System.Drawing.Point(34, 12);
            this.cbSolution.Name = "cbSolution";
            this.cbSolution.Size = new System.Drawing.Size(109, 17);
            this.cbSolution.TabIndex = 8;
            this.cbSolution.Text = "Generate solution";
            this.cbSolution.UseVisualStyleBackColor = true;
            this.cbSolution.Click += new System.EventHandler(this.cbSolution_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(416, 125);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 47);
            this.button1.TabIndex = 9;
            this.button1.Text = "Get values from config";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // CodeGeneratorStep3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 306);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbSolution);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSolutionLocation);
            this.Controls.Add(this.txtVSlocation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSolutionName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbVSversion);
            this.Controls.Add(this.btnNext);
            this.Name = "CodeGeneratorStep3";
            this.Text = "Step2";
            this.Load += new System.EventHandler(this.Step2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ComboBox cbVSversion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSolutionName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVSlocation;
        private System.Windows.Forms.Button btnSolutionLocation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbSolution;
        private System.Windows.Forms.Button button1;
    }
}