namespace XmlHtmlSitemap
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lbURL = new System.Windows.Forms.Label();
            this.tbURL = new System.Windows.Forms.TextBox();
            this.tbDestinationFolder = new System.Windows.Forms.TextBox();
            this.lbFileLocation = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.lbFilter = new System.Windows.Forms.Label();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.btnBrouseDirectory = new System.Windows.Forms.Button();
            this.cbGenerateHtmlFile = new System.Windows.Forms.CheckBox();
            this.lbEncoding = new System.Windows.Forms.Label();
            this.comboBoxEncoding = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.cbGenerateXmlFile = new System.Windows.Forms.CheckBox();
            this.comboBoxPriority = new System.Windows.Forms.ComboBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.comboBoxLastModification = new System.Windows.Forms.ComboBox();
            this.cbPriority = new System.Windows.Forms.CheckBox();
            this.cbChangeFrequency = new System.Windows.Forms.CheckBox();
            this.cbLastModification = new System.Windows.Forms.CheckBox();
            this.comboBoxChangeFrequency = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxPageTitle = new System.Windows.Forms.ComboBox();
            this.lbPageTitle = new System.Windows.Forms.Label();
            this.cbUseLocal = new System.Windows.Forms.CheckBox();
            this.lbLocalPath = new System.Windows.Forms.Label();
            this.tbLocalPath = new System.Windows.Forms.TextBox();
            this.btnBrowseLocalPath = new System.Windows.Forms.Button();
            this.cbIncludeNotFound = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbURL
            // 
            resources.ApplyResources(this.lbURL, "lbURL");
            this.lbURL.Name = "lbURL";
            // 
            // tbURL
            // 
            resources.ApplyResources(this.tbURL, "tbURL");
            this.tbURL.Name = "tbURL";
            // 
            // tbDestinationFolder
            // 
            resources.ApplyResources(this.tbDestinationFolder, "tbDestinationFolder");
            this.tbDestinationFolder.Name = "tbDestinationFolder";
            // 
            // lbFileLocation
            // 
            resources.ApplyResources(this.lbFileLocation, "lbFileLocation");
            this.lbFileLocation.Name = "lbFileLocation";
            // 
            // btnRun
            // 
            resources.ApplyResources(this.btnRun, "btnRun");
            this.btnRun.Name = "btnRun";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // lbFilter
            // 
            resources.ApplyResources(this.lbFilter, "lbFilter");
            this.lbFilter.Name = "lbFilter";
            // 
            // tbFilter
            // 
            resources.ApplyResources(this.tbFilter, "tbFilter");
            this.tbFilter.Name = "tbFilter";
            // 
            // btnBrouseDirectory
            // 
            resources.ApplyResources(this.btnBrouseDirectory, "btnBrouseDirectory");
            this.btnBrouseDirectory.Name = "btnBrouseDirectory";
            this.btnBrouseDirectory.UseVisualStyleBackColor = true;
            this.btnBrouseDirectory.Click += new System.EventHandler(this.btnBrouseDirectory_Click);
            // 
            // cbGenerateHtmlFile
            // 
            resources.ApplyResources(this.cbGenerateHtmlFile, "cbGenerateHtmlFile");
            this.cbGenerateHtmlFile.Name = "cbGenerateHtmlFile";
            this.cbGenerateHtmlFile.UseVisualStyleBackColor = true;
            this.cbGenerateHtmlFile.CheckedChanged += new System.EventHandler(this.cbGenerateHtmlFile_CheckedChanged);
            // 
            // lbEncoding
            // 
            resources.ApplyResources(this.lbEncoding, "lbEncoding");
            this.lbEncoding.Name = "lbEncoding";
            // 
            // comboBoxEncoding
            // 
            this.comboBoxEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEncoding.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxEncoding, "comboBoxEncoding");
            this.comboBoxEncoding.Name = "comboBoxEncoding";
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cbGenerateXmlFile
            // 
            resources.ApplyResources(this.cbGenerateXmlFile, "cbGenerateXmlFile");
            this.cbGenerateXmlFile.Name = "cbGenerateXmlFile";
            this.cbGenerateXmlFile.UseVisualStyleBackColor = true;
            this.cbGenerateXmlFile.CheckedChanged += new System.EventHandler(this.cbGenerateXmlFile_CheckedChanged);
            // 
            // comboBoxPriority
            // 
            this.comboBoxPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.comboBoxPriority, "comboBoxPriority");
            this.comboBoxPriority.FormattingEnabled = true;
            this.comboBoxPriority.Items.AddRange(new object[] {
            global::XmlHtmlSitemap.Properties.Resources.String21});
            this.comboBoxPriority.Name = "comboBoxPriority";
            // 
            // dateTimePicker
            // 
            resources.ApplyResources(this.dateTimePicker, "dateTimePicker");
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.ShowUpDown = true;
            // 
            // comboBoxLastModification
            // 
            this.comboBoxLastModification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.comboBoxLastModification, "comboBoxLastModification");
            this.comboBoxLastModification.FormattingEnabled = true;
            this.comboBoxLastModification.Items.AddRange(new object[] {
            global::XmlHtmlSitemap.Properties.Resources.String22,
            global::XmlHtmlSitemap.Properties.Resources.String23});
            this.comboBoxLastModification.Name = "comboBoxLastModification";
            this.comboBoxLastModification.SelectedIndexChanged += new System.EventHandler(this.comboBoxLastModified_SelectedIndexChanged);
            // 
            // cbPriority
            // 
            resources.ApplyResources(this.cbPriority, "cbPriority");
            this.cbPriority.Name = "cbPriority";
            this.cbPriority.UseVisualStyleBackColor = true;
            this.cbPriority.CheckedChanged += new System.EventHandler(this.cbPriority_CheckedChanged);
            this.cbPriority.EnabledChanged += new System.EventHandler(this.cbPriority_EnabledChanged);
            // 
            // cbChangeFrequency
            // 
            resources.ApplyResources(this.cbChangeFrequency, "cbChangeFrequency");
            this.cbChangeFrequency.Name = "cbChangeFrequency";
            this.cbChangeFrequency.UseVisualStyleBackColor = true;
            this.cbChangeFrequency.CheckedChanged += new System.EventHandler(this.cbChangeFrequency_CheckedChanged);
            this.cbChangeFrequency.EnabledChanged += new System.EventHandler(this.cbChangeFrequency_EnabledChanged);
            // 
            // cbLastModification
            // 
            resources.ApplyResources(this.cbLastModification, "cbLastModification");
            this.cbLastModification.Name = "cbLastModification";
            this.cbLastModification.UseVisualStyleBackColor = true;
            this.cbLastModification.CheckedChanged += new System.EventHandler(this.cbLastModification_CheckedChanged);
            this.cbLastModification.EnabledChanged += new System.EventHandler(this.cbLastModification_EnabledChanged);
            // 
            // comboBoxChangeFrequency
            // 
            this.comboBoxChangeFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.comboBoxChangeFrequency, "comboBoxChangeFrequency");
            this.comboBoxChangeFrequency.FormattingEnabled = true;
            this.comboBoxChangeFrequency.Items.AddRange(new object[] {
            global::XmlHtmlSitemap.Properties.Resources.String27,
            global::XmlHtmlSitemap.Properties.Resources.String28,
            global::XmlHtmlSitemap.Properties.Resources.String29,
            global::XmlHtmlSitemap.Properties.Resources.String30,
            global::XmlHtmlSitemap.Properties.Resources.String31,
            global::XmlHtmlSitemap.Properties.Resources.String32,
            global::XmlHtmlSitemap.Properties.Resources.String33});
            this.comboBoxChangeFrequency.Name = "comboBoxChangeFrequency";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbChangeFrequency);
            this.groupBox1.Controls.Add(this.comboBoxChangeFrequency);
            this.groupBox1.Controls.Add(this.comboBoxPriority);
            this.groupBox1.Controls.Add(this.cbLastModification);
            this.groupBox1.Controls.Add(this.dateTimePicker);
            this.groupBox1.Controls.Add(this.comboBoxLastModification);
            this.groupBox1.Controls.Add(this.cbPriority);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxPageTitle);
            this.groupBox2.Controls.Add(this.lbPageTitle);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // comboBoxPageTitle
            // 
            this.comboBoxPageTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPageTitle.FormattingEnabled = true;
            this.comboBoxPageTitle.Items.AddRange(new object[] {
            resources.GetString("comboBoxPageTitle.Items"),
            resources.GetString("comboBoxPageTitle.Items1"),
            resources.GetString("comboBoxPageTitle.Items2"),
            resources.GetString("comboBoxPageTitle.Items3")});
            resources.ApplyResources(this.comboBoxPageTitle, "comboBoxPageTitle");
            this.comboBoxPageTitle.Name = "comboBoxPageTitle";
            // 
            // lbPageTitle
            // 
            resources.ApplyResources(this.lbPageTitle, "lbPageTitle");
            this.lbPageTitle.Name = "lbPageTitle";
            // 
            // cbUseLocal
            // 
            resources.ApplyResources(this.cbUseLocal, "cbUseLocal");
            this.cbUseLocal.Name = "cbUseLocal";
            this.cbUseLocal.UseVisualStyleBackColor = true;
            this.cbUseLocal.CheckedChanged += new System.EventHandler(this.cbUseLocal_CheckedChanged);
            // 
            // lbLocalPath
            // 
            resources.ApplyResources(this.lbLocalPath, "lbLocalPath");
            this.lbLocalPath.Name = "lbLocalPath";
            // 
            // tbLocalPath
            // 
            resources.ApplyResources(this.tbLocalPath, "tbLocalPath");
            this.tbLocalPath.Name = "tbLocalPath";
            // 
            // btnBrowseLocalPath
            // 
            resources.ApplyResources(this.btnBrowseLocalPath, "btnBrowseLocalPath");
            this.btnBrowseLocalPath.Name = "btnBrowseLocalPath";
            this.btnBrowseLocalPath.UseVisualStyleBackColor = true;
            this.btnBrowseLocalPath.Click += new System.EventHandler(this.btnBrowseLocalPath_Click);
            // 
            // cbIncludeNotFound
            // 
            resources.ApplyResources(this.cbIncludeNotFound, "cbIncludeNotFound");
            this.cbIncludeNotFound.Name = "cbIncludeNotFound";
            this.cbIncludeNotFound.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbLocalPath);
            this.groupBox3.Controls.Add(this.cbIncludeNotFound);
            this.groupBox3.Controls.Add(this.cbUseLocal);
            this.groupBox3.Controls.Add(this.btnBrowseLocalPath);
            this.groupBox3.Controls.Add(this.lbLocalPath);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnRun;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbGenerateHtmlFile);
            this.Controls.Add(this.cbGenerateXmlFile);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBoxEncoding);
            this.Controls.Add(this.lbEncoding);
            this.Controls.Add(this.btnBrouseDirectory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.tbDestinationFolder);
            this.Controls.Add(this.tbFilter);
            this.Controls.Add(this.tbURL);
            this.Controls.Add(this.lbFilter);
            this.Controls.Add(this.lbFileLocation);
            this.Controls.Add(this.lbURL);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbURL;
        private System.Windows.Forms.TextBox tbURL;
        private System.Windows.Forms.TextBox tbDestinationFolder;
        private System.Windows.Forms.Label lbFileLocation;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label lbFilter;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.Button btnBrouseDirectory;
        private System.Windows.Forms.CheckBox cbGenerateHtmlFile;
        private System.Windows.Forms.Label lbEncoding;
        private System.Windows.Forms.ComboBox comboBoxEncoding;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox cbGenerateXmlFile;
        private System.Windows.Forms.ComboBox comboBoxPriority;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.ComboBox comboBoxLastModification;
        private System.Windows.Forms.CheckBox cbPriority;
        private System.Windows.Forms.CheckBox cbChangeFrequency;
        private System.Windows.Forms.CheckBox cbLastModification;
        private System.Windows.Forms.ComboBox comboBoxChangeFrequency;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxPageTitle;
        private System.Windows.Forms.Label lbPageTitle;
        private System.Windows.Forms.CheckBox cbUseLocal;
        private System.Windows.Forms.Label lbLocalPath;
        private System.Windows.Forms.TextBox tbLocalPath;
        private System.Windows.Forms.Button btnBrowseLocalPath;
        private System.Windows.Forms.CheckBox cbIncludeNotFound;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}