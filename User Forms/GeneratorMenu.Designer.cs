namespace User_Forms
{
    partial class GeneratorMenu
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
            this.rdBtnC = new System.Windows.Forms.RadioButton();
            this.rdBtnJ = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnFindTemplate
            // 
            this.btnFindTemplate.Location = new System.Drawing.Point(492, 63);
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
            this.label1.Location = new System.Drawing.Point(11, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Template location";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(273, 189);
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
            this.btnSaveClass.Location = new System.Drawing.Point(492, 121);
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
            this.label2.Location = new System.Drawing.Point(11, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Class location";
            // 
            // txtClass
            // 
            this.txtClass.Enabled = false;
            this.txtClass.Location = new System.Drawing.Point(147, 123);
            this.txtClass.Name = "txtClass";
            this.txtClass.Size = new System.Drawing.Size(319, 20);
            this.txtClass.TabIndex = 6;
            // 
            // txtTemplate
            // 
            this.txtTemplate.Enabled = false;
            this.txtTemplate.Location = new System.Drawing.Point(147, 68);
            this.txtTemplate.Name = "txtTemplate";
            this.txtTemplate.Size = new System.Drawing.Size(319, 20);
            this.txtTemplate.TabIndex = 7;
            // 
            // rdBtnC
            // 
            this.rdBtnC.AutoSize = true;
            this.rdBtnC.Location = new System.Drawing.Point(196, 25);
            this.rdBtnC.Name = "rdBtnC";
            this.rdBtnC.Size = new System.Drawing.Size(42, 17);
            this.rdBtnC.TabIndex = 8;
            this.rdBtnC.TabStop = true;
            this.rdBtnC.Text = "C #";
            this.rdBtnC.UseVisualStyleBackColor = true;
            // 
            // rdBtnJ
            // 
            this.rdBtnJ.AutoSize = true;
            this.rdBtnJ.Location = new System.Drawing.Point(330, 25);
            this.rdBtnJ.Name = "rdBtnJ";
            this.rdBtnJ.Size = new System.Drawing.Size(48, 17);
            this.rdBtnJ.TabIndex = 9;
            this.rdBtnJ.TabStop = true;
            this.rdBtnJ.Text = "Java";
            this.rdBtnJ.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Chose language";
            // 
            // GeneratorMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 274);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rdBtnJ);
            this.Controls.Add(this.rdBtnC);
            this.Controls.Add(this.txtTemplate);
            this.Controls.Add(this.txtClass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSaveClass);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFindTemplate);
            this.Name = "GeneratorMenu";
            this.Text = "SelectClass";
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
        private System.Windows.Forms.RadioButton rdBtnC;
        private System.Windows.Forms.RadioButton rdBtnJ;
        private System.Windows.Forms.Label label3;
    }
}