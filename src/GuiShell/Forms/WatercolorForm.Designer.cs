namespace GuiShell.Forms {
    partial class WatercolorForm {
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.WinSizeLbl = new System.Windows.Forms.Label();
            this.CopyLbl = new System.Windows.Forms.Label();
            this.WinSizeUpDown = new System.Windows.Forms.NumericUpDown();
            this.CopyChk = new System.Windows.Forms.CheckBox();
            this.MainProgress = new System.Windows.Forms.ProgressBar();
            this.BtnPanel = new System.Windows.Forms.Panel();
            this.ApplyBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.WatercolorBgw = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WinSizeUpDown)).BeginInit();
            this.BtnPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 206F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.WinSizeLbl, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.CopyLbl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.WinSizeUpDown, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.CopyChk, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.MainProgress, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.BtnPanel, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(290, 126);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // WinSizeLbl
            // 
            this.WinSizeLbl.AutoSize = true;
            this.WinSizeLbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WinSizeLbl.Location = new System.Drawing.Point(3, 0);
            this.WinSizeLbl.Name = "WinSizeLbl";
            this.WinSizeLbl.Size = new System.Drawing.Size(73, 13);
            this.WinSizeLbl.TabIndex = 0;
            this.WinSizeLbl.Text = "Window size";
            // 
            // CopyLbl
            // 
            this.CopyLbl.AutoSize = true;
            this.CopyLbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CopyLbl.Location = new System.Drawing.Point(3, 30);
            this.CopyLbl.Name = "CopyLbl";
            this.CopyLbl.Size = new System.Drawing.Size(199, 13);
            this.CopyLbl.TabIndex = 1;
            this.CopyLbl.Text = "Keep a copy of the unmodified image";
            // 
            // WinSizeUpDown
            // 
            this.WinSizeUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WinSizeUpDown.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WinSizeUpDown.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.WinSizeUpDown.Location = new System.Drawing.Point(209, 3);
            this.WinSizeUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WinSizeUpDown.Name = "WinSizeUpDown";
            this.WinSizeUpDown.Size = new System.Drawing.Size(78, 22);
            this.WinSizeUpDown.TabIndex = 2;
            this.WinSizeUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // CopyChk
            // 
            this.CopyChk.AutoSize = true;
            this.CopyChk.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CopyChk.Checked = true;
            this.CopyChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CopyChk.Location = new System.Drawing.Point(209, 33);
            this.CopyChk.Name = "CopyChk";
            this.CopyChk.Size = new System.Drawing.Size(15, 14);
            this.CopyChk.TabIndex = 3;
            this.CopyChk.UseVisualStyleBackColor = true;
            // 
            // MainProgress
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.MainProgress, 2);
            this.MainProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainProgress.Location = new System.Drawing.Point(3, 99);
            this.MainProgress.Name = "MainProgress";
            this.MainProgress.Size = new System.Drawing.Size(284, 24);
            this.MainProgress.TabIndex = 6;
            // 
            // BtnPanel
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.BtnPanel, 2);
            this.BtnPanel.Controls.Add(this.ApplyBtn);
            this.BtnPanel.Controls.Add(this.CancelBtn);
            this.BtnPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnPanel.Location = new System.Drawing.Point(3, 63);
            this.BtnPanel.Name = "BtnPanel";
            this.BtnPanel.Size = new System.Drawing.Size(284, 30);
            this.BtnPanel.TabIndex = 7;
            // 
            // ApplyBtn
            // 
            this.ApplyBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ApplyBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplyBtn.Location = new System.Drawing.Point(125, 4);
            this.ApplyBtn.Name = "ApplyBtn";
            this.ApplyBtn.Size = new System.Drawing.Size(75, 23);
            this.ApplyBtn.TabIndex = 6;
            this.ApplyBtn.Text = "Apply";
            this.ApplyBtn.UseVisualStyleBackColor = true;
            this.ApplyBtn.Click += new System.EventHandler(this.ApplyBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelBtn.Location = new System.Drawing.Point(206, 4);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 7;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // WatercolorBgw
            // 
            this.WatercolorBgw.WorkerReportsProgress = true;
            this.WatercolorBgw.WorkerSupportsCancellation = true;
            this.WatercolorBgw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.WatercolorBgw_DoWork);
            this.WatercolorBgw.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.WatercolorBgw_ProgressChanged);
            this.WatercolorBgw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.WatercolorBgw_RunWorkerCompleted);
            // 
            // WatercolorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 126);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WatercolorForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Watercolor Filter";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WinSizeUpDown)).EndInit();
            this.BtnPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label WinSizeLbl;
        private System.Windows.Forms.Label CopyLbl;
        private System.Windows.Forms.NumericUpDown WinSizeUpDown;
        private System.Windows.Forms.CheckBox CopyChk;
        private System.Windows.Forms.ProgressBar MainProgress;
        private System.Windows.Forms.Panel BtnPanel;
        private System.Windows.Forms.Button ApplyBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.ComponentModel.BackgroundWorker WatercolorBgw;
    }
}