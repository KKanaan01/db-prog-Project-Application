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
    public partial class frmBrowsePlatforms : Form
    {
        public frmBrowsePlatforms()
        {
            InitializeComponent();
        }

        private void frmBrowsePlatforms_Load(object sender, EventArgs e)
        {
            try
            {
                LoadPlatforms();
                dgvPlats.Visible = false;
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
                if (cmbPlatformList.SelectedIndex <= 0)
                {
                    MessageBox.Show("Please Select a Platform");
                }
                else
                {

                    string? selectedPlatform = cmbPlatformList.SelectedValue.ToString();

                    string sql = $@"SELECT 
                            g.Title,
                            g.ReleaseDate AS GameReleaseDate,
                            g.Publisher,
                            g.Price AS GamePrice,
                            g.Genre,
                            g.Rating,
                            g.DownloadSize
                     FROM Platform p
                     INNER JOIN Library_Games lg ON p.PlatformID = lg.PlatformID
                     INNER JOIN Game g ON lg.GameID = g.GameID
	                    WHERE p.PlatformID = {selectedPlatform}
                     ORDER BY p.PlatformName, g.Title";

                    DataTable dtGamePlats = DataAccess.GetData(sql);

                    dgvPlats.Visible = true;
                    dgvPlats.DataSource = dtGamePlats;
                    dgvPlats.ReadOnly = true;
                    dgvPlats.AutoResizeColumns();
                }
            }
            catch(Exception ex)
            {
                DisplayCatchMessage(ex);
            }
        }

        #region Methods
        private void LoadPlatforms()
        {
            string sql = "SELECT PlatformId , PlatformName FROM Platform ORDER BY PlatformName";
            DataTable dt = DataAccess.GetData(sql);

            dt.AddEmptyRow("PlatformName", "PlatformId", 0);
            cmbPlatformList.Bind("PlatformName", "PlatformId", dt);
        }

        private void DisplayCatchMessage(Exception ex)
        {
            MessageBox.Show(ex.Message, ex.GetType().ToString());
        }
        #endregion
    }
}
