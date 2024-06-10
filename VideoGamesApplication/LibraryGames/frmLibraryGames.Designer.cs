namespace LibraryGames
{
    partial class frmLibraryGames
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
            grpLibrary = new GroupBox();
            cmbPlatforms = new ComboBox();
            cmbGame = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            btnLast = new Button();
            btnCancel = new Button();
            btnSave = new Button();
            btnDelete = new Button();
            btnPrevious = new Button();
            btnNext = new Button();
            btnAdd = new Button();
            btnFirst = new Button();
            grpLibrary.SuspendLayout();
            SuspendLayout();
            // 
            // grpLibrary
            // 
            grpLibrary.Controls.Add(cmbPlatforms);
            grpLibrary.Controls.Add(cmbGame);
            grpLibrary.Controls.Add(label2);
            grpLibrary.Controls.Add(label1);
            grpLibrary.Controls.Add(btnLast);
            grpLibrary.Controls.Add(btnCancel);
            grpLibrary.Controls.Add(btnSave);
            grpLibrary.Controls.Add(btnDelete);
            grpLibrary.Controls.Add(btnPrevious);
            grpLibrary.Controls.Add(btnNext);
            grpLibrary.Controls.Add(btnAdd);
            grpLibrary.Controls.Add(btnFirst);
            grpLibrary.Location = new Point(21, 21);
            grpLibrary.Name = "grpLibrary";
            grpLibrary.Size = new Size(632, 476);
            grpLibrary.TabIndex = 0;
            grpLibrary.TabStop = false;
            grpLibrary.Text = "Library Games";
            // 
            // cmbPlatforms
            // 
            cmbPlatforms.FormattingEnabled = true;
            cmbPlatforms.Location = new Point(168, 212);
            cmbPlatforms.Name = "cmbPlatforms";
            cmbPlatforms.Size = new Size(297, 28);
            cmbPlatforms.TabIndex = 13;
            // 
            // cmbGame
            // 
            cmbGame.FormattingEnabled = true;
            cmbGame.Location = new Point(168, 102);
            cmbGame.Name = "cmbGame";
            cmbGame.Size = new Size(297, 28);
            cmbGame.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(279, 178);
            label2.Name = "label2";
            label2.Size = new Size(66, 20);
            label2.TabIndex = 11;
            label2.Text = "Platform";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(288, 66);
            label1.Name = "label1";
            label1.Size = new Size(48, 20);
            label1.TabIndex = 10;
            label1.Text = "Game";
            // 
            // btnLast
            // 
            btnLast.Location = new Point(496, 298);
            btnLast.Name = "btnLast";
            btnLast.Size = new Size(94, 29);
            btnLast.TabIndex = 9;
            btnLast.Text = "Last";
            btnLast.UseVisualStyleBackColor = true;
            btnLast.Click += Navigation_Handler;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(496, 389);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(353, 389);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 7;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(189, 389);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.Location = new Point(189, 298);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(94, 29);
            btnPrevious.TabIndex = 5;
            btnPrevious.Text = "Previous";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += Navigation_Handler;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(353, 298);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(94, 29);
            btnNext.TabIndex = 4;
            btnNext.Text = " Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += Navigation_Handler;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(29, 389);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnFirst
            // 
            btnFirst.Location = new Point(29, 298);
            btnFirst.Name = "btnFirst";
            btnFirst.Size = new Size(94, 29);
            btnFirst.TabIndex = 2;
            btnFirst.Text = "First";
            btnFirst.UseVisualStyleBackColor = true;
            btnFirst.Click += Navigation_Handler;
            // 
            // frmLibraryGames
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(665, 509);
            Controls.Add(grpLibrary);
            Name = "frmLibraryGames";
            Text = "Library Games";
            Load += frmLibraryGames_Load;
            grpLibrary.ResumeLayout(false);
            grpLibrary.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpLibrary;
        private Button btnFirst;
        private Button btnLast;
        private Button btnCancel;
        private Button btnSave;
        private Button btnDelete;
        private Button btnPrevious;
        private Button btnNext;
        private Button btnAdd;
        private Label label2;
        private Label label1;
        private ComboBox cmbPlatforms;
        private ComboBox cmbGame;
    }
}