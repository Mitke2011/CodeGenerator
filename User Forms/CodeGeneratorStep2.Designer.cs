namespace User_Forms
{
    partial class CodeGeneratorStep2
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
            this.cbUI = new System.Windows.Forms.CheckBox();
            this.cbSP = new System.Windows.Forms.CheckBox();
            this.cbObjects = new System.Windows.Forms.CheckBox();
            this.cbDomainclasses = new System.Windows.Forms.CheckBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbUI
            // 
            this.cbUI.AutoSize = true;
            this.cbUI.Location = new System.Drawing.Point(29, 12);
            this.cbUI.Name = "cbUI";
            this.cbUI.Size = new System.Drawing.Size(137, 17);
            this.cbUI.TabIndex = 0;
            this.cbUI.Text = "Generate user interface";
            this.cbUI.UseVisualStyleBackColor = true;
            // 
            // cbSP
            // 
            this.cbSP.AutoSize = true;
            this.cbSP.Location = new System.Drawing.Point(180, 12);
            this.cbSP.Name = "cbSP";
            this.cbSP.Size = new System.Drawing.Size(158, 17);
            this.cbSP.TabIndex = 1;
            this.cbSP.Text = "Generate stored procedures";
            this.cbSP.UseVisualStyleBackColor = true;
            // 
            // cbObjects
            // 
            this.cbObjects.AutoSize = true;
            this.cbObjects.Location = new System.Drawing.Point(29, 73);
            this.cbObjects.Name = "cbObjects";
            this.cbObjects.Size = new System.Drawing.Size(140, 17);
            this.cbObjects.TabIndex = 2;
            this.cbObjects.Text = "Generate object classes";
            this.cbObjects.UseVisualStyleBackColor = true;
            // 
            // cbDomainclasses
            // 
            this.cbDomainclasses.AutoSize = true;
            this.cbDomainclasses.Location = new System.Drawing.Point(180, 73);
            this.cbDomainclasses.Name = "cbDomainclasses";
            this.cbDomainclasses.Size = new System.Drawing.Size(145, 17);
            this.cbDomainclasses.TabIndex = 3;
            this.cbDomainclasses.Text = "Generate domain classes";
            this.cbDomainclasses.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(115, 134);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // CodeGeneratorStep2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 194);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.cbDomainclasses);
            this.Controls.Add(this.cbObjects);
            this.Controls.Add(this.cbSP);
            this.Controls.Add(this.cbUI);
            this.Name = "CodeGeneratorStep2";
            this.Text = "CodeGeneratorStep2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbUI;
        private System.Windows.Forms.CheckBox cbSP;
        private System.Windows.Forms.CheckBox cbObjects;
        private System.Windows.Forms.CheckBox cbDomainclasses;
        private System.Windows.Forms.Button btnNext;
    }
}