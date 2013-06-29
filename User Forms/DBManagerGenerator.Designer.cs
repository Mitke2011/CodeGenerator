namespace User_Forms
{
    partial class DBmanagerGenerator
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
            this.btnFindTemplate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnSaveClass = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClass = new System.Windows.Forms.TextBox();
            this.txtTemplate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtConStr = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rdBtnC = new System.Windows.Forms.RadioButton();
            this.rdBtnJ = new System.Windows.Forms.RadioButton();
            this.txtDriver = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnFindTemplate
            // 
            this.btnFindTemplate.Location = new System.Drawing.Point(498, 70);
            this.btnFindTemplate.Name = "btnFindTemplate";
            this.btnFindTemplate.Size = new System.Drawing.Size(91, 23);
            this.btnFindTemplate.TabIndex = 0;
            this.btnFindTemplate.Text = "Browse...";
            this.btnFindTemplate.UseVisualStyleBackColor = true;
            this.btnFindTemplate.Click += new System.EventHandler(this.btnFindTemplate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Template location";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(273, 263);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // fileDialog
            // 
            this.fileDialog.FileName = "openFileDialog1";
            // 
            // btnSaveClass
            // 
            this.btnSaveClass.Location = new System.Drawing.Point(498, 124);
            this.btnSaveClass.Name = "btnSaveClass";
            this.btnSaveClass.Size = new System.Drawing.Size(91, 23);
            this.btnSaveClass.TabIndex = 4;
            this.btnSaveClass.Text = "Browse...";
            this.btnSaveClass.UseVisualStyleBackColor = true;
            this.btnSaveClass.Click += new System.EventHandler(this.btnSaveClass_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Class location";
            // 
            // txtClass
            // 
            this.txtClass.Enabled = false;
            this.txtClass.Location = new System.Drawing.Point(153, 126);
            this.txtClass.Name = "txtClass";
            this.txtClass.Size = new System.Drawing.Size(319, 20);
            this.txtClass.TabIndex = 6;
            // 
            // txtTemplate
            // 
            this.txtTemplate.Enabled = false;
            this.txtTemplate.Location = new System.Drawing.Point(153, 75);
            this.txtTemplate.Name = "txtTemplate";
            this.txtTemplate.Size = new System.Drawing.Size(319, 20);
            this.txtTemplate.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Connection string";
            // 
            // txtConStr
            // 
            this.txtConStr.Location = new System.Drawing.Point(153, 180);
            this.txtConStr.Name = "txtConStr";
            this.txtConStr.Size = new System.Drawing.Size(319, 20);
            this.txtConStr.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Chose language";
            // 
            // rdBtnC
            // 
            this.rdBtnC.AutoSize = true;
            this.rdBtnC.Location = new System.Drawing.Point(153, 29);
            this.rdBtnC.Name = "rdBtnC";
            this.rdBtnC.Size = new System.Drawing.Size(42, 17);
            this.rdBtnC.TabIndex = 11;
            this.rdBtnC.TabStop = true;
            this.rdBtnC.Text = "C #";
            this.rdBtnC.UseVisualStyleBackColor = true;
            this.rdBtnC.CheckedChanged += new System.EventHandler(this.rdBtnC_CheckedChanged);
            // 
            // rdBtnJ
            // 
            this.rdBtnJ.AutoSize = true;
            this.rdBtnJ.Location = new System.Drawing.Point(387, 29);
            this.rdBtnJ.Name = "rdBtnJ";
            this.rdBtnJ.Size = new System.Drawing.Size(48, 17);
            this.rdBtnJ.TabIndex = 12;
            this.rdBtnJ.TabStop = true;
            this.rdBtnJ.Text = "Java";
            this.rdBtnJ.UseVisualStyleBackColor = true;
            this.rdBtnJ.CheckedChanged += new System.EventHandler(this.rdBtnJ_CheckedChanged);
            // 
            // txtDriver
            // 
            this.txtDriver.Location = new System.Drawing.Point(153, 227);
            this.txtDriver.Name = "txtDriver";
            this.txtDriver.Size = new System.Drawing.Size(319, 20);
            this.txtDriver.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "DB driver";
            // 
            // DBmanagerGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 298);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDriver);
            this.Controls.Add(this.rdBtnJ);
            this.Controls.Add(this.rdBtnC);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtConStr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTemplate);
            this.Controls.Add(this.txtClass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSaveClass);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFindTemplate);
            this.Name = "DBmanagerGenerator";
            this.Text = "SelectClass";
            this.Load += new System.EventHandler(this.DBmanagerGenerator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFindTemplate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog fileDialog;
        private System.Windows.Forms.Button btnSaveClass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClass;
        private System.Windows.Forms.TextBox txtTemplate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtConStr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdBtnC;
        private System.Windows.Forms.RadioButton rdBtnJ;
        private System.Windows.Forms.TextBox txtDriver;
        private System.Windows.Forms.Label label5;
    }
}