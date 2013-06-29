

    namespace WinFormPatternApplication
    {
    partial class KupacEdit
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
    
      this.lblIme = new System.Windows.Forms.Label();
      this.lblIme.AutoSize = true;
      this.lblIme.Name = "lblIme";
      this.lblIme.Location = new System.Drawing.Point(8, 2);
      this.lblIme.Size = new System.Drawing.Size(120, 20);
      this.lblIme.TabIndex = 1;
      this.lblIme.Text = "Ime";
    
      this.lblPrezime = new System.Windows.Forms.Label();
      this.lblPrezime.AutoSize = true;
      this.lblPrezime.Name = "lblPrezime";
      this.lblPrezime.Location = new System.Drawing.Point(8, 2);
      this.lblPrezime.Size = new System.Drawing.Size(120, 20);
      this.lblPrezime.TabIndex = 1;
      this.lblPrezime.Text = "Prezime";
    
      this.lblBrojTelefona = new System.Windows.Forms.Label();
      this.lblBrojTelefona.AutoSize = true;
      this.lblBrojTelefona.Name = "lblBrojTelefona";
      this.lblBrojTelefona.Location = new System.Drawing.Point(8, 2);
      this.lblBrojTelefona.Size = new System.Drawing.Size(120, 20);
      this.lblBrojTelefona.TabIndex = 1;
      this.lblBrojTelefona.Text = "BrojTelefona";
    
      this.lblAdresa = new System.Windows.Forms.Label();
      this.lblAdresa.AutoSize = true;
      this.lblAdresa.Name = "lblAdresa";
      this.lblAdresa.Location = new System.Drawing.Point(8, 2);
      this.lblAdresa.Size = new System.Drawing.Size(120, 20);
      this.lblAdresa.TabIndex = 1;
      this.lblAdresa.Text = "Adresa";
    
      this.txtIme= new System.Windows.Forms.TextBox();
      this.txtPrezime= new System.Windows.Forms.TextBox();
      this.txtBrojTelefona= new System.Windows.Forms.TextBox();
      this.txtAdresa= new System.Windows.Forms.TextBox();
    this.hdnID = new System.Windows.Forms.TextBox();
    
      this.txtIme.Location = new System.Drawing.Point(78, 2);

      this.txtIme.Name = "Ime";
      this.txtIme.Size = new System.Drawing.Size(120, 20);
      this.txtIme.TabIndex =1;
      
      this.txtPrezime.Location = new System.Drawing.Point(78, 42);

      this.txtPrezime.Name = "Prezime";
      this.txtPrezime.Size = new System.Drawing.Size(120, 20);
      this.txtPrezime.TabIndex =1;
      
      this.txtBrojTelefona.Location = new System.Drawing.Point(78, 82);

      this.txtBrojTelefona.Name = "BrojTelefona";
      this.txtBrojTelefona.Size = new System.Drawing.Size(120, 20);
      this.txtBrojTelefona.TabIndex =1;
      
      this.txtAdresa.Location = new System.Drawing.Point(78, 122);

      this.txtAdresa.Name = "Adresa";
      this.txtAdresa.Size = new System.Drawing.Size(120, 20);
      this.txtAdresa.TabIndex =1;
        
    this.hdnID.Visible = false;
  
      this.Controls.Add(this.txtIme);
      this.Controls.Add(this.lblIme);
    
      this.Controls.Add(this.txtPrezime);
      this.Controls.Add(this.lblPrezime);
    
      this.Controls.Add(this.txtBrojTelefona);
      this.Controls.Add(this.lblBrojTelefona);
    
      this.Controls.Add(this.txtAdresa);
      this.Controls.Add(this.lblAdresa);
    
    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    this.ClientSize = new System.Drawing.Size(750, 450);
    this.Name = "KupacEdit";
    this.Text = "KupacEdit";
    this.ResumeLayout(false);
    this.PerformLayout();
  
    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    this.ClientSize = new System.Drawing.Size(750, 450);
    this.Name = "KupacSelect";
    this.Text = "KupacSelect";
    this.ResumeLayout(false);
    this.PerformLayout();
  
    }
  
      private System.Windows.Forms.Label lblIme;
    
      private System.Windows.Forms.Label lblPrezime;
    
      private System.Windows.Forms.Label lblBrojTelefona;
    
      private System.Windows.Forms.Label lblAdresa;
    
      private  System.Windows.Forms.TextBox txtIme;
    
      private  System.Windows.Forms.TextBox txtPrezime;
    
      private  System.Windows.Forms.TextBox txtBrojTelefona;
    
      private  System.Windows.Forms.TextBox txtAdresa;
    
    private System.Windows.Forms.TextBox hdnID;
  
    }
    }

  