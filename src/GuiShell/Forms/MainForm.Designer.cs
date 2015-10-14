namespace GuiShell.Forms {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.ImgFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ImgBrowseBtn = new System.Windows.Forms.Button();
            this.ImgLabel = new System.Windows.Forms.Label();
            this.ImgTxt = new System.Windows.Forms.TextBox();
            this.MainToolStrip = new System.Windows.Forms.ToolStrip();
            this.FiltersLbl = new System.Windows.Forms.ToolStripLabel();
            this.WatercolorBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.OperationsLbl = new System.Windows.Forms.ToolStripLabel();
            this.RollingBallBtn = new System.Windows.Forms.ToolStripButton();
            this.ImgPicBox = new System.Windows.Forms.PictureBox();
            this.MainTblLayout = new System.Windows.Forms.TableLayoutPanel();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.ClearImgBtn = new System.Windows.Forms.Button();
            this.CloseFileBtn = new System.Windows.Forms.Button();
            this.MainSplit = new System.Windows.Forms.SplitContainer();
            this.LogListbox = new System.Windows.Forms.ListBox();
            this.MainToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgPicBox)).BeginInit();
            this.MainTblLayout.SuspendLayout();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplit)).BeginInit();
            this.MainSplit.Panel1.SuspendLayout();
            this.MainSplit.Panel2.SuspendLayout();
            this.MainSplit.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImgFileDialog
            // 
            this.ImgFileDialog.Filter = "GIF images|*.gif|JPEG images|*.jpg; *.jpeg; *.jpe; *.jif; *.jfif; *.jfi|PNG image" +
    "s|*.png|TIFF images|*.tiff; *.tif|All files|*.*";
            this.ImgFileDialog.FilterIndex = 3;
            this.ImgFileDialog.InitialDirectory = "C:\\";
            this.ImgFileDialog.Title = "Select an Image File";
            this.ImgFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.ImgFileDialog_FileOk);
            // 
            // ImgBrowseBtn
            // 
            this.ImgBrowseBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImgBrowseBtn.Location = new System.Drawing.Point(292, 5);
            this.ImgBrowseBtn.Name = "ImgBrowseBtn";
            this.ImgBrowseBtn.Size = new System.Drawing.Size(75, 23);
            this.ImgBrowseBtn.TabIndex = 0;
            this.ImgBrowseBtn.Text = "Browse";
            this.ImgBrowseBtn.UseVisualStyleBackColor = true;
            this.ImgBrowseBtn.Click += new System.EventHandler(this.ImgBrowseBtn_Click);
            // 
            // ImgLabel
            // 
            this.ImgLabel.AutoSize = true;
            this.ImgLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImgLabel.Location = new System.Drawing.Point(3, 10);
            this.ImgLabel.Name = "ImgLabel";
            this.ImgLabel.Size = new System.Drawing.Size(59, 13);
            this.ImgLabel.TabIndex = 1;
            this.ImgLabel.Text = "Image File";
            // 
            // ImgTxt
            // 
            this.ImgTxt.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImgTxt.Location = new System.Drawing.Point(64, 7);
            this.ImgTxt.Name = "ImgTxt";
            this.ImgTxt.ReadOnly = true;
            this.ImgTxt.Size = new System.Drawing.Size(222, 22);
            this.ImgTxt.TabIndex = 2;
            // 
            // MainToolStrip
            // 
            this.MainToolStrip.Enabled = false;
            this.MainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FiltersLbl,
            this.WatercolorBtn,
            this.toolStripSeparator1,
            this.OperationsLbl,
            this.RollingBallBtn});
            this.MainToolStrip.Location = new System.Drawing.Point(0, 0);
            this.MainToolStrip.Name = "MainToolStrip";
            this.MainToolStrip.Size = new System.Drawing.Size(861, 25);
            this.MainToolStrip.TabIndex = 4;
            this.MainToolStrip.Text = "toolStrip1";
            // 
            // FiltersLbl
            // 
            this.FiltersLbl.Name = "FiltersLbl";
            this.FiltersLbl.Size = new System.Drawing.Size(38, 22);
            this.FiltersLbl.Text = "Filters";
            // 
            // WatercolorBtn
            // 
            this.WatercolorBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.WatercolorBtn.Image = global::GuiShell.Properties.Resources.watercolor;
            this.WatercolorBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.WatercolorBtn.Name = "WatercolorBtn";
            this.WatercolorBtn.Size = new System.Drawing.Size(23, 22);
            this.WatercolorBtn.Text = "Watercolor Filter";
            this.WatercolorBtn.Click += new System.EventHandler(this.WatercolorBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // OperationsLbl
            // 
            this.OperationsLbl.Name = "OperationsLbl";
            this.OperationsLbl.Size = new System.Drawing.Size(65, 22);
            this.OperationsLbl.Text = "Operations";
            // 
            // RollingBallBtn
            // 
            this.RollingBallBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RollingBallBtn.Image = global::GuiShell.Properties.Resources.rolling_ball;
            this.RollingBallBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RollingBallBtn.Name = "RollingBallBtn";
            this.RollingBallBtn.Size = new System.Drawing.Size(23, 22);
            this.RollingBallBtn.Text = "Rolling Ball";
            this.RollingBallBtn.Click += new System.EventHandler(this.RollingBallBtn_Click);
            // 
            // ImgPicBox
            // 
            this.ImgPicBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImgPicBox.Location = new System.Drawing.Point(0, 0);
            this.ImgPicBox.Name = "ImgPicBox";
            this.ImgPicBox.Padding = new System.Windows.Forms.Padding(75, 50, 20, 33);
            this.ImgPicBox.Size = new System.Drawing.Size(851, 239);
            this.ImgPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImgPicBox.TabIndex = 5;
            this.ImgPicBox.TabStop = false;
            this.ImgPicBox.Paint += new System.Windows.Forms.PaintEventHandler(this.ImgPicBox_Paint);
            // 
            // MainTblLayout
            // 
            this.MainTblLayout.ColumnCount = 1;
            this.MainTblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTblLayout.Controls.Add(this.MainPanel, 0, 0);
            this.MainTblLayout.Controls.Add(this.MainSplit, 0, 1);
            this.MainTblLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTblLayout.Location = new System.Drawing.Point(0, 25);
            this.MainTblLayout.Name = "MainTblLayout";
            this.MainTblLayout.RowCount = 2;
            this.MainTblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.MainTblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTblLayout.Size = new System.Drawing.Size(861, 382);
            this.MainTblLayout.TabIndex = 6;
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.ClearImgBtn);
            this.MainPanel.Controls.Add(this.CloseFileBtn);
            this.MainPanel.Controls.Add(this.ImgLabel);
            this.MainPanel.Controls.Add(this.ImgBrowseBtn);
            this.MainPanel.Controls.Add(this.ImgTxt);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(3, 3);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(855, 34);
            this.MainPanel.TabIndex = 6;
            // 
            // ClearImgBtn
            // 
            this.ClearImgBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearImgBtn.AutoSize = true;
            this.ClearImgBtn.Enabled = false;
            this.ClearImgBtn.Location = new System.Drawing.Point(684, 5);
            this.ClearImgBtn.Name = "ClearImgBtn";
            this.ClearImgBtn.Size = new System.Drawing.Size(77, 23);
            this.ClearImgBtn.TabIndex = 5;
            this.ClearImgBtn.Text = "Clear Image";
            this.ClearImgBtn.UseVisualStyleBackColor = true;
            this.ClearImgBtn.Click += new System.EventHandler(this.ClearImgBtn_Click);
            // 
            // CloseFileBtn
            // 
            this.CloseFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseFileBtn.AutoSize = true;
            this.CloseFileBtn.Enabled = false;
            this.CloseFileBtn.Location = new System.Drawing.Point(767, 5);
            this.CloseFileBtn.Name = "CloseFileBtn";
            this.CloseFileBtn.Size = new System.Drawing.Size(79, 23);
            this.CloseFileBtn.TabIndex = 4;
            this.CloseFileBtn.Text = "Close Image";
            this.CloseFileBtn.UseVisualStyleBackColor = true;
            this.CloseFileBtn.Click += new System.EventHandler(this.CloseFileBtn_Click);
            // 
            // MainSplit
            // 
            this.MainSplit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MainSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.MainSplit.Location = new System.Drawing.Point(3, 43);
            this.MainSplit.Name = "MainSplit";
            this.MainSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainSplit.Panel1
            // 
            this.MainSplit.Panel1.Controls.Add(this.ImgPicBox);
            // 
            // MainSplit.Panel2
            // 
            this.MainSplit.Panel2.Controls.Add(this.LogListbox);
            this.MainSplit.Panel2MinSize = 30;
            this.MainSplit.Size = new System.Drawing.Size(855, 336);
            this.MainSplit.SplitterDistance = 243;
            this.MainSplit.TabIndex = 7;
            // 
            // LogListbox
            // 
            this.LogListbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogListbox.FormattingEnabled = true;
            this.LogListbox.Location = new System.Drawing.Point(0, 0);
            this.LogListbox.Name = "LogListbox";
            this.LogListbox.ScrollAlwaysVisible = true;
            this.LogListbox.Size = new System.Drawing.Size(851, 85);
            this.LogListbox.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 407);
            this.Controls.Add(this.MainTblLayout);
            this.Controls.Add(this.MainToolStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(570, 180);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Image Cruncher";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MainToolStrip.ResumeLayout(false);
            this.MainToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgPicBox)).EndInit();
            this.MainTblLayout.ResumeLayout(false);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.MainSplit.Panel1.ResumeLayout(false);
            this.MainSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplit)).EndInit();
            this.MainSplit.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ImgFileDialog;
        private System.Windows.Forms.Button ImgBrowseBtn;
        private System.Windows.Forms.Label ImgLabel;
        private System.Windows.Forms.TextBox ImgTxt;
        private System.Windows.Forms.ToolStrip MainToolStrip;
        private System.Windows.Forms.ToolStripButton WatercolorBtn;
        private System.Windows.Forms.ToolStripButton RollingBallBtn;
        private System.Windows.Forms.PictureBox ImgPicBox;
        private System.Windows.Forms.TableLayoutPanel MainTblLayout;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Button CloseFileBtn;
        private System.Windows.Forms.Button ClearImgBtn;
        private System.Windows.Forms.SplitContainer MainSplit;
        private System.Windows.Forms.ListBox LogListbox;
        private System.Windows.Forms.ToolStripLabel FiltersLbl;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel OperationsLbl;
    }
}

