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
            this.ColorGroup = new System.Windows.Forms.GroupBox();
            this.ColorDrawLbl = new System.Windows.Forms.Label();
            this.BlueLbl = new System.Windows.Forms.Label();
            this.GreenLbl = new System.Windows.Forms.Label();
            this.RedLbl = new System.Windows.Forms.Label();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.WinSizeUpDown = new System.Windows.Forms.NumericUpDown();
            this.WinSizeLbl = new System.Windows.Forms.Label();
            this.MainProgress = new System.Windows.Forms.ProgressBar();
            this.BtnPanel = new System.Windows.Forms.Panel();
            this.ExecuteBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.OperationWorker = new System.ComponentModel.BackgroundWorker();
            this.RedTrack = new System.Windows.Forms.TrackBar();
            this.RedValueLbl = new System.Windows.Forms.Label();
            this.GreenTrack = new System.Windows.Forms.TrackBar();
            this.GreenValueLbl = new System.Windows.Forms.Label();
            this.BlueTrack = new System.Windows.Forms.TrackBar();
            this.BlueValueLbl = new System.Windows.Forms.Label();
            this.MainTblLayout.SuspendLayout();
            this.ColorGroup.SuspendLayout();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WinSizeUpDown)).BeginInit();
            this.BtnPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RedTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueTrack)).BeginInit();
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
            this.MainTblLayout.Size = new System.Drawing.Size(284, 261);
            this.MainTblLayout.TabIndex = 0;
            // 
            // ColorGroup
            // 
            this.ColorGroup.Controls.Add(this.BlueValueLbl);
            this.ColorGroup.Controls.Add(this.GreenValueLbl);
            this.ColorGroup.Controls.Add(this.RedValueLbl);
            this.ColorGroup.Controls.Add(this.BlueTrack);
            this.ColorGroup.Controls.Add(this.GreenTrack);
            this.ColorGroup.Controls.Add(this.RedTrack);
            this.ColorGroup.Controls.Add(this.ColorDrawLbl);
            this.ColorGroup.Controls.Add(this.BlueLbl);
            this.ColorGroup.Controls.Add(this.GreenLbl);
            this.ColorGroup.Controls.Add(this.RedLbl);
            this.ColorGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ColorGroup.Location = new System.Drawing.Point(3, 43);
            this.ColorGroup.Name = "ColorGroup";
            this.ColorGroup.Size = new System.Drawing.Size(278, 145);
            this.ColorGroup.TabIndex = 11;
            this.ColorGroup.TabStop = false;
            this.ColorGroup.Text = "Optimal color";
            // 
            // ColorDrawLbl
            // 
            this.ColorDrawLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ColorDrawLbl.BackColor = System.Drawing.Color.Red;
            this.ColorDrawLbl.Location = new System.Drawing.Point(178, 23);
            this.ColorDrawLbl.Name = "ColorDrawLbl";
            this.ColorDrawLbl.Size = new System.Drawing.Size(85, 78);
            this.ColorDrawLbl.TabIndex = 10;
            // 
            // BlueLbl
            // 
            this.BlueLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BlueLbl.AutoSize = true;
            this.BlueLbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlueLbl.Location = new System.Drawing.Point(16, 83);
            this.BlueLbl.Name = "BlueLbl";
            this.BlueLbl.Size = new System.Drawing.Size(14, 13);
            this.BlueLbl.TabIndex = 9;
            this.BlueLbl.Text = "B";
            // 
            // GreenLbl
            // 
            this.GreenLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GreenLbl.AutoSize = true;
            this.GreenLbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GreenLbl.Location = new System.Drawing.Point(15, 55);
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
            this.RedLbl.Location = new System.Drawing.Point(16, 27);
            this.RedLbl.Name = "RedLbl";
            this.RedLbl.Size = new System.Drawing.Size(14, 13);
            this.RedLbl.TabIndex = 9;
            this.RedLbl.Text = "R";
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.WinSizeUpDown);
            this.MainPanel.Controls.Add(this.WinSizeLbl);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(3, 3);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(278, 34);
            this.MainPanel.TabIndex = 5;
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
            this.WinSizeUpDown.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
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
            // MainProgress
            // 
            this.MainProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainProgress.Location = new System.Drawing.Point(3, 234);
            this.MainProgress.Name = "MainProgress";
            this.MainProgress.Size = new System.Drawing.Size(278, 24);
            this.MainProgress.TabIndex = 3;
            // 
            // BtnPanel
            // 
            this.BtnPanel.Controls.Add(this.ExecuteBtn);
            this.BtnPanel.Controls.Add(this.CancelBtn);
            this.BtnPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnPanel.Location = new System.Drawing.Point(3, 194);
            this.BtnPanel.Name = "BtnPanel";
            this.BtnPanel.Size = new System.Drawing.Size(278, 34);
            this.BtnPanel.TabIndex = 1;
            // 
            // ExecuteBtn
            // 
            this.ExecuteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExecuteBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExecuteBtn.Location = new System.Drawing.Point(119, 4);
            this.ExecuteBtn.Name = "ExecuteBtn";
            this.ExecuteBtn.Size = new System.Drawing.Size(75, 23);
            this.ExecuteBtn.TabIndex = 4;
            this.ExecuteBtn.Text = "Execute";
            this.ExecuteBtn.UseVisualStyleBackColor = true;
            this.ExecuteBtn.Click += new System.EventHandler(this.ExecuteBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelBtn.Location = new System.Drawing.Point(200, 4);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 5;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // OperationWorker
            // 
            this.OperationWorker.WorkerReportsProgress = true;
            this.OperationWorker.WorkerSupportsCancellation = true;
            this.OperationWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.OperationWorker_DoWork);
            this.OperationWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.OperationWorker_ProgressChanged);
            this.OperationWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.OperationWorker_RunWorkerCompleted);
            // 
            // RedTrack
            // 
            this.RedTrack.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RedTrack.LargeChange = 25;
            this.RedTrack.Location = new System.Drawing.Point(36, 23);
            this.RedTrack.Maximum = 255;
            this.RedTrack.Name = "RedTrack";
            this.RedTrack.Size = new System.Drawing.Size(104, 45);
            this.RedTrack.TabIndex = 11;
            this.RedTrack.TickFrequency = 100;
            this.RedTrack.TickStyle = System.Windows.Forms.TickStyle.None;
            this.RedTrack.Value = 255;
            this.RedTrack.Scroll += new System.EventHandler(this.RedTrack_Scroll);
            // 
            // RedValueLbl
            // 
            this.RedValueLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RedValueLbl.AutoSize = true;
            this.RedValueLbl.Location = new System.Drawing.Point(146, 27);
            this.RedValueLbl.Name = "RedValueLbl";
            this.RedValueLbl.Size = new System.Drawing.Size(25, 13);
            this.RedValueLbl.TabIndex = 12;
            this.RedValueLbl.Text = "255";
            // 
            // GreenTrack
            // 
            this.GreenTrack.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GreenTrack.LargeChange = 25;
            this.GreenTrack.Location = new System.Drawing.Point(36, 51);
            this.GreenTrack.Maximum = 255;
            this.GreenTrack.Name = "GreenTrack";
            this.GreenTrack.Size = new System.Drawing.Size(104, 45);
            this.GreenTrack.TabIndex = 11;
            this.GreenTrack.TickFrequency = 100;
            this.GreenTrack.TickStyle = System.Windows.Forms.TickStyle.None;
            this.GreenTrack.Scroll += new System.EventHandler(this.GreenTrack_Scroll);
            // 
            // GreenValueLbl
            // 
            this.GreenValueLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GreenValueLbl.AutoSize = true;
            this.GreenValueLbl.Location = new System.Drawing.Point(146, 55);
            this.GreenValueLbl.Name = "GreenValueLbl";
            this.GreenValueLbl.Size = new System.Drawing.Size(25, 13);
            this.GreenValueLbl.TabIndex = 12;
            this.GreenValueLbl.Text = "255";
            // 
            // BlueTrack
            // 
            this.BlueTrack.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BlueTrack.LargeChange = 25;
            this.BlueTrack.Location = new System.Drawing.Point(36, 79);
            this.BlueTrack.Maximum = 255;
            this.BlueTrack.Name = "BlueTrack";
            this.BlueTrack.Size = new System.Drawing.Size(104, 45);
            this.BlueTrack.TabIndex = 11;
            this.BlueTrack.TickFrequency = 100;
            this.BlueTrack.TickStyle = System.Windows.Forms.TickStyle.None;
            this.BlueTrack.Scroll += new System.EventHandler(this.BlueTrack_Scroll);
            // 
            // BlueValueLbl
            // 
            this.BlueValueLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BlueValueLbl.AutoSize = true;
            this.BlueValueLbl.Location = new System.Drawing.Point(146, 83);
            this.BlueValueLbl.Name = "BlueValueLbl";
            this.BlueValueLbl.Size = new System.Drawing.Size(25, 13);
            this.BlueValueLbl.TabIndex = 12;
            this.BlueValueLbl.Text = "255";
            // 
            // RollingBallForm
            // 
            this.AcceptButton = this.ExecuteBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.MainTblLayout);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "RollingBallForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Rolling Ball Algorithm";
            this.MainTblLayout.ResumeLayout(false);
            this.ColorGroup.ResumeLayout(false);
            this.ColorGroup.PerformLayout();
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WinSizeUpDown)).EndInit();
            this.BtnPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RedTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueTrack)).EndInit();
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
        private System.Windows.Forms.Label BlueLbl;
        private System.Windows.Forms.Label GreenLbl;
        private System.Windows.Forms.Label RedLbl;
        private System.Windows.Forms.Label ColorDrawLbl;
        private System.Windows.Forms.GroupBox ColorGroup;
        private System.Windows.Forms.Label BlueValueLbl;
        private System.Windows.Forms.Label GreenValueLbl;
        private System.Windows.Forms.Label RedValueLbl;
        private System.Windows.Forms.TrackBar BlueTrack;
        private System.Windows.Forms.TrackBar GreenTrack;
        private System.Windows.Forms.TrackBar RedTrack;
    }
}