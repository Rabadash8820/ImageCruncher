namespace GuiShell {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ImgFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ImgBrowseBtn = new System.Windows.Forms.Button();
            this.ImgLabel = new System.Windows.Forms.Label();
            this.ImgTxt = new System.Windows.Forms.TextBox();
            this.MainToolStrip = new System.Windows.Forms.ToolStrip();
            this.WatercolorBtn = new System.Windows.Forms.ToolStripButton();
            this.RollingBallBtn = new System.Windows.Forms.ToolStripButton();
            this.ImgPicBox = new System.Windows.Forms.PictureBox();
            this.MainTblLayout = new System.Windows.Forms.TableLayoutPanel();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.MainToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgPicBox)).BeginInit();
            this.MainTblLayout.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImgFileDialog
            // 
            this.ImgFileDialog.FileName = "openFileDialog1";
            this.ImgFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.ImgFileDialog1_FileOk);
            // 
            // ImgBrowseBtn
            // 
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
            this.ImgLabel.Location = new System.Drawing.Point(3, 10);
            this.ImgLabel.Name = "ImgLabel";
            this.ImgLabel.Size = new System.Drawing.Size(55, 13);
            this.ImgLabel.TabIndex = 1;
            this.ImgLabel.Text = "Image File";
            // 
            // ImgTxt
            // 
            this.ImgTxt.Location = new System.Drawing.Point(64, 7);
            this.ImgTxt.Name = "ImgTxt";
            this.ImgTxt.Size = new System.Drawing.Size(222, 20);
            this.ImgTxt.TabIndex = 2;
            // 
            // MainToolStrip
            // 
            this.MainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WatercolorBtn,
            this.RollingBallBtn});
            this.MainToolStrip.Location = new System.Drawing.Point(0, 0);
            this.MainToolStrip.Name = "MainToolStrip";
            this.MainToolStrip.Size = new System.Drawing.Size(673, 25);
            this.MainToolStrip.TabIndex = 4;
            this.MainToolStrip.Text = "toolStrip1";
            // 
            // WatercolorBtn
            // 
            this.WatercolorBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.WatercolorBtn.Image = ((System.Drawing.Image)(resources.GetObject("WatercolorBtn.Image")));
            this.WatercolorBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.WatercolorBtn.Name = "WatercolorBtn";
            this.WatercolorBtn.Size = new System.Drawing.Size(23, 22);
            this.WatercolorBtn.Text = "Watercolor Filter";
            this.WatercolorBtn.Click += new System.EventHandler(this.WatercolorBtn_Click);
            // 
            // RollingBallBtn
            // 
            this.RollingBallBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RollingBallBtn.Image = ((System.Drawing.Image)(resources.GetObject("RollingBallBtn.Image")));
            this.RollingBallBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RollingBallBtn.Name = "RollingBallBtn";
            this.RollingBallBtn.Size = new System.Drawing.Size(23, 22);
            this.RollingBallBtn.Text = "Rolling Ball";
            this.RollingBallBtn.Click += new System.EventHandler(this.RollingBallBtn_Click);
            // 
            // ImgPicBox
            // 
            this.ImgPicBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImgPicBox.Location = new System.Drawing.Point(3, 43);
            this.ImgPicBox.Name = "ImgPicBox";
            this.ImgPicBox.Size = new System.Drawing.Size(667, 190);
            this.ImgPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImgPicBox.TabIndex = 5;
            this.ImgPicBox.TabStop = false;
            // 
            // MainTblLayout
            // 
            this.MainTblLayout.ColumnCount = 1;
            this.MainTblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTblLayout.Controls.Add(this.ImgPicBox, 0, 1);
            this.MainTblLayout.Controls.Add(this.MainPanel, 0, 0);
            this.MainTblLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTblLayout.Location = new System.Drawing.Point(0, 25);
            this.MainTblLayout.Name = "MainTblLayout";
            this.MainTblLayout.RowCount = 2;
            this.MainTblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.MainTblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTblLayout.Size = new System.Drawing.Size(673, 236);
            this.MainTblLayout.TabIndex = 6;
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.ImgLabel);
            this.MainPanel.Controls.Add(this.ImgBrowseBtn);
            this.MainPanel.Controls.Add(this.ImgTxt);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(3, 3);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(667, 34);
            this.MainPanel.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 261);
            this.Controls.Add(this.MainTblLayout);
            this.Controls.Add(this.MainToolStrip);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Image Cruncher";
            this.MainToolStrip.ResumeLayout(false);
            this.MainToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgPicBox)).EndInit();
            this.MainTblLayout.ResumeLayout(false);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
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
    }
}

