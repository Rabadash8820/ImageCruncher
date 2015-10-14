namespace GuiShell.Forms {
    partial class RollingBallForm {
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
            this.MainTblLayout = new System.Windows.Forms.TableLayoutPanel();
            this.MainProgress = new System.Windows.Forms.ProgressBar();
            this.BtnPanel = new System.Windows.Forms.Panel();
            this.ExecuteBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.ColorGroup = new System.Windows.Forms.GroupBox();
            this.RedUpDown = new System.Windows.Forms.NumericUpDown();
            this.ColorDrawLbl = new System.Windows.Forms.Label();
            this.GreenUpDown = new System.Windows.Forms.NumericUpDown();
            this.BlueLbl = new System.Windows.Forms.Label();
            this.BlueUpDown = new System.Windows.Forms.NumericUpDown();
            this.GreenLbl = new System.Windows.Forms.Label();
            this.RedLbl = new System.Windows.Forms.Label();
            this.WinSizeUpDown = new System.Windows.Forms.NumericUpDown();
            this.WinSizeLbl = new System.Windows.Forms.Label();
            this.OperationWorker = new System.ComponentModel.BackgroundWorker();
            this.MainTblLayout.SuspendLayout();
            this.BtnPanel.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.ColorGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RedUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WinSizeUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTblLayout
            // 
            this.MainTblLayout.ColumnCount = 1;
            this.MainTblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTblLayout.Controls.Add(this.ColorGroup, 0, 1);
            this.MainTblLayout.Controls.Add(this.MainPanel, 0, 0);
            this.MainTblLayout.Controls.Add(this.MainProgress, 0, 3);
            this.MainTblLayout.Controls.Add(this.BtnPanel, 0, 2);
            this.MainTblLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTblLayout.Location = new System.Drawing.Point(0, 0);
            this.MainTblLayout.Name = "MainTblLayout";
            this.MainTblLayout.RowCount = 4;
            this.MainTblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.MainTblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.MainTblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.MainTblLayout.Size = new System.Drawing.Size(264, 221);
            this.MainTblLayout.TabIndex = 0;
            // 
            // MainProgress
            // 
            this.MainProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainProgress.Location = new System.Drawing.Point(3, 194);
            this.MainProgress.Name = "MainProgress";
            this.MainProgress.Size = new System.Drawing.Size(258, 24);
            this.MainProgress.TabIndex = 3;
            // 
            // BtnPanel
            // 
            this.BtnPanel.Controls.Add(this.ExecuteBtn);
            this.BtnPanel.Controls.Add(this.CancelBtn);
            this.BtnPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnPanel.Location = new System.Drawing.Point(3, 154);
            this.BtnPanel.Name = "BtnPanel";
            this.BtnPanel.Size = new System.Drawing.Size(258, 34);
            this.BtnPanel.TabIndex = 1;
            // 
            // ExecuteBtn
            // 
            this.ExecuteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExecuteBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExecuteBtn.Location = new System.Drawing.Point(99, 4);
            this.ExecuteBtn.Name = "ExecuteBtn";
            this.ExecuteBtn.Size = new System.Drawing.Size(75, 23);
            this.ExecuteBtn.TabIndex = 4;
            this.ExecuteBtn.Text = "Execute";
            this.ExecuteBtn.UseVisualStyleBackColor = true;
            this.ExecuteBtn.Click += new System.EventHandler(this.ApplyBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelBtn.Location = new System.Drawing.Point(180, 4);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 5;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.WinSizeUpDown);
            this.MainPanel.Controls.Add(this.WinSizeLbl);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(3, 3);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(258, 34);
            this.MainPanel.TabIndex = 5;
            // 
            // ColorGroup
            // 
            this.ColorGroup.Controls.Add(this.RedUpDown);
            this.ColorGroup.Controls.Add(this.ColorDrawLbl);
            this.ColorGroup.Controls.Add(this.GreenUpDown);
            this.ColorGroup.Controls.Add(this.BlueLbl);
            this.ColorGroup.Controls.Add(this.BlueUpDown);
            this.ColorGroup.Controls.Add(this.GreenLbl);
            this.ColorGroup.Controls.Add(this.RedLbl);
            this.ColorGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ColorGroup.Location = new System.Drawing.Point(3, 43);
            this.ColorGroup.Name = "ColorGroup";
            this.ColorGroup.Size = new System.Drawing.Size(258, 105);
            this.ColorGroup.TabIndex = 11;
            this.ColorGroup.TabStop = false;
            this.ColorGroup.Text = "Optimal color";
            // 
            // RedUpDown
            // 
            this.RedUpDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RedUpDown.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RedUpDown.Location = new System.Drawing.Point(58, 21);
            this.RedUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.RedUpDown.Name = "RedUpDown";
            this.RedUpDown.Size = new System.Drawing.Size(72, 22);
            this.RedUpDown.TabIndex = 6;
            this.RedUpDown.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.RedUpDown.ValueChanged += new System.EventHandler(this.RedUpDown_ValueChanged);
            // 
            // ColorDrawLbl
            // 
            this.ColorDrawLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ColorDrawLbl.BackColor = System.Drawing.Color.Red;
            this.ColorDrawLbl.Location = new System.Drawing.Point(136, 21);
            this.ColorDrawLbl.Name = "ColorDrawLbl";
            this.ColorDrawLbl.Size = new System.Drawing.Size(85, 78);
            this.ColorDrawLbl.TabIndex = 10;
            // 
            // GreenUpDown
            // 
            this.GreenUpDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GreenUpDown.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GreenUpDown.Location = new System.Drawing.Point(58, 49);
            this.GreenUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.GreenUpDown.Name = "GreenUpDown";
            this.GreenUpDown.Size = new System.Drawing.Size(72, 22);
            this.GreenUpDown.TabIndex = 7;
            this.GreenUpDown.ValueChanged += new System.EventHandler(this.GreenUpDown_ValueChanged);
            // 
            // BlueLbl
            // 
            this.BlueLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BlueLbl.AutoSize = true;
            this.BlueLbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlueLbl.Location = new System.Drawing.Point(38, 79);
            this.BlueLbl.Name = "BlueLbl";
            this.BlueLbl.Size = new System.Drawing.Size(14, 13);
            this.BlueLbl.TabIndex = 9;
            this.BlueLbl.Text = "B";
            // 
            // BlueUpDown
            // 
            this.BlueUpDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BlueUpDown.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlueUpDown.Location = new System.Drawing.Point(58, 77);
            this.BlueUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.BlueUpDown.Name = "BlueUpDown";
            this.BlueUpDown.Size = new System.Drawing.Size(72, 22);
            this.BlueUpDown.TabIndex = 8;
            this.BlueUpDown.ValueChanged += new System.EventHandler(this.BlueUpDown_ValueChanged);
            // 
            // GreenLbl
            // 
            this.GreenLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GreenLbl.AutoSize = true;
            this.GreenLbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GreenLbl.Location = new System.Drawing.Point(37, 51);
            this.GreenLbl.Name = "GreenLbl";
            this.GreenLbl.Size = new System.Drawing.Size(15, 13);
            this.GreenLbl.TabIndex = 9;
            this.GreenLbl.Text = "G";
            // 
            // RedLbl
            // 
            this.RedLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RedLbl.AutoSize = true;
            this.RedLbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RedLbl.Location = new System.Drawing.Point(38, 23);
            this.RedLbl.Name = "RedLbl";
            this.RedLbl.Size = new System.Drawing.Size(14, 13);
            this.RedLbl.TabIndex = 9;
            this.RedLbl.Text = "R";
            // 
            // WinSizeUpDown
            // 
            this.WinSizeUpDown.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WinSizeUpDown.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.WinSizeUpDown.Location = new System.Drawing.Point(86, 5);
            this.WinSizeUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WinSizeUpDown.Name = "WinSizeUpDown";
            this.WinSizeUpDown.Size = new System.Drawing.Size(72, 22);
            this.WinSizeUpDown.TabIndex = 2;
            this.WinSizeUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // WinSizeLbl
            // 
            this.WinSizeLbl.AutoSize = true;
            this.WinSizeLbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WinSizeLbl.Location = new System.Drawing.Point(3, 6);
            this.WinSizeLbl.Name = "WinSizeLbl";
            this.WinSizeLbl.Size = new System.Drawing.Size(73, 13);
            this.WinSizeLbl.TabIndex = 0;
            this.WinSizeLbl.Text = "Window size";
            // 
            // OperationWorker
            // 
            this.OperationWorker.WorkerReportsProgress = true;
            this.OperationWorker.WorkerSupportsCancellation = true;
            this.OperationWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.OperationWorker_DoWork);
            this.OperationWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.OperationWorker_ProgressChanged);
            this.OperationWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.OperationWorker_RunWorkerCompleted);
            // 
            // RollingBallForm
            // 
            this.AcceptButton = this.ExecuteBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(264, 221);
            this.Controls.Add(this.MainTblLayout);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(280, 260);
            this.Name = "RollingBallForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Rolling Ball Algorithm";
            this.MainTblLayout.ResumeLayout(false);
            this.BtnPanel.ResumeLayout(false);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.ColorGroup.ResumeLayout(false);
            this.ColorGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RedUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WinSizeUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTblLayout;
        private System.Windows.Forms.Label WinSizeLbl;
        private System.Windows.Forms.NumericUpDown WinSizeUpDown;
        private System.Windows.Forms.Button ExecuteBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Panel BtnPanel;
        private System.Windows.Forms.ProgressBar MainProgress;
        private System.ComponentModel.BackgroundWorker OperationWorker;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.NumericUpDown BlueUpDown;
        private System.Windows.Forms.NumericUpDown GreenUpDown;
        private System.Windows.Forms.NumericUpDown RedUpDown;
        private System.Windows.Forms.Label BlueLbl;
        private System.Windows.Forms.Label GreenLbl;
        private System.Windows.Forms.Label RedLbl;
        private System.Windows.Forms.Label ColorDrawLbl;
        private System.Windows.Forms.GroupBox ColorGroup;
    }
}