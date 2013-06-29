

        namespace WinFormPatternApplication
        {
        partial class KorpaEdit
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

    
      this.lblSifraKupca = new System.Windows.Forms.Label();
      this.lblSifraKupca.AutoSize = true;
      this.lblSifraKupca.Name = "lblSifraKupca";
      this.lblSifraKupca.Location = new System.Drawing.Point(8, 5);
      this.lblSifraKupca.Size = new System.Drawing.Size(120, 20);
      this.lblSifraKupca.TabIndex = 1;
      this.lblSifraKupca.Text = "SifraKupca";
    
      this.lblDatum = new System.Windows.Forms.Label();
      this.lblDatum.AutoSize = true;
      this.lblDatum.Name = "lblDatum";
      this.lblDatum.Location = new System.Drawing.Point(8, 30);
      this.lblDatum.Size = new System.Drawing.Size(120, 20);
      this.lblDatum.TabIndex = 3;
      this.lblDatum.Text = "Datum";
    
      this.cboSifraKupca= new System.Windows.Forms.ComboBox();
      this.dtpDatum= new System.Windows.Forms.DateTimePicker();
    this.hdnID = new System.Windows.Forms.TextBox();
    
      
      this.cboSifraKupca.Location = new System.Drawing.Point(78, 5);

      this.cboSifraKupca.Name = "SifraKupca";
      this.cboSifraKupca.Size = new System.Drawing.Size(120, 20);
      this.cboSifraKupca.TabIndex =1;
      
        this.cboSifraKupca.Text = "SifraKupca";
      
        this.cboSifraKupca.FormattingEnabled = true;
      
      
      this.dtpDatum.Location = new System.Drawing.Point(78, 45);

      this.dtpDatum.Name = "Datum";
      this.dtpDatum.Size = new System.Drawing.Size(120, 20);
      this.dtpDatum.TabIndex =1;
      
        this.dtpDatum.Text = "Datum";
      
    this.hdnID.Visible = false;
  
      this.Controls.Add(this.cboSifraKupca);
      this.Controls.Add(this.lblSifraKupca);
    
      this.Controls.Add(this.dtpDatum);
      this.Controls.Add(this.lblDatum);
    
    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    this.ClientSize = new System.Drawing.Size(750, 450);
    this.Name = "Korpa";
    this.Text = "Korpa";
    this.ResumeLayout(false);
    this.PerformLayout();
  
    }
  
      private System.Windows.Forms.Label lblSifraKupca;
    
      private System.Windows.Forms.Label lblDatum;
    
      private  System.Windows.Forms.ComboBox cboSifraKupca;
    
      private  System.Windows.Forms.DateTimePicker dtpDatum;
    
    private System.Windows.Forms.TextBox hdnID;
  
        }
        }
      