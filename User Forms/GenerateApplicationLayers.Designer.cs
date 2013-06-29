namespace User_Forms
{
    partial class GenerateApplicationLayers
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
            this.btnStartGen = new System.Windows.Forms.Button();
            this.cbDB = new System.Windows.Forms.CheckBox();
            this.cbUI = new System.Windows.Forms.CheckBox();
            this.cbDomainClasses = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnStartGen
            // 
            this.btnStartGen.Location = new System.Drawing.Point(355, 206);
            this.btnStartGen.Name = "btnStartGen";
            this.btnStartGen.Size = new System.Drawing.Size(75, 23);
            this.btnStartGen.TabIndex = 0;
            this.btnStartGen.Text = "Start generator";
            this.btnStartGen.UseVisualStyleBackColor = true;
            this.btnStartGen.Click += new System.EventHandler(this.btnStartGen_Click);
            // 
            // cbDB
            // 
            this.cbDB.AutoSize = true;
            this.cbDB.Location = new System.Drawing.Point(23, 51);
            this.cbDB.Name = "cbDB";
            this.cbDB.Size = new System.Drawing.Size(151, 17);
            this.cbDB.TabIndex = 1;
            this.cbDB.Text = "Create Storred Procedures";
            this.cbDB.UseVisualStyleBackColor = true;
            // 
            // cbUI
            // 
            this.cbUI.AutoSize = true;
            this.cbUI.Location = new System.Drawing.Point(24, 149);
            this.cbUI.Name = "cbUI";
            this.cbUI.Size = new System.Drawing.Size(100, 17);
            this.cbUI.TabIndex = 2;
            this.cbUI.Text = "Create UI Layer";
            this.cbUI.UseVisualStyleBackColor = true;
            // 
            // cbDomainClasses
            // 
            this.cbDomainClasses.AutoSize = true;
            this.cbDomainClasses.Location = new System.Drawing.Point(24, 98);
            this.cbDomainClasses.Name = "cbDomainClasses";
            this.cbDomainClasses.Size = new System.Drawing.Size(135, 17);
            this.cbDomainClasses.TabIndex = 3;
            this.cbDomainClasses.Text = "Create Domain Classes";
            this.cbDomainClasses.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(533, 45);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(259, 20);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(533, 95);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(259, 20);
            this.textBox2.TabIndex = 5;
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(533, 146);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(259, 20);
            this.textBox3.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Chose application layer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(648, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "File paths";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(288, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Options";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(254, 149);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.Text = "Chose UI type";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(200, 95);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(259, 20);
            this.textBox4.TabIndex = 11;
            this.textBox4.Text = "Add connection string";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(200, 48);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(259, 20);
            this.textBox5.TabIndex = 12;
            this.textBox5.Text = "Add connection string";
            // 
            // GenerateApplicationLayers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 262);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cbDomainClasses);
            this.Controls.Add(this.cbUI);
            this.Controls.Add(this.cbDB);
            this.Controls.Add(this.btnStartGen);
            this.Name = "GenerateApplicationLayers";
            this.Text = "GenerateApplicationLayers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartGen;
        private System.Windows.Forms.CheckBox cbDB;
        private System.Windows.Forms.CheckBox cbUI;
        private System.Windows.Forms.CheckBox cbDomainClasses;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
    }
}