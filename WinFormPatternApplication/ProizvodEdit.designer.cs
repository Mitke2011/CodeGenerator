

namespace WinFormPatternApplication
        {
        partial class ProizvodEdit
        {
        private System.ComponentModel.IContainer components = null;

        
    protected override void Dispose(bool disposing)
    {
    if (disposing && (components != null))
    {
    components.Dispose();
    }
    base.Dispose(disposing);
    }
  
    protected void InitializeComponent()
    {
            this.lblNaziv = new System.Windows.Forms.Label();
            this.lblKolicina = new System.Windows.Forms.Label();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.txtKolicina = new System.Windows.Forms.TextBox();
            this.hdnID = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNaziv
            // 
            this.lblNaziv.AutoSize = true;
            this.lblNaziv.Location = new System.Drawing.Point(8, 5);
            this.lblNaziv.Name = "lblNaziv";
            this.lblNaziv.Size = new System.Drawing.Size(34, 13);
            this.lblNaziv.TabIndex = 1;
            this.lblNaziv.Text = "Naziv";
            // 
            // lblKolicina
            // 
            this.lblKolicina.AutoSize = true;
            this.lblKolicina.Location = new System.Drawing.Point(8, 30);
            this.lblKolicina.Name = "lblKolicina";
            this.lblKolicina.Size = new System.Drawing.Size(44, 13);
            this.lblKolicina.TabIndex = 3;
            this.lblKolicina.Text = "Kolicina";
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(78, 55);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(120, 20);
            this.txtNaziv.TabIndex = 5;
            // 
            // txtKolicina
            // 
            this.txtKolicina.Location = new System.Drawing.Point(78, 95);
            this.txtKolicina.Name = "txtKolicina";
            this.txtKolicina.Size = new System.Drawing.Size(120, 20);
            this.txtKolicina.TabIndex = 5;
            // 
            // hdnID
            // 
            this.hdnID.Location = new System.Drawing.Point(0, 0);
            this.hdnID.Name = "hdnID";
            this.hdnID.Size = new System.Drawing.Size(100, 20);
            this.hdnID.TabIndex = 0;
            this.hdnID.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(600, 52);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(600, 85);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(126, 23);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ProizvodEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 450);
            this.Controls.Add(this.txtNaziv);
            this.Controls.Add(this.lblNaziv);
            this.Controls.Add(this.txtKolicina);
            this.Controls.Add(this.lblKolicina);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Name = "ProizvodEdit";
            this.Text = "Proizvod";
            this.ResumeLayout(false);
            this.PerformLayout();

    }
  
      private System.Windows.Forms.Label lblNaziv;
    
      private System.Windows.Forms.Label lblKolicina;
    
      private  System.Windows.Forms.TextBox txtNaziv;
    
      private  System.Windows.Forms.TextBox txtKolicina;
    
      private System.Windows.Forms.TextBox hdnID;
      private System.Windows.Forms.Button  btnSave;
      private System.Windows.Forms.Button  btnDelete;
  
        }
        }
      