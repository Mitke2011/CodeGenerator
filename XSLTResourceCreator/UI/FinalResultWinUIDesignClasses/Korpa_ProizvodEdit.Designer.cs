

        namespace WinFormPatternApplication
        {
        partial class Korpa_ProizvodEdit
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

    
      this.lblSifraProizvoda = new System.Windows.Forms.Label();
      this.lblSifraProizvoda.AutoSize = true;
      this.lblSifraProizvoda.Name = "lblSifraProizvoda";
      this.lblSifraProizvoda.Location = new System.Drawing.Point(8, 5);
      this.lblSifraProizvoda.Size = new System.Drawing.Size(120, 20);
      this.lblSifraProizvoda.TabIndex = 1;
      this.lblSifraProizvoda.Text = "SifraProizvoda";
    
      this.lblSifraKorpe = new System.Windows.Forms.Label();
      this.lblSifraKorpe.AutoSize = true;
      this.lblSifraKorpe.Name = "lblSifraKorpe";
      this.lblSifraKorpe.Location = new System.Drawing.Point(8, 30);
      this.lblSifraKorpe.Size = new System.Drawing.Size(120, 20);
      this.lblSifraKorpe.TabIndex = 3;
      this.lblSifraKorpe.Text = "SifraKorpe";
    
      this.lblDatum_Kupovine = new System.Windows.Forms.Label();
      this.lblDatum_Kupovine.AutoSize = true;
      this.lblDatum_Kupovine.Name = "lblDatum_Kupovine";
      this.lblDatum_Kupovine.Location = new System.Drawing.Point(8, 55);
      this.lblDatum_Kupovine.Size = new System.Drawing.Size(120, 20);
      this.lblDatum_Kupovine.TabIndex = 5;
      this.lblDatum_Kupovine.Text = "Datum_Kupovine";
    
      this.cboSifraProizvoda= new System.Windows.Forms.ComboBox();
      this.cboSifraKorpe= new System.Windows.Forms.ComboBox();
      this.dtpDatum_Kupovine= new System.Windows.Forms.DateTimePicker();
    this.hdnID = new System.Windows.Forms.TextBox();
    
      
      this.cboSifraProizvoda.Location = new System.Drawing.Point(78, 30);

      this.cboSifraProizvoda.Name = "SifraProizvoda";
      this.cboSifraProizvoda.Size = new System.Drawing.Size(120, 20);
      this.cboSifraProizvoda.TabIndex =3;
      
        this.cboSifraProizvoda.Text = "SifraProizvoda";
      
        this.cboSifraProizvoda.FormattingEnabled = true;
      
      
      this.cboSifraKorpe.Location = new System.Drawing.Point(78, 70);

      this.cboSifraKorpe.Name = "SifraKorpe";
      this.cboSifraKorpe.Size = new System.Drawing.Size(120, 20);
      this.cboSifraKorpe.TabIndex =3;
      
        this.cboSifraKorpe.Text = "SifraKorpe";
      
        this.cboSifraKorpe.FormattingEnabled = true;
      
      
      this.dtpDatum_Kupovine.Location = new System.Drawing.Point(78, 110);

      this.dtpDatum_Kupovine.Name = "Datum_Kupovine";
      this.dtpDatum_Kupovine.Size = new System.Drawing.Size(120, 20);
      this.dtpDatum_Kupovine.TabIndex =3;
      
        this.dtpDatum_Kupovine.Text = "Datum_Kupovine";
      
    this.hdnID.Visible = false;
  
      this.Controls.Add(this.cboSifraProizvoda);
      this.Controls.Add(this.lblSifraProizvoda);
    
      this.Controls.Add(this.cboSifraKorpe);
      this.Controls.Add(this.lblSifraKorpe);
    
      this.Controls.Add(this.dtpDatum_Kupovine);
      this.Controls.Add(this.lblDatum_Kupovine);
    
    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    this.ClientSize = new System.Drawing.Size(750, 450);
    this.Name = "Korpa_Proizvod";
    this.Text = "Korpa_Proizvod";
    this.ResumeLayout(false);
    this.PerformLayout();
  
    }
  
      private System.Windows.Forms.Label lblSifraProizvoda;
    
      private System.Windows.Forms.Label lblSifraKorpe;
    
      private System.Windows.Forms.Label lblDatum_Kupovine;
    
      private  System.Windows.Forms.ComboBox cboSifraProizvoda;
    
      private  System.Windows.Forms.ComboBox cboSifraKorpe;
    
      private  System.Windows.Forms.DateTimePicker dtpDatum_Kupovine;
    
    private System.Windows.Forms.TextBox hdnID;
  
        }
        }
      