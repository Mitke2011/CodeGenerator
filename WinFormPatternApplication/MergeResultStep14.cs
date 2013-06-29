
//using System;
//using System.Windows.Forms;
//using System.Threading;
////using KADGen.BusinessObjectSupport;

//namespace KADGen.WinProject
//{
//    public partial class layoutKupacEdit : Form
//    {


//        protected int mMargin = 5;
//        protected bool mbIsDirty;
//        protected string mCaption;

//        #region  class Declarations
//        protected System.Drawing.Size mMinimumSize = new System.Drawing.Size(270, 137);
//        protected int mLabelWidth = 120;
//        protected int mHorizontalMargin = 8;
//        protected int mIdealHeight = 117;
//        protected int mIdealWidth = -1;
//        protected int mVerticalMargin = 5;
//        protected System.Windows.Forms.Control mSampleControl;
//        #endregion

//        #region System.Windows Form Designer generated code

//        public layoutKupacEdit()
//            : base()
//        {
//            //This call is required by the System.Windows Form Designer.
//            InitializeComponent();

//            //Add any initialization after the InitializeComponent() call
//            mCaption = "";

//            grpKorpa.Height = this.Height - grpKorpa.Top - 5;


//        }

//        //Form overrides dispose to clean up the component list.
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                if (components != null)
//                {
//                    components.Dispose();
//                }
//            }
//            base.Dispose(disposing);
//        }

//        //Required by the System.Windows Form Designer
//        private System.ComponentModel.IContainer components;


//        internal System.Windows.Forms.Panel pnlKorpa;
//        internal System.Windows.Forms.GroupBox grpKorpa;
//        internal System.Windows.Forms.Button btnAddKorpa;
//        internal System.Windows.Forms.Button btnRemoveKorpa;
//        internal System.Windows.Forms.Button btnEditKorpa;
//        internal System.Windows.Forms.DataGrid dgKorpa;

//        internal System.Windows.Forms.ListBox lstRules;
//        internal System.Windows.Forms.CheckBox chkIsDirty;
//        internal System.Windows.Forms.Panel pnlDetail;
//        internal System.Windows.Forms.Panel pnlAll;
//        internal System.Windows.Forms.Panel pnlBottomShim;
//        internal System.Windows.Forms.Label lblForceScroll;

//        //NOTE: The following procedure is required by the System.Windows Form Designer
//        //It can be modified using the System.Windows Form Designer.  
//        //Do not modify it using the code editor.
//        [System.Diagnostics.DebuggerStepThrough()]
//        private void InitializeComponent()
//        {

//            this.grpKorpa = new System.Windows.Forms.GroupBox();
//            this.pnlKorpa = new System.Windows.Forms.Panel();
//            this.dgKorpa = new System.Windows.Forms.DataGrid();
//            this.btnAddKorpa = new System.Windows.Forms.Button();
//            this.btnRemoveKorpa = new System.Windows.Forms.Button();
//            this.btnEditKorpa = new System.Windows.Forms.Button();

//            this.grpKorpa.SuspendLayout();

//            this.lstRules = new System.Windows.Forms.ListBox();
//            this.chkIsDirty = new System.Windows.Forms.CheckBox();
//            this.pnlAll = new System.Windows.Forms.Panel();
//            this.pnlBottomShim = new System.Windows.Forms.Panel();
//            this.pnlDetail = new System.Windows.Forms.Panel();
//            this.lblForceScroll = new System.Windows.Forms.Label();
//            this.SuspendLayout();
//            //
//            // pnlAll
//            //
//            this.pnlAll.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.pnlAll.AutoScroll = true;
//            this.pnlAll.Controls.Add(lblForceScroll);
//            this.lblForceScroll.Width = 100 + 120 + this.errProvider.Icon.Width + 16;
//            //
//            // pnlDetail
//            //
//            //this.pnlDetail.Anchor = ( System.Windows.Forms.AnchorStyles )_
//            //            ( System.Windows.Forms.AnchorStyles.Top |
//            //            System.Windows.Forms.AnchorStyles.Left |
//            //			   System.Windows.Forms.AnchorStyles.Right ),
//            //         
//            this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Top;
//            this.pnlDetail.Size = new System.Drawing.Size(734 + errProvider.Icon.Width, 10);

//            //
//            // pnlBottomShim
//            //
//            this.pnlBottomShim.Dock = System.Windows.Forms.DockStyle.Top;
//            this.pnlBottomShim.Height = 5;


