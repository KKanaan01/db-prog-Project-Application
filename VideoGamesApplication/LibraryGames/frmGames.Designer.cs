namespace LibraryGames
{
    partial class frmGames
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
            grpNavigation = new GroupBox();
            btnCancel = new Button();
            btnSave = new Button();
            btnDelete = new Button();
            btnAdd = new Button();
            btnLast = new Button();
            btnNext = new Button();
            btnPrevious = new Button();
            btnFirst = new Button();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            lbl1 = new Label();
            lbl = new Label();
            txtPrice = new TextBox();
            txtSize = new TextBox();
            txtRating = new TextBox();
            txtDate = new TextBox();
            txtPublisher = new TextBox();
            txtGenre = new TextBox();
            txtTitle = new TextBox();
            txtGameID = new TextBox();
            grpNavigation.SuspendLayout();
            SuspendLayout();
            // 
            // grpNavigation
            // 
            grpNavigation.Controls.Add(btnCancel);
            grpNavigation.Controls.Add(btnSave);
            grpNavigation.Controls.Add(btnDelete);
            grpNavigation.Controls.Add(btnAdd);
            grpNavigation.Controls.Add(btnLast);
            grpNavigation.Controls.Add(btnNext);
            grpNavigation.Controls.Add(btnPrevious);
            grpNavigation.Controls.Add(btnFirst);
            grpNavigation.Controls.Add(label8);
            grpNavigation.Controls.Add(label7);
            grpNavigation.Controls.Add(label6);
            grpNavigation.Controls.Add(label5);
            grpNavigation.Controls.Add(label4);
            grpNavigation.Controls.Add(label3);
            grpNavigation.Controls.Add(lbl1);
            grpNavigation.Controls.Add(lbl);
            grpNavigation.Controls.Add(txtPrice);
            grpNavigation.Controls.Add(txtSize);
            grpNavigation.Controls.Add(txtRating);
            grpNavigation.Controls.Add(txtDate);
            grpNavigation.Controls.Add(txtPublisher);
            grpNavigation.Controls.Add(txtGenre);
            grpNavigation.Controls.Add(txtTitle);
            grpNavigation.Controls.Add(txtGameID);
            grpNavigation.Location = new Point(12, 50);
            grpNavigation.Name = "grpNavigation";
            grpNavigation.Size = new Size(865, 695);
            grpNavigation.TabIndex = 0;
            grpNavigation.TabStop = false;
            grpNavigation.Text = "Navigation";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(673, 593);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(118, 68);
            btnCancel.TabIndex = 26;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(464, 593);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(118, 68);
            btnSave.TabIndex = 25;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(244, 593);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(118, 68);
            btnDelete.TabIndex = 24;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(35, 593);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(118, 68);
            btnAdd.TabIndex = 23;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnLast
            // 
            btnLast.Location = new Point(673, 493);
            btnLast.Name = "btnLast";
            btnLast.Size = new Size(118, 68);
            btnLast.TabIndex = 22;
            btnLast.Text = "Last";
            btnLast.UseVisualStyleBackColor = true;
            btnLast.Click += Navigation_Handler;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(464, 493);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(118, 68);
            btnNext.TabIndex = 21;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += Navigation_Handler;
            // 
            // btnPrevious
            // 
            btnPrevious.Location = new Point(244, 493);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(118, 68);
            btnPrevious.TabIndex = 20;
            btnPrevious.Text = "Previous";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += Navigation_Handler;
            // 
            // btnFirst
            // 
            btnFirst.Location = new Point(35, 493);
            btnFirst.Name = "btnFirst";
            btnFirst.Size = new Size(118, 68);
            btnFirst.TabIndex = 19;
            btnFirst.Text = "First";
            btnFirst.UseVisualStyleBackColor = true;
            btnFirst.Click += Navigation_Handler;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(568, 357);
            label8.Name = "label8";
            label8.Size = new Size(41, 20);
            label8.TabIndex = 18;
            label8.Text = "Price";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(621, 272);
            label7.Name = "label7";
            label7.Size = new Size(109, 20);
            label7.TabIndex = 17;
            label7.Text = "Download Size";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(481, 272);
            label6.Name = "label6";
            label6.Size = new Size(52, 20);
            label6.TabIndex = 16;
            label6.Text = "Rating";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(37, 272);
            label5.Name = "label5";
            label5.Size = new Size(48, 20);
            label5.TabIndex = 15;
            label5.Text = "Genre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(464, 174);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 14;
            label4.Text = "Publisher";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(35, 174);
            label3.Name = "label3";
            label3.Size = new Size(96, 20);
            label3.TabIndex = 13;
            label3.Text = "Release Date";
            // 
            // lbl1
            // 
            lbl1.AutoSize = true;
            lbl1.Location = new Point(464, 67);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(38, 20);
            lbl1.TabIndex = 12;
            lbl1.Text = "Title";
            // 
            // lbl
            // 
            lbl.AutoSize = true;
            lbl.Location = new Point(37, 67);
            lbl.Name = "lbl";
            lbl.Size = new Size(67, 20);
            lbl.TabIndex = 11;
            lbl.Text = "Game ID";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(541, 380);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(95, 27);
            txtPrice.TabIndex = 10;
            // 
            // txtSize
            // 
            txtSize.Location = new Point(623, 295);
            txtSize.Name = "txtSize";
            txtSize.Size = new Size(107, 27);
            txtSize.TabIndex = 9;
            // 
            // txtRating
            // 
            txtRating.Location = new Point(464, 295);
            txtRating.Name = "txtRating";
            txtRating.Size = new Size(95, 27);
            txtRating.TabIndex = 8;
            // 
            // txtDate
            // 
            txtDate.Location = new Point(35, 197);
            txtDate.Name = "txtDate";
            txtDate.Size = new Size(266, 27);
            txtDate.TabIndex = 7;
            // 
            // txtPublisher
            // 
            txtPublisher.Location = new Point(464, 197);
            txtPublisher.Name = "txtPublisher";
            txtPublisher.Size = new Size(266, 27);
            txtPublisher.TabIndex = 6;
            // 
            // txtGenre
            // 
            txtGenre.Location = new Point(37, 295);
            txtGenre.Name = "txtGenre";
            txtGenre.Size = new Size(266, 27);
            txtGenre.TabIndex = 5;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(464, 90);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(266, 27);
            txtTitle.TabIndex = 4;
            // 
            // txtGameID
            // 
            txtGameID.Location = new Point(37, 90);
            txtGameID.Name = "txtGameID";
            txtGameID.Size = new Size(266, 27);
            txtGameID.TabIndex = 0;
            // 
            // frmGames
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(910, 788);
            Controls.Add(grpNavigation);
            Name = "frmGames";
            Text = "Games";
            Load += frmGames_Load;
            grpNavigation.ResumeLayout(false);
            grpNavigation.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox grpNavigation;
        private TextBox txtRating;
        private TextBox txtDate;
        private TextBox txtPublisher;
        private TextBox txtGenre;
        private TextBox txtTitle;
        private TextBox txtGameID;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label lbl1;
        private Label lbl;
        private TextBox txtPrice;
        private TextBox txtSize;
        private Button btnCancel;
        private Button btnSave;
        private Button btnDelete;
        private Button btnAdd;
        private Button btnLast;
        private Button btnNext;
        private Button btnPrevious;
        private Button btnFirst;
    }
}