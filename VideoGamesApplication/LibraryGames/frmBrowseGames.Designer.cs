namespace LibraryGames
{
    partial class frmBrowseGames
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
            grpGame = new GroupBox();
            btnShow = new Button();
            cmbGameList = new ComboBox();
            dgvGames = new DataGridView();
            grpGame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGames).BeginInit();
            SuspendLayout();
            // 
            // grpGame
            // 
            grpGame.Controls.Add(btnShow);
            grpGame.Controls.Add(cmbGameList);
            grpGame.Location = new Point(290, 12);
            grpGame.Name = "grpGame";
            grpGame.Size = new Size(288, 146);
            grpGame.TabIndex = 0;
            grpGame.TabStop = false;
            grpGame.Text = "Choose a game";
            // 
            // btnShow
            // 
            btnShow.Location = new Point(76, 101);
            btnShow.Name = "btnShow";
            btnShow.Size = new Size(126, 29);
            btnShow.TabIndex = 1;
            btnShow.Text = "Show Details";
            btnShow.UseVisualStyleBackColor = true;
            btnShow.Click += btnShow_Click;
            // 
            // cmbGameList
            // 
            cmbGameList.FormattingEnabled = true;
            cmbGameList.Location = new Point(17, 56);
            cmbGameList.Name = "cmbGameList";
            cmbGameList.Size = new Size(254, 28);
            cmbGameList.TabIndex = 0;
            // 
            // dgvGames
            // 
            dgvGames.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGames.Location = new Point(31, 196);
            dgvGames.Name = "dgvGames";
            dgvGames.RowHeadersWidth = 51;
            dgvGames.Size = new Size(799, 263);
            dgvGames.TabIndex = 1;
            // 
            // frmBrowseGames
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(854, 483);
            Controls.Add(dgvGames);
            Controls.Add(grpGame);
            Name = "frmBrowseGames";
            Text = "Browse Games";
            Load += frmBrowseGames_Load;
            grpGame.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvGames).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpGame;
        private ComboBox cmbGameList;
        private DataGridView dgvGames;
        private Button btnShow;
    }
}