//            // 112
//            //
//            //grpKorpa
//            //
//            this.pnlKorpa.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.pnlKorpa.Height = 112;
//            this.pnlKorpa.Controls.Add(this.grpKorpa);
//            this.grpKorpa.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom |
//                     System.Windows.Forms.AnchorStyles.Top |
//                     System.Windows.Forms.AnchorStyles.Left |
//                    System.Windows.Forms.AnchorStyles.Right);
//            this.grpKorpa.Controls.Add(this.dgKorpa);
//            this.grpKorpa.Controls.Add(this.btnAddKorpa);
//            this.grpKorpa.Controls.Add(this.btnRemoveKorpa);
//            this.grpKorpa.Controls.Add(this.btnEditKorpa);
//            this.grpKorpa.Location = new System.Drawing.Point(8, 5);
//            this.grpKorpa.Name = "grpKorpa";
//            this.grpKorpa.Size = new System.Drawing.Size(734, 112);

//            this.grpKorpa.TabIndex = 0;
//            this.grpKorpa.TabStop = false;
//            this.grpKorpa.Text = "";

//            this.pnlAll.Controls.Add(this.pnlKorpa);
//            this.pnlKorpa.BringToFront();

//            //
//            //dgKorpa
//            //
//            this.dgKorpa.Anchor = (System.Windows.Forms.AnchorStyles)
//                        (System.Windows.Forms.AnchorStyles.Top |
//                        System.Windows.Forms.AnchorStyles.Bottom |
//                            System.Windows.Forms.AnchorStyles.Left |
//                            System.Windows.Forms.AnchorStyles.Right);
//            this.dgKorpa.CaptionVisible = false;
//            this.dgKorpa.DataSource = null;
//            this.dgKorpa.Location = new System.Drawing.Point(8, 20);
//            this.dgKorpa.Name = "dgKorpa";
//            this.dgKorpa.Size = new System.Drawing.Size(635, 82);

//            this.dgKorpa.TabIndex = 1;
//            this.dgKorpa.DoubleClick += new System.EventHandler(this.dgKorpa_DoubleClick);
//            this.dgKorpa.CurrentCellChanged += new System.EventHandler(this.dgKorpa_CurrentCellChanged);
//            ;
//            //
//            //btnAddKorpa
//            //
//            this.btnAddKorpa.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
//            this.btnAddKorpa.Location = new System.Drawing.Point(651, 20);
//            //5);
//            this.btnAddKorpa.Size = new System.Drawing.Size(75, 24);
//            this.btnAddKorpa.Name = "btnAddKorpa";
//            this.btnAddKorpa.TabIndex = 2;
//            this.btnAddKorpa.Text = "&Add";
//            this.btnAddKorpa.Click += new System.EventHandler(this.btnAddKorpa_Click);
//            //
//            //btnRemoveKorpa
//            //
//            this.btnRemoveKorpa.Anchor = (System.Windows.Forms.AnchorStyles)
//                        (System.Windows.Forms.AnchorStyles.Top |
//                        System.Windows.Forms.AnchorStyles.Right);
//            this.btnRemoveKorpa.Location = new System.Drawing.Point(651, 44);
//            //49);
//            this.btnRemoveKorpa.Size = new System.Drawing.Size(75, 24);
//            this.btnRemoveKorpa.Name = "btnRemoveKorpa";
//            this.btnRemoveKorpa.TabIndex = 3;
//            this.btnRemoveKorpa.Text = "&Remove";
//            this.btnRemoveKorpa.Click += new System.EventHandler(this.btnRemoveKorpa_Click);
//            //
//            //btnEditKorpa
//            //
//            this.btnEditKorpa.Anchor = (System.Windows.Forms.AnchorStyles)
//                        (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
//            this.btnEditKorpa.Location = new System.Drawing.Point(651, 68);
//            //78);
//            this.btnEditKorpa.Size = new System.Drawing.Size(75, 24);
//            this.btnEditKorpa.Name = "btnEditKorpa";
//            this.btnEditKorpa.TabIndex = 4;
//            this.btnEditKorpa.Text = "&Edit";
//            this.btnEditKorpa.Click += new System.EventHandler(this.btnEditKorpa_Click);

//            //
//            //lstRules
//            //
//            this.lstRules.Anchor = (System.Windows.Forms.AnchorStyles)
//                        (System.Windows.Forms.AnchorStyles.Top |
//                           System.Windows.Forms.AnchorStyles.Left |
//                               System.Windows.Forms.AnchorStyles.Right);
//            this.lstRules.Location = new System.Drawing.Point(544, 104);
//            this.lstRules.Name = "lstRules";
//            this.lstRules.Size = new System.Drawing.Size(192, 108);
//            this.lstRules.TabIndex = 5;
//            this.lstRules.Visible = false;
//            //
//            //chkIsDirty
//            //
//            this.chkIsDirty.Enabled = false;
//            this.chkIsDirty.Location = new System.Drawing.Point(488, 8);
//            this.chkIsDirty.Name = "chkIsDirty";
//            this.chkIsDirty.Size = new System.Drawing.Size(80, 0);
//            this.chkIsDirty.TabIndex = 6;
//            this.chkIsDirty.Text = "IsDirty";
//            //
//            // KupacEdit
//            //

