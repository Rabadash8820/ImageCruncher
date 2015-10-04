namespace GuiShell {
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.WinSizeLbl = new System.Windows.Forms.Label();
            this.WinSizeUpDown = new System.Windows.Forms.NumericUpDown();
            this.ExecuteBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WinSizeUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 206F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.WinSizeLbl, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.WinSizeUpDown, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ExecuteBtn, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.CancelBtn, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(290, 62);
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
            // ExecuteBtn
            // 
            this.ExecuteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExecuteBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExecuteBtn.Location = new System.Drawing.Point(128, 33);
            this.ExecuteBtn.Name = "ExecuteBtn";
            this.ExecuteBtn.Size = new System.Drawing.Size(75, 23);
            this.ExecuteBtn.TabIndex = 4;
            this.ExecuteBtn.Text = "Execute";
            this.ExecuteBtn.UseVisualStyleBackColor = true;
            this.ExecuteBtn.Click += new System.EventHandler(this.ApplyBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelBtn.Location = new System.Drawing.Point(209, 33);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 5;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // RollingBallForm
            // 
            this.AcceptButton = this.ExecuteBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(290, 62);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RollingBallForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Rolling Ball Algorithm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WinSizeUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label WinSizeLbl;
        private System.Windows.Forms.NumericUpDown WinSizeUpDown;
        private System.Windows.Forms.Button ExecuteBtn;
        private System.Windows.Forms.Button CancelBtn;
    }
}