

          namespace WinFormPatternApplication
        {
        partial class KupacList
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

    this.dataGridView1 = new System.Windows.Forms.DataGridView();
    
          
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(58, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(579, 150);
            this.dataGridView1.TabIndex = 1;
  
    this.Controls.Add(this.dataGridView1);
  
    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    this.ClientSize = new System.Drawing.Size(750, 450);
    this.Name = "Kupac";
    this.Text = "Kupac";
      this.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
  
    }
  
    private System.Windows.Forms.DataGridView dataGridView1;
  
        }
        }
      