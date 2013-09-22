namespace User_Forms
{
    partial class FilesLocation
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
            this.btnObjects = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnSPLocation = new System.Windows.Forms.Button();
            this.btnUILocation = new System.Windows.Forms.Button();
            this.txtObjecDestination = new System.Windows.Forms.TextBox();
            this.txtDomainFiles = new System.Windows.Forms.TextBox();
            this.txtSPFiles = new System.Windows.Forms.TextBox();
            this.txtUIFiles = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnObjects
            // 
            this.btnObjects.Location = new System.Drawing.Point(559, 16);
            this.btnObjects.Name = "btnObjects";
            this.btnObjects.Size = new System.Drawing.Size(103, 50);
            this.btnObjects.TabIndex = 0;
            this.btnObjects.Text = "Set object files location";
            this.btnObjects.UseVisualStyleBackColor = true;
            this.btnObjects.Click += new System.EventHandler(this.btnObjects_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(559, 90);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 50);
            this.button2.TabIndex = 1;
            this.button2.Text = "Set domain files location";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSPLocation
            // 
            this.btnSPLocation.Location = new System.Drawing.Point(559, 160);
            this.btnSPLocation.Name = "btnSPLocation";
            this.btnSPLocation.Size = new System.Drawing.Size(103, 50);
            this.btnSPLocation.TabIndex = 2;
            this.btnSPLocation.Text = "Set SP files location";
            this.btnSPLocation.UseVisualStyleBackColor = true;
            this.btnSPLocation.Click += new System.EventHandler(this.btnSPLocation_Click);
            // 
            // btnUILocation
            // 
            this.btnUILocation.Location = new System.Drawing.Point(559, 231);
            this.btnUILocation.Name = "btnUILocation";
            this.btnUILocation.Size = new System.Drawing.Size(103, 50);
            this.btnUILocation.TabIndex = 3;
            this.btnUILocation.Text = "Set UI files location";
            this.btnUILocation.UseVisualStyleBackColor = true;
            this.btnUILocation.Click += new System.EventHandler(this.btnUILocation_Click);
            // 
            // txtObjecDestination
            // 
            this.txtObjecDestination.Location = new System.Drawing.Point(252, 32);
            this.txtObjecDestination.Name = "txtObjecDestination";
            this.txtObjecDestination.Size = new System.Drawing.Size(274, 20);
            this.txtObjecDestination.TabIndex = 4;
            // 
            // txtDomainFiles
            // 
            this.txtDomainFiles.Location = new System.Drawing.Point(252, 106);
            this.txtDomainFiles.Name = "txtDomainFiles";
            this.txtDomainFiles.Size = new System.Drawing.Size(274, 20);
            this.txtDomainFiles.TabIndex = 5;
            // 
            // txtSPFiles
            // 
            this.txtSPFiles.Location = new System.Drawing.Point(252, 176);
            this.txtSPFiles.Name = "txtSPFiles";
            this.txtSPFiles.Size = new System.Drawing.Size(274, 20);
            this.txtSPFiles.TabIndex = 6;
            // 
            // txtUIFiles
            // 
            this.txtUIFiles.Location = new System.Drawing.Point(252, 247);
            this.txtUIFiles.Name = "txtUIFiles";
            this.txtUIFiles.Size = new System.Drawing.Size(274, 20);
            this.txtUIFiles.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Location for object files";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Location for domain files";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Location for stored procedure files";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Location for UI files";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(330, 303);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FilesLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 349);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUIFiles);
            this.Controls.Add(this.txtSPFiles);
            this.Controls.Add(this.txtDomainFiles);
            this.Controls.Add(this.txtObjecDestination);
            this.Controls.Add(this.btnUILocation);
            this.Controls.Add(this.btnSPLocation);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnObjects);
            this.Name = "FilesLocation";
            this.Text = "FilesLocation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnObjects;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSPLocation;
        private System.Windows.Forms.Button btnUILocation;
        private System.Windows.Forms.TextBox txtObjecDestination;
        private System.Windows.Forms.TextBox txtDomainFiles;
        private System.Windows.Forms.TextBox txtSPFiles;
        private System.Windows.Forms.TextBox txtUIFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}