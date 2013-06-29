

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
      this.lblNaziv.AutoSize = true;
      this.lblNaziv.Name = "lblNaziv";
      this.lblNaziv.Location = new System.Drawing.Point(8, 5);
      this.lblNaziv.Size = new System.Drawing.Size(120, 20);
      this.lblNaziv.TabIndex = 1;
      this.lblNaziv.Text = "Naziv";
    
      this.lblKolicina = new System.Windows.Forms.Label();
      this.lblKolicina.AutoSize = true;
      this.lblKolicina.Name = "lblKolicina";
      this.lblKolicina.Location = new System.Drawing.Point(8, 30);
      this.lblKolicina.Size = new System.Drawing.Size(120, 20);
      this.lblKolicina.TabIndex = 3;
      this.lblKolicina.Text = "Kolicina";
    
      this.txtNaziv= new System.Windows.Forms.TextBox();
      this.txtKolicina= new System.Windows.Forms.TextBox();
    this.hdnID = new System.Windows.Forms.TextBox();
    
      
      this.txtNaziv.Location = new System.Drawing.Point(78, 55);

      this.txtNaziv.Name = "Naziv";
      this.txtNaziv.Size = new System.Drawing.Size(120, 20);
      this.txtNaziv.TabIndex =5;
      
      
      this.txtKolicina.Location = new System.Drawing.Point(78, 95);

      this.txtKolicina.Name = "Kolicina";
      this.txtKolicina.Size = new System.Drawing.Size(120, 20);
      this.txtKolicina.TabIndex =5;
      
    this.hdnID.Visible = false;
  
      this.Controls.Add(this.txtNaziv);
      this.Controls.Add(this.lblNaziv);
    
      this.Controls.Add(this.txtKolicina);
      this.Controls.Add(this.lblKolicina);
    
    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    this.ClientSize = new System.Drawing.Size(750, 450);
    this.Name = "Proizvod";
    this.Text = "Proizvod";
    this.ResumeLayout(false);
    this.PerformLayout();
  
    }
  
      private System.Windows.Forms.Label lblNaziv;
    
      private System.Windows.Forms.Label lblKolicina;
    
      private  System.Windows.Forms.TextBox txtNaziv;
    
      private  System.Windows.Forms.TextBox txtKolicina;
    
    private System.Windows.Forms.TextBox hdnID;
  
        }
        }
      