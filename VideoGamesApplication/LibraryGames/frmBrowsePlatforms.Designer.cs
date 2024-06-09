namespace LibraryGames
{
    partial class frmBrowsePlatforms
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
            grpPlatforms = new GroupBox();
            btnShow = new Button();
            cmbPlatformList = new ComboBox();
            dgvPlats = new DataGridView();
            grpPlatforms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPlats).BeginInit();
            SuspendLayout();
            // 
            // grpPlatforms
            // 
            grpPlatforms.Controls.Add(btnShow);
            grpPlatforms.Controls.Add(cmbPlatformList);
            grpPlatforms.Location = new Point(255, 12);
            grpPlatforms.Name = "grpPlatforms";
            grpPlatforms.Size = new Size(306, 162);
            grpPlatforms.TabIndex = 0;
            grpPlatforms.TabStop = false;
            grpPlatforms.Text = "Choose a Platform";
            // 
            // btnShow
            // 
            btnShow.Location = new Point(95, 117);
            btnShow.Name = "btnShow";
            btnShow.Size = new Size(117, 29);
            btnShow.TabIndex = 1;
            btnShow.Text = "Show Details";
            btnShow.UseVisualStyleBackColor = true;
            btnShow.Click += btnShow_Click;
            // 
            // cmbPlatformList
            // 
            cmbPlatformList.FormattingEnabled = true;
            cmbPlatformList.Location = new Point(24, 74);
            cmbPlatformList.Name = "cmbPlatformList";
            cmbPlatformList.Size = new Size(258, 28);
            cmbPlatformList.TabIndex = 0;
            // 
            // dgvPlats
            // 
            dgvPlats.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPlats.Location = new Point(12, 208);
            dgvPlats.Name = "dgvPlats";
            dgvPlats.RowHeadersWidth = 51;
            dgvPlats.Size = new Size(776, 230);
            dgvPlats.TabIndex = 1;
            // 
            // frmBrowsePlatforms
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvPlats);
            Controls.Add(grpPlatforms);
            Name = "frmBrowsePlatforms";
            Text = "frmBrowsePlatforms";
            Load += frmBrowsePlatforms_Load;
            grpPlatforms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPlats).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpPlatforms;
        private Button btnShow;
        private ComboBox cmbPlatformList;
        private DataGridView dgvPlats;
    }
}