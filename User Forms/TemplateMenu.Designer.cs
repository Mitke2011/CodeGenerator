namespace User_Forms
{
    partial class TemplateMenu
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.createNewTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editExistingTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.existingTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createTemplateFromClassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.javaClassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateClassFromTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateDomainClassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateDBManagerClassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateNUnitTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateFilesFromDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.configurationSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewTemplateToolStripMenuItem,
            this.classGeneratorToolStripMenuItem,
            this.configurationSettingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(472, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // createNewTemplateToolStripMenuItem
            // 
            this.createNewTemplateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editExistingTemplateToolStripMenuItem,
            this.existingTemplateToolStripMenuItem,
            this.createTemplateFromClassToolStripMenuItem});
            this.createNewTemplateToolStripMenuItem.Name = "createNewTemplateToolStripMenuItem";
            this.createNewTemplateToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.createNewTemplateToolStripMenuItem.Text = "Templates";
            // 
            // editExistingTemplateToolStripMenuItem
            // 
            this.editExistingTemplateToolStripMenuItem.Name = "editExistingTemplateToolStripMenuItem";
            this.editExistingTemplateToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.editExistingTemplateToolStripMenuItem.Text = "Create new XML template";
            this.editExistingTemplateToolStripMenuItem.Click += new System.EventHandler(this.editExistingTemplateToolStripMenuItem_Click);
            // 
            // existingTemplateToolStripMenuItem
            // 
            this.existingTemplateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.existingTemplateToolStripMenuItem.Name = "existingTemplateToolStripMenuItem";
            this.existingTemplateToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.existingTemplateToolStripMenuItem.Text = "Existing template";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // createTemplateFromClassToolStripMenuItem
            // 
            this.createTemplateFromClassToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cToolStripMenuItem,
            this.javaClassToolStripMenuItem});
            this.createTemplateFromClassToolStripMenuItem.Name = "createTemplateFromClassToolStripMenuItem";
            this.createTemplateFromClassToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.createTemplateFromClassToolStripMenuItem.Text = "Create template from class";
            // 
            // cToolStripMenuItem
            // 
            this.cToolStripMenuItem.Name = "cToolStripMenuItem";
            this.cToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.cToolStripMenuItem.Text = "C # class";
            this.cToolStripMenuItem.Click += new System.EventHandler(this.cToolStripMenuItem_Click);
            // 
            // javaClassToolStripMenuItem
            // 
            this.javaClassToolStripMenuItem.Name = "javaClassToolStripMenuItem";
            this.javaClassToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.javaClassToolStripMenuItem.Text = "Java class";
            // 
            // classGeneratorToolStripMenuItem
            // 
            this.classGeneratorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateClassFromTemplateToolStripMenuItem,
            this.generateFilesFromDatabaseToolStripMenuItem});
            this.classGeneratorToolStripMenuItem.Name = "classGeneratorToolStripMenuItem";
            this.classGeneratorToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.classGeneratorToolStripMenuItem.Text = "Class generator";
            // 
            // generateClassFromTemplateToolStripMenuItem
            // 
            this.generateClassFromTemplateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateDomainClassToolStripMenuItem,
            this.generateDBManagerClassToolStripMenuItem,
            this.generateNUnitTestsToolStripMenuItem});
            this.generateClassFromTemplateToolStripMenuItem.Name = "generateClassFromTemplateToolStripMenuItem";
            this.generateClassFromTemplateToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.generateClassFromTemplateToolStripMenuItem.Text = "Generate class from template";
            // 
            // generateDomainClassToolStripMenuItem
            // 
            this.generateDomainClassToolStripMenuItem.Name = "generateDomainClassToolStripMenuItem";
            this.generateDomainClassToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.generateDomainClassToolStripMenuItem.Text = "Generate domain class";
            this.generateDomainClassToolStripMenuItem.Click += new System.EventHandler(this.generateDomainClassToolStripMenuItem_Click);
            // 
            // generateDBManagerClassToolStripMenuItem
            // 
            this.generateDBManagerClassToolStripMenuItem.Name = "generateDBManagerClassToolStripMenuItem";
            this.generateDBManagerClassToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.generateDBManagerClassToolStripMenuItem.Text = "Generate DB Manager class";
            this.generateDBManagerClassToolStripMenuItem.Click += new System.EventHandler(this.generateDBManagerClassToolStripMenuItem_Click);
            // 
            // generateNUnitTestsToolStripMenuItem
            // 
            this.generateNUnitTestsToolStripMenuItem.Name = "generateNUnitTestsToolStripMenuItem";
            this.generateNUnitTestsToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.generateNUnitTestsToolStripMenuItem.Text = "Generate NUnit tests";
            // 
            // generateFilesFromDatabaseToolStripMenuItem
            // 
            this.generateFilesFromDatabaseToolStripMenuItem.Name = "generateFilesFromDatabaseToolStripMenuItem";
            this.generateFilesFromDatabaseToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.generateFilesFromDatabaseToolStripMenuItem.Text = "Generate files from database";
            this.generateFilesFromDatabaseToolStripMenuItem.Click += new System.EventHandler(this.generateFilesFromDatabaseToolStripMenuItem_Click);
            // 
            // configurationSettingsToolStripMenuItem
            // 
            this.configurationSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeConfigurationToolStripMenuItem});
            this.configurationSettingsToolStripMenuItem.Name = "configurationSettingsToolStripMenuItem";
            this.configurationSettingsToolStripMenuItem.Size = new System.Drawing.Size(137, 20);
            this.configurationSettingsToolStripMenuItem.Text = "Configuration settings";
            // 
            // changeConfigurationToolStripMenuItem
            // 
            this.changeConfigurationToolStripMenuItem.Name = "changeConfigurationToolStripMenuItem";
            this.changeConfigurationToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.changeConfigurationToolStripMenuItem.Text = "Change configuration";
            this.changeConfigurationToolStripMenuItem.Click += new System.EventHandler(this.changeConfigurationToolStripMenuItem_Click);
            // 
            // TemplateMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 344);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Menu = this.mainMenu1;
            this.Name = "TemplateMenu";
            this.Text = "TemplateMenu";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem createNewTemplateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editExistingTemplateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem existingTemplateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classGeneratorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateClassFromTemplateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateDomainClassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateDBManagerClassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateNUnitTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createTemplateFromClassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem javaClassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateFilesFromDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurationSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeConfigurationToolStripMenuItem;
        private System.Windows.Forms.MainMenu mainMenu1;


    }
}