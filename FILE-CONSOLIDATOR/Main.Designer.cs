namespace FILE_CONSOLIDATOR
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.pbProgress = new MetroFramework.Controls.MetroProgressBar();
            this.lblTotalFiles = new MetroFramework.Controls.MetroLabel();
            this.dtpDateTrans = new MetroFramework.Controls.MetroDateTime();
            this.btnStart = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.lblFiles = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(11, 218);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(547, 23);
            this.pbProgress.TabIndex = 8;
            // 
            // lblTotalFiles
            // 
            this.lblTotalFiles.AutoSize = true;
            this.lblTotalFiles.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTotalFiles.Location = new System.Drawing.Point(11, 161);
            this.lblTotalFiles.Name = "lblTotalFiles";
            this.lblTotalFiles.Size = new System.Drawing.Size(92, 25);
            this.lblTotalFiles.TabIndex = 9;
            this.lblTotalFiles.Text = "Total Files:";
            this.lblTotalFiles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpDateTrans
            // 
            this.dtpDateTrans.CustomFormat = "yyyy - MMMM";
            this.dtpDateTrans.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTrans.Location = new System.Drawing.Point(194, 63);
            this.dtpDateTrans.MinimumSize = new System.Drawing.Size(0, 30);
            this.dtpDateTrans.Name = "dtpDateTrans";
            this.dtpDateTrans.Size = new System.Drawing.Size(200, 30);
            this.dtpDateTrans.TabIndex = 10;
            // 
            // btnStart
            // 
            this.btnStart.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnStart.Location = new System.Drawing.Point(194, 99);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(200, 50);
            this.btnStart.TabIndex = 11;
            this.btnStart.Text = "Start";
            this.btnStart.UseSelectable = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(134, 68);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(54, 25);
            this.metroLabel1.TabIndex = 12;
            this.metroLabel1.Text = "Date:";
            // 
            // lblFiles
            // 
            this.lblFiles.AutoSize = true;
            this.lblFiles.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblFiles.Location = new System.Drawing.Point(11, 188);
            this.lblFiles.Name = "lblFiles";
            this.lblFiles.Size = new System.Drawing.Size(0, 0);
            this.lblFiles.TabIndex = 13;
            this.lblFiles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(572, 260);
            this.Controls.Add(this.lblFiles);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.dtpDateTrans);
            this.Controls.Add(this.lblTotalFiles);
            this.Controls.Add(this.pbProgress);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "File Consolidator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public MetroFramework.Controls.MetroProgressBar pbProgress;
        public MetroFramework.Controls.MetroLabel lblTotalFiles;
        private MetroFramework.Controls.MetroDateTime dtpDateTrans;
        public MetroFramework.Controls.MetroButton btnStart;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        public MetroFramework.Controls.MetroLabel lblFiles;
    }
}

