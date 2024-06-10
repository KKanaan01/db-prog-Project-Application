namespace LibraryGames
{
    partial class frmBuy
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
            cmbGames = new ComboBox();
            cmbPlatforms = new ComboBox();
            lstCart = new ListBox();
            btnAdd = new Button();
            lblTotal = new Label();
            txtTotal = new TextBox();
            btnBuy = new Button();
            label1 = new Label();
            label2 = new Label();
            btnDisc = new Button();
            SuspendLayout();
            // 
            // cmbGames
            // 
            cmbGames.FormattingEnabled = true;
            cmbGames.Location = new Point(12, 142);
            cmbGames.Name = "cmbGames";
            cmbGames.Size = new Size(243, 28);
            cmbGames.TabIndex = 0;
            // 
            // cmbPlatforms
            // 
            cmbPlatforms.FormattingEnabled = true;
            cmbPlatforms.Location = new Point(12, 251);
            cmbPlatforms.Name = "cmbPlatforms";
            cmbPlatforms.Size = new Size(243, 28);
            cmbPlatforms.TabIndex = 1;
            // 
            // lstCart
            // 
            lstCart.FormattingEnabled = true;
            lstCart.Location = new Point(325, 36);
            lstCart.Name = "lstCart";
            lstCart.Size = new Size(514, 384);
            lstCart.TabIndex = 2;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(73, 358);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Add to Cart";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(954, 79);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(42, 20);
            lblTotal.TabIndex = 4;
            lblTotal.Text = "Total";
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(917, 119);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(125, 27);
            txtTotal.TabIndex = 5;
            // 
            // btnBuy
            // 
            btnBuy.Location = new Point(902, 274);
            btnBuy.Name = "btnBuy";
            btnBuy.Size = new Size(151, 65);
            btnBuy.TabIndex = 6;
            btnBuy.Text = "Purchase";
            btnBuy.UseVisualStyleBackColor = true;
            btnBuy.Click += btnBuy_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(91, 119);
            label1.Name = "label1";
            label1.Size = new Size(92, 20);
            label1.TabIndex = 7;
            label1.Text = "Select Game";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(73, 228);
            label2.Name = "label2";
            label2.Size = new Size(110, 20);
            label2.TabIndex = 8;
            label2.Text = "Select Platform";
            // 
            // btnDisc
            // 
            btnDisc.Location = new Point(893, 188);
            btnDisc.Name = "btnDisc";
            btnDisc.Size = new Size(173, 49);
            btnDisc.TabIndex = 9;
            btnDisc.Text = "Check for discounts";
            btnDisc.UseVisualStyleBackColor = true;
            btnDisc.Click += btnDisc_Click;
            // 
            // frmBuy
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1094, 450);
            Controls.Add(btnDisc);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnBuy);
            Controls.Add(txtTotal);
            Controls.Add(lblTotal);
            Controls.Add(btnAdd);
            Controls.Add(lstCart);
            Controls.Add(cmbPlatforms);
            Controls.Add(cmbGames);
            Name = "frmBuy";
            Text = "frmBuy";
            Load += frmBuy_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbGames;
        private ComboBox cmbPlatforms;
        private ListBox lstCart;
        private Button btnAdd;
        private Label lblTotal;
        private TextBox txtTotal;
        private Button btnBuy;
        private Label label1;
        private Label label2;
        private Button btnDisc;
    }
}