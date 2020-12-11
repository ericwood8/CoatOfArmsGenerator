using System.Windows.Forms;

namespace CoatOfArmsCore
{
    partial class FrmCoatOfArms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCoatOfArms));
            this.fileMenu = new System.Windows.Forms.MenuStrip();
            this.miFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.miFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.miWatermark = new System.Windows.Forms.ToolStripMenuItem();
            this.miOpenAndOverlay = new System.Windows.Forms.ToolStripMenuItem();
            this.miOpenAndUnderlay = new System.Windows.Forms.ToolStripMenuItem();
            this.miSwitchColor = new System.Windows.Forms.ToolStripMenuItem();
            this.miGenerateCoatOfArms = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.bitmapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exifToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gIFFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jPEGFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pNGFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tIFFFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsMetafileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbxWatermarkText = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCompany = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnFont = new System.Windows.Forms.Button();
            this.gbxPosition = new System.Windows.Forms.GroupBox();
            this.optBottom = new System.Windows.Forms.RadioButton();
            this.optTop = new System.Windows.Forms.RadioButton();
            this.cboOpacity = new System.Windows.Forms.ComboBox();
            this.lblOpacity = new System.Windows.Forms.Label();
            this.lblWmark = new System.Windows.Forms.Label();
            this.txtWaterMark = new System.Windows.Forms.TextBox();
            this.picContainer = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SaveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.fileMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbxWatermarkText.SuspendLayout();
            this.gbxPosition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picContainer)).BeginInit();
            this.SuspendLayout();
            // 
            // fileMenu
            // 
            this.fileMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile,
            this.miExit});
            this.fileMenu.Location = new System.Drawing.Point(0, 0);
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.fileMenu.Size = new System.Drawing.Size(888, 24);
            this.fileMenu.TabIndex = 1;
            this.fileMenu.Text = "menuStrip1";
            // 
            // miFile
            // 
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFileOpen,
            this.miFileSave,
            this.miWatermark,
            this.miOpenAndOverlay,
            this.miOpenAndUnderlay,
            this.miSwitchColor,
            this.miGenerateCoatOfArms,
            this.exitToolStripMenuItem});
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(37, 20);
            this.miFile.Text = "File";
            this.miFile.ToolTipText = "File";
            // 
            // miFileOpen
            // 
            this.miFileOpen.Image = ((System.Drawing.Image)(resources.GetObject("miFileOpen.Image")));
            this.miFileOpen.Name = "miFileOpen";
            this.miFileOpen.Size = new System.Drawing.Size(178, 22);
            this.miFileOpen.Text = "&Open...";
            this.miFileOpen.ToolTipText = "Open";
            this.miFileOpen.Click += new System.EventHandler(this.miFileOpen_Click);
            // 
            // miFileSave
            // 
            this.miFileSave.Name = "miFileSave";
            this.miFileSave.Size = new System.Drawing.Size(178, 22);
            this.miFileSave.Text = "&Save";
            this.miFileSave.ToolTipText = "Save";
            this.miFileSave.Click += new System.EventHandler(this.miFileSave_Click);
            // 
            // miWatermark
            // 
            this.miWatermark.Name = "miWatermark";
            this.miWatermark.Size = new System.Drawing.Size(178, 22);
            this.miWatermark.Text = "Apply Watermark";
            this.miWatermark.ToolTipText = "Watermark";
            this.miWatermark.Click += new System.EventHandler(this.miWatermark_Click);
            // 
            // miOpenAndOverlay
            // 
            this.miOpenAndOverlay.Name = "miOpenAndOverlay";
            this.miOpenAndOverlay.Size = new System.Drawing.Size(178, 22);
            this.miOpenAndOverlay.Text = "Open and Overlay...";
            this.miOpenAndOverlay.ToolTipText = "Open and Overlay...";
            this.miOpenAndOverlay.Click += new System.EventHandler(this.miOpenAndOverlay_Click);
            // 
            // miOpenAndUnderlay
            // 
            this.miOpenAndUnderlay.Name = "miOpenAndUnderlay";
            this.miOpenAndUnderlay.Size = new System.Drawing.Size(178, 22);
            this.miOpenAndUnderlay.Text = "Open and Underlay...";
            this.miOpenAndUnderlay.ToolTipText = "Open and Underlay...";
            this.miOpenAndUnderlay.Click += new System.EventHandler(this.miOpenAndUnderlay_Click);
            // 
            // miSwitchColor
            // 
            this.miSwitchColor.Name = "miSwitchColor";
            this.miSwitchColor.Size = new System.Drawing.Size(178, 22);
            this.miSwitchColor.Text = "Switch Color...";
            this.miSwitchColor.ToolTipText = "Switch Color...";
            this.miSwitchColor.Click += new System.EventHandler(this.miSwitchColor_Click);
            // 
            // miGenerateCoatOfArms
            // 
            this.miGenerateCoatOfArms.Name = "miGenerateCoatOfArms";
            this.miGenerateCoatOfArms.Size = new System.Drawing.Size(178, 22);
            this.miGenerateCoatOfArms.Text = "Generate Coat of Arms";
            this.miGenerateCoatOfArms.ToolTipText = "Generate Coat of Arms";
            this.miGenerateCoatOfArms.Click += new System.EventHandler(this.miGenerateCoatOfArms_Click);
            this.miGenerateCoatOfArms.ShortcutKeys = Keys.Control | Keys.G;
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.miExit_Click);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(12, 20);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(109, 6);
            // 
            // bitmapToolStripMenuItem
            // 
            this.bitmapToolStripMenuItem.Name = "bitmapToolStripMenuItem";
            this.bitmapToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // emfToolStripMenuItem
            // 
            this.emfToolStripMenuItem.Name = "emfToolStripMenuItem";
            this.emfToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // exifToolStripMenuItem
            // 
            this.exifToolStripMenuItem.Name = "exifToolStripMenuItem";
            this.exifToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // gIFFileToolStripMenuItem
            // 
            this.gIFFileToolStripMenuItem.Name = "gIFFileToolStripMenuItem";
            this.gIFFileToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // jPEGFileToolStripMenuItem
            // 
            this.jPEGFileToolStripMenuItem.Name = "jPEGFileToolStripMenuItem";
            this.jPEGFileToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // pNGFileToolStripMenuItem
            // 
            this.pNGFileToolStripMenuItem.Name = "pNGFileToolStripMenuItem";
            this.pNGFileToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // tIFFFileToolStripMenuItem
            // 
            this.tIFFFileToolStripMenuItem.Name = "tIFFFileToolStripMenuItem";
            this.tIFFFileToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // windowsMetafileToolStripMenuItem
            // 
            this.windowsMetafileToolStripMenuItem.Name = "windowsMetafileToolStripMenuItem";
            this.windowsMetafileToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbxWatermarkText);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Black;
            this.splitContainer1.Panel2.Controls.Add(this.picContainer);
            this.splitContainer1.Size = new System.Drawing.Size(888, 578);
            this.splitContainer1.SplitterDistance = 119;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 2;
            // 
            // gbxWatermarkText
            // 
            this.gbxWatermarkText.Controls.Add(this.label1);
            this.gbxWatermarkText.Controls.Add(this.tbCompany);
            this.gbxWatermarkText.Controls.Add(this.button1);
            this.gbxWatermarkText.Controls.Add(this.btnFont);
            this.gbxWatermarkText.Controls.Add(this.gbxPosition);
            this.gbxWatermarkText.Controls.Add(this.cboOpacity);
            this.gbxWatermarkText.Controls.Add(this.lblOpacity);
            this.gbxWatermarkText.Controls.Add(this.lblWmark);
            this.gbxWatermarkText.Controls.Add(this.txtWaterMark);
            this.gbxWatermarkText.Location = new System.Drawing.Point(6, 6);
            this.gbxWatermarkText.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gbxWatermarkText.Name = "gbxWatermarkText";
            this.gbxWatermarkText.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gbxWatermarkText.Size = new System.Drawing.Size(869, 97);
            this.gbxWatermarkText.TabIndex = 0;
            this.gbxWatermarkText.TabStop = false;
            this.gbxWatermarkText.Text = "Watermark Text";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Company Name";
            // 
            // tbCompany
            // 
            this.tbCompany.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbCompany.Location = new System.Drawing.Point(110, 23);
            this.tbCompany.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbCompany.Name = "tbCompany";
            this.tbCompany.Size = new System.Drawing.Size(139, 22);
            this.tbCompany.TabIndex = 0;
            this.tbCompany.TextChanged += new System.EventHandler(this.tbCompany_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(616, 56);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 27);
            this.button1.TabIndex = 0;
            this.button1.Text = "Preview";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnFont
            // 
            this.btnFont.Location = new System.Drawing.Point(615, 14);
            this.btnFont.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(135, 27);
            this.btnFont.TabIndex = 4;
            this.btnFont.Text = "Text Font...";
            this.btnFont.UseVisualStyleBackColor = true;
            this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
            // 
            // gbxPosition
            // 
            this.gbxPosition.Controls.Add(this.optBottom);
            this.gbxPosition.Controls.Add(this.optTop);
            this.gbxPosition.Location = new System.Drawing.Point(482, 14);
            this.gbxPosition.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gbxPosition.Name = "gbxPosition";
            this.gbxPosition.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gbxPosition.Size = new System.Drawing.Size(126, 77);
            this.gbxPosition.TabIndex = 1;
            this.gbxPosition.TabStop = false;
            this.gbxPosition.Text = "Watermark Position";
            // 
            // optBottom
            // 
            this.optBottom.AutoSize = true;
            this.optBottom.Location = new System.Drawing.Point(21, 50);
            this.optBottom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.optBottom.Name = "optBottom";
            this.optBottom.Size = new System.Drawing.Size(65, 19);
            this.optBottom.TabIndex = 1;
            this.optBottom.TabStop = true;
            this.optBottom.Text = "Bottom";
            this.optBottom.UseVisualStyleBackColor = true;
            // 
            // optTop
            // 
            this.optTop.AutoSize = true;
            this.optTop.Location = new System.Drawing.Point(21, 23);
            this.optTop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.optTop.Name = "optTop";
            this.optTop.Size = new System.Drawing.Size(44, 19);
            this.optTop.TabIndex = 0;
            this.optTop.TabStop = true;
            this.optTop.Text = "Top";
            this.optTop.UseVisualStyleBackColor = true;
            // 
            // cboOpacity
            // 
            this.cboOpacity.FormattingEnabled = true;
            this.cboOpacity.Items.AddRange(new object[] {
            "100%",
            "75%",
            "50%",
            "25%",
            "10%"});
            this.cboOpacity.Location = new System.Drawing.Point(309, 21);
            this.cboOpacity.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboOpacity.Name = "cboOpacity";
            this.cboOpacity.Size = new System.Drawing.Size(140, 23);
            this.cboOpacity.TabIndex = 3;
            // 
            // lblOpacity
            // 
            this.lblOpacity.AutoSize = true;
            this.lblOpacity.Location = new System.Drawing.Point(257, 29);
            this.lblOpacity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOpacity.Name = "lblOpacity";
            this.lblOpacity.Size = new System.Drawing.Size(48, 15);
            this.lblOpacity.TabIndex = 2;
            this.lblOpacity.Text = "Opacity";
            // 
            // lblWmark
            // 
            this.lblWmark.AutoSize = true;
            this.lblWmark.Location = new System.Drawing.Point(6, 65);
            this.lblWmark.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWmark.Name = "lblWmark";
            this.lblWmark.Size = new System.Drawing.Size(28, 15);
            this.lblWmark.TabIndex = 1;
            this.lblWmark.Text = "Text";
            // 
            // txtWaterMark
            // 
            this.txtWaterMark.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtWaterMark.Location = new System.Drawing.Point(44, 64);
            this.txtWaterMark.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtWaterMark.Name = "txtWaterMark";
            this.txtWaterMark.Size = new System.Drawing.Size(430, 22);
            this.txtWaterMark.TabIndex = 0;
            // 
            // picContainer
            // 
            this.picContainer.BackColor = System.Drawing.Color.LightGray;
            this.picContainer.Location = new System.Drawing.Point(5, 5);
            this.picContainer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.picContainer.Name = "picContainer";
            this.picContainer.Size = new System.Drawing.Size(117, 58);
            this.picContainer.TabIndex = 0;
            this.picContainer.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.InitialDirectory = "c:";
            // 
            // FrmCoatOfArms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 602);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.fileMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FrmCoatOfArms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Coat Of Arms Utility";
            this.fileMenu.ResumeLayout(false);
            this.fileMenu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbxWatermarkText.ResumeLayout(false);
            this.gbxWatermarkText.PerformLayout();
            this.gbxPosition.ResumeLayout(false);
            this.gbxPosition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picContainer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip fileMenu;
        private System.Windows.Forms.ToolStripMenuItem miFile;
        private System.Windows.Forms.ToolStripMenuItem miFileOpen;
        private System.Windows.Forms.ToolStripMenuItem miFileSave;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog1;
        private System.Windows.Forms.PictureBox picContainer;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.ToolStripMenuItem bitmapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emfToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exifToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gIFFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jPEGFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pNGFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tIFFFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsMetafileToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbxWatermarkText;
        private System.Windows.Forms.ComboBox cboOpacity;
        private System.Windows.Forms.Label lblOpacity;
        private System.Windows.Forms.Label lblWmark;
        private System.Windows.Forms.TextBox txtWaterMark;
        private System.Windows.Forms.GroupBox gbxPosition;
        private System.Windows.Forms.RadioButton optBottom;
        private System.Windows.Forms.RadioButton optTop;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ToolStripMenuItem miWatermark;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem miOpenAndOverlay;
        private System.Windows.Forms.ToolStripMenuItem miOpenAndUnderlay;
        private System.Windows.Forms.ToolStripMenuItem miSwitchColor;
        private System.Windows.Forms.ToolStripMenuItem miGenerateCoatOfArms;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCompany;
    }
}