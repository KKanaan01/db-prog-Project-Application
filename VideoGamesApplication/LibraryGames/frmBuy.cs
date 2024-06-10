using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryGames
{
    public partial class frmBuy : Form
    {
        public frmBuy()
        {
            InitializeComponent();
        }

        private DataTable dtGames;
        private decimal totalAmount = 0;
        private decimal discount;

        #region Event Handlers
        private void frmBuy_Load(object sender, EventArgs e)
        {
            try
            {
                LoadGames();
                LoadPlatforms();
            }
            catch (Exception ex)
            {
                DisplayCatchMessage(ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                AddToCart();
            }
            catch (Exception ex)
            {
                DisplayCatchMessage(ex);
            }
        }
        private void btnBuy_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                DisplayCatchMessage(ex);
            }
        }

        private void btnDisc_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstCart.Items.Count <= 0)
                {
                    MessageBox.Show("Please add games to your cart");
                }
                else
                {
                    CheckForDiscounts(); 
                }
            }
            catch (Exception ex)
            {
                DisplayCatchMessage(ex);
            }
        }
        #endregion


        #region Load Data

        private void LoadGames()
        {
            string sql = "SELECT Title , GameId , Price FROM Game ORDER BY Title";
            dtGames = DataAccess.GetData(sql);

            dtGames.AddEmptyRow("Title", "GameId", 0);
            cmbGames.Bind("Title", "GameId", dtGames);
        }

        private void LoadPlatforms()
        {
            string sql = "SELECT PlatformId , PlatformName FROM Platform ORDER BY PlatformName";
            DataTable dtPlatforms = DataAccess.GetData(sql);

            dtPlatforms.AddEmptyRow("PlatformName", "PlatformId", 0);
            cmbPlatforms.Bind("PlatformName", "PlatformId", dtPlatforms);
        }

        #endregion

        #region Action Methods
        private void AddToCart()
        {
            if (cmbGames.SelectedIndex <= 0 || cmbPlatforms.SelectedIndex <= 0)
            {
                MessageBox.Show("Please choose a game and platform");
            }
            else
            {
                string game = cmbGames.Text;
                string platform = cmbPlatforms.Text;
                decimal price = GetGamePrice();

                lstCart.Items.Add($"{game} - on {platform} - Price: {price:C}");

                totalAmount += price;
                txtTotal.Text = totalAmount.ToString("c");
            }
        }

        private decimal GetGamePrice()
        {
            decimal price = 0;

            string? selectedGame = cmbGames.SelectedValue.ToString();
            string sql = $"SELECT Title, Price FROM Game WHERE GameId = {selectedGame}";
            DataTable dtPrice = DataAccess.GetData(sql);

            price += Convert.ToDecimal(dtPrice.Rows[0]["Price"]);
            return price;
        }

        private void CheckForDiscounts()
        {
            string sql = "SELECT COUNT(*) FROM Library_Games";
            int count = Convert.ToInt32(DataAccess.GetValue(sql));

            decimal gamesPurchased = count % 5;


            if (lstCart.Items.Count >= 2)
            {
                discount = 0.25m * totalAmount;
                totalAmount -= discount;

                MessageBox.Show("25% discount will be applied");
                txtTotal.Text = totalAmount.ToString("c");
            }
            else if (gamesPurchased == 0 && lstCart.Items.Count > 0)
            {
                discount = 0.1m * totalAmount;
                totalAmount -= discount;

                MessageBox.Show("10% discount applied after 5 games purchased");
                txtTotal.Text = totalAmount.ToString("c");
            }
            else
            {
                MessageBox.Show("No discount applied");

            }

            btnDisc.Enabled = false;
        }

        private void BuyGame()
        {
            //do something
        }
        #endregion

        #region Make it easier methods
        private void DisplayCatchMessage(Exception ex)
        {
            MessageBox.Show(ex.Message, ex.GetType().ToString());
        }
        #endregion
    }
}
