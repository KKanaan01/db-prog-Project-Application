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
    public partial class frmBrowseGames : Form
    {
        public frmBrowseGames()
        {
            InitializeComponent();
        }

        private void frmBrowseGames_Load(object sender, EventArgs e)
        {
            try
            {
                LoadGames();
                dgvGames.Visible = false;
            }
            catch (Exception ex)
            {
                DisplayCatchMessage(ex);
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if(cmbGameList.SelectedIndex <= 0)
                {
                    MessageBox.Show("Please Select a Game");
                }
                else
                {

                    string? selectedGame = cmbGameList.SelectedValue.ToString();

                    string sql = $@"SELECT p.PlatformName,
                            p.ReleaseDate,
                            p.Manufacturer,
                            p.[Description],
                            p.Price
                     FROM Game g
                     INNER JOIN Library_Games lg ON g.GameID = lg.GameID
                     INNER JOIN Platform p ON lg.PlatformID = p.PlatformID
                     WHERE g.GameID = {selectedGame}";

                    DataTable dtGamePlats = DataAccess.GetData(sql);

                    dgvGames.Visible = true;
                    dgvGames.DataSource = dtGamePlats;
                    dgvGames.ReadOnly = true;
                    dgvGames.AutoResizeColumns();
                }
            }
            catch(Exception ex)
            {
                DisplayCatchMessage(ex);
            }
        }

        #region Methods

        private void LoadGames()
        {
            string sql = "SELECT GameId, Title FROM Game ORDER BY Title";
            DataTable dt = DataAccess.GetData(sql);

            dt.AddEmptyRow("Title", "GameId" , 0);
            cmbGameList.Bind("Title", "GameId", dt);
        }

        private void DisplayCatchMessage(Exception ex)
        {
            MessageBox.Show(ex.Message, ex.GetType().ToString());
        }

        #endregion
    }
}
