namespace LibraryGames
{
    partial class frmPlatforms
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
            label1 = new Label();
            btnLast = new Button();
            btnNext = new Button();
            btnPrevious = new Button();
            btnFirst = new Button();
            btnAdd = new Button();
            btnSave = new Button();
            btnCancel = new Button();
            txtPlatformID = new TextBox();
            txtDesc = new TextBox();
            txtManufacturer = new TextBox();
            txtDate = new TextBox();
            txtName = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtPrice = new TextBox();
            label7 = new Label();
            btnDelete = new Button();
            grpPlats = new GroupBox();
            grpPlats.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Stencil", 25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(283, 10);
            label1.Name = "label1";
            label1.Size = new Size(268, 50);
            label1.TabIndex = 0;
            label1.Text = "Platforms";
            // 
            // btnLast
            // 
            btnLast.Location = new Point(67, 98);
            btnLast.Name = "btnLast";
            btnLast.Size = new Size(94, 37);
            btnLast.TabIndex = 2;
            btnLast.Text = "Last";
            btnLast.UseVisualStyleBackColor = true;
            btnLast.Click += Navigation_Handler;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(67, 231);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(94, 37);
            btnNext.TabIndex = 3;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += Navigation_Handler;
            // 
            // btnPrevious
            // 
            btnPrevious.Location = new Point(67, 168);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(94, 37);
            btnPrevious.TabIndex = 4;
            btnPrevious.Text = "Previous";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += Navigation_Handler;
            // 
            // btnFirst
            // 
            btnFirst.Location = new Point(67, 300);
            btnFirst.Name = "btnFirst";
            btnFirst.Size = new Size(94, 37);
            btnFirst.TabIndex = 5;
            btnFirst.Text = "First";
            btnFirst.UseVisualStyleBackColor = true;
            btnFirst.Click += Navigation_Handler;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(208, 121);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 45);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(208, 203);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 45);
            btnSave.TabIndex = 7;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(131, 371);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 47);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtPlatformID
            // 
            txtPlatformID.Location = new Point(102, 89);
            txtPlatformID.Name = "txtPlatformID";
            txtPlatformID.Size = new Size(250, 27);
            txtPlatformID.TabIndex = 9;
            // 
            // txtDesc
            // 
            txtDesc.Location = new Point(102, 399);
            txtDesc.Name = "txtDesc";
            txtDesc.Size = new Size(123, 27);
            txtDesc.TabIndex = 10;
            // 
            // txtManufacturer
            // 
            txtManufacturer.Location = new Point(102, 318);
            txtManufacturer.Name = "txtManufacturer";
            txtManufacturer.Size = new Size(250, 27);
            txtManufacturer.TabIndex = 11;
            // 
            // txtDate
            // 
            txtDate.Location = new Point(102, 242);
            txtDate.Name = "txtDate";
            txtDate.Size = new Size(250, 27);
            txtDate.TabIndex = 12;
            // 
            // txtName
            // 
            txtName.Location = new Point(102, 159);
            txtName.Name = "txtName";
            txtName.Size = new Size(250, 27);
            txtName.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Variable Display", 10F, FontStyle.Bold);
            label2.Location = new Point(175, 46);
            label2.Name = "label2";
            label2.Size = new Size(100, 22);
            label2.TabIndex = 14;
            label2.Text = "Platform ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Variable Display", 10F, FontStyle.Bold);
            label3.Location = new Point(197, 130);
            label3.Name = "label3";
            label3.Size = new Size(56, 22);
            label3.TabIndex = 15;
            label3.Text = "Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Variable Display", 10F, FontStyle.Bold);
            label4.Location = new Point(173, 212);
            label4.Name = "label4";
            label4.Size = new Size(111, 22);
            label4.TabIndex = 16;
            label4.Text = "Release Date";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Variable Display", 10F, FontStyle.Bold);
            label5.Location = new Point(172, 284);
            label5.Name = "label5";
            label5.Size = new Size(119, 22);
            label5.TabIndex = 17;
            label5.Text = "Manufacturer";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Variable Display", 10F, FontStyle.Bold);
            label6.Location = new Point(102, 361);
            label6.Name = "label6";
            label6.Size = new Size(103, 22);
            label6.TabIndex = 18;
            label6.Text = "Description";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(268, 399);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(84, 27);
            txtPrice.TabIndex = 19;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Variable Display", 10F, FontStyle.Bold);
            label7.Location = new Point(285, 361);
            label7.Name = "label7";
            label7.Size = new Size(50, 22);
            label7.TabIndex = 20;
            label7.Text = "Price";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(208, 281);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 45);
            btnDelete.TabIndex = 21;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // grpPlats
            // 
            grpPlats.Controls.Add(txtPlatformID);
            grpPlats.Controls.Add(txtDesc);
            grpPlats.Controls.Add(label6);
            grpPlats.Controls.Add(label7);
            grpPlats.Controls.Add(txtManufacturer);
            grpPlats.Controls.Add(txtPrice);
            grpPlats.Controls.Add(txtDate);
            grpPlats.Controls.Add(txtName);
            grpPlats.Controls.Add(label5);
            grpPlats.Controls.Add(label2);
            grpPlats.Controls.Add(label4);
            grpPlats.Controls.Add(label3);
            grpPlats.Location = new Point(361, 79);
            grpPlats.Name = "grpPlats";
            grpPlats.Size = new Size(447, 484);
            grpPlats.TabIndex = 22;
            grpPlats.TabStop = false;
            grpPlats.Text = "Information";
            // 
            // frmPlatforms
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(852, 596);
            Controls.Add(grpPlats);
            Controls.Add(btnDelete);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(btnAdd);
            Controls.Add(btnFirst);
            Controls.Add(btnPrevious);
            Controls.Add(btnNext);
            Controls.Add(btnLast);
            Controls.Add(label1);
            Name = "frmPlatforms";
            Text = "Platforms";
            Load += frmPlatforms_Load;
            grpPlats.ResumeLayout(false);
            grpPlats.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnLast;
        private Button btnNext;
        private Button btnPrevious;
        private Button btnFirst;
        private Button btnAdd;
        private Button btnSave;
        private Button btnCancel;
        private TextBox txtPlatformID;
        private TextBox txtDesc;
        private TextBox txtManufacturer;
        private TextBox txtDate;
        private TextBox txtName;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtPrice;
        private Label label7;
        private Button btnDelete;
        private GroupBox grpPlats;
    }
}