//            // 10
//            // 122
//            // 1
//            this.pnlAll.Controls.Add(this.pnlDetail);
//            this.pnlAll.Controls.Add(this.pnlBottomShim);
//            this.ClientSize = new System.Drawing.Size(750, 222);
//            this.Controls.Add(this.chkIsDirty);
//            this.Controls.Add(this.lstRules);
//            this.Controls.Add(this.pnlAll);

//            this.Name = "genKupacEdit";
//            this.Text = "Kupac Edit";

//            this.grpKorpa.ResumeLayout(false);

//            this.ResumeLayout(false);

//        }

//        #endregion

//        #region Event Handlers
//        private void ctl_Validated(System.Object sender, System.EventArgs e)
//        {
//            OnCtlValidated(sender, e);
//        }
//        protected virtual void OnCtlValidated(System.Object sender, System.EventArgs e)
//        {
//        }

//        private void ctl_Changed(System.Object sender, System.EventArgs e)
//        {
//            OnDataChanged(sender, e);
//        }
//        protected override void OnDataChanged(System.Object sender, System.EventArgs e)
//        {
//            mbIsDirty = true;
//            base.OnDataChanged(sender, e);
//        }


//        private void btnAddKorpa_Click(System.Object sender, System.EventArgs e)
//        {
//            OnBtnAddKorpaClick(sender, e);
//        }
//        protected virtual void OnBtnAddKorpaClick(System.Object sender, System.EventArgs e)
//        {
//        }

//        private void btnRemoveKorpa_Click(System.Object sender, System.EventArgs e)
//        {
//            OnBtnRemoveKorpaClick(sender, e);
//        }
//        protected virtual void OnBtnRemoveKorpaClick(System.Object sender, System.EventArgs e)
//        {
//        }

//        private void btnEditKorpa_Click(System.Object sender, System.EventArgs e)
//        {
//            OnBtnEditKorpaClick(sender, e);
//        }
//        protected virtual void OnBtnEditKorpaClick(System.Object sender, System.EventArgs e)
//        {
//        }

//        private void dgKorpa_DoubleClick(System.Object sender, System.EventArgs e)
//        {
//            OnDataGridKorpaDoubleClick(sender, e);
//        }
//        protected virtual void OnDataGridKorpaDoubleClick(System.Object sender, System.EventArgs e)
//        {
//        }

//        private void dgKorpa_CurrentCellChanged(System.Object sender, System.EventArgs e)
//        {
//            OnDataGridKorpaCurrentCellChanged(sender, e);
//        }
//        protected virtual void OnDataGridKorpaCurrentCellChanged(System.Object sender, System.EventArgs e)
//        {
//        }


//        protected override void OnLayout(System.Windows.Forms.LayoutEventArgs e)
//        {
//            int width;
//            int height;
//            base.OnLayout(e);

//            //this.lblForceScroll.Height = 1;


//            width = grpKorpa.Width - btnAddKorpa.Width - 24;
//            if (grpKorpa.ClientSize.Height - btnEditKorpa.Bottom < 10)
//            {
//                height = btnEditKorpa.Bottom - dgKorpa.Top;
//            }
//            else
//            {
//                height = grpKorpa.Height - dgKorpa.Top - 5;
//            }
//            //height = grpKorpa.Height - dgKorpa.Top - 5;
//            dgKorpa.Size = new System.Drawing.Size(width, height);
//            //dgKorpa.Width = width;
//            btnAddKorpa.Left = width + 12;
//            btnRemoveKorpa.Left = btnAddKorpa.Left;
//            btnEditKorpa.Left = btnAddKorpa.Left;
//            grpKorpa.Size = new System.Drawing.Size(
//                        pnlKorpa.ClientSize.Width - 2 * 8,
//                        pnlKorpa.ClientSize.Height - grpKorpa.Top - 10);

//        }

//        protected override void OnLoad(System.EventArgs e)
//        {
//            base.OnLoad(e);
//            //pnlDetail.Width = this.pnlAll.Width;
//            //this.lblForceScroll.SendToBack();
//            this.pnlBottomShim.SendToBack();
//            this.lblForceScroll.Height = 1;
//            //this.lblForceScroll.Visible = false;
//        }
//        #endregion

//        #region Rest of form
//        protected override void ResizeUC()
//        {
//            base.ResizeUC();


//            grpKorpa.Height = this.Height - grpKorpa.Top - 5;
//            dgKorpa.Height = grpKorpa.Height - dgKorpa.Top - 10;

//            //this.pnlDetail.Size = new System.Drawing.Size(this.ClientSize.Width, 10);

//        }

//        #endregion

//    }
//}
