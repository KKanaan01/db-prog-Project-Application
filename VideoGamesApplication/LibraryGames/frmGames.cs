using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LibraryGames
{
    public partial class frmGames : Form
    {
        public frmGames()
        {
            InitializeComponent();
        }

        #region Private Fields
        int currentId;
        private int firstId;
        private int lastId;
        private int? nextId;
        private int? previousId;
        private int? rowNumber;
        private FormState currentState;
        #endregion

        #region Event Handlers
        private void frmGames_Load(object sender, EventArgs e)
        {
            try
            {
                LoadFirstGame();
                SetState(FormState.View);
            }
            catch (Exception ex)
            {
                DisplayCatchMessage(ex);
            }
        }

        private void Navigation_Handler(object sender, EventArgs e)
        {
            try
            {
                if (sender == btnFirst)
                {
                    currentId = firstId;
                }
                else if (sender == btnLast)
                {
                    currentId = lastId;
                }
                else if (sender == btnNext)
                {
                    if (nextId != null)
                        currentId = nextId.Value;
                    else
                        MessageBox.Show("Last Game currently displayed");

                }
                else if (sender == btnPrevious)
                {
                    if (previousId != null)
                        currentId = previousId.Value;
                    else
                        MessageBox.Show("First Game currently displayed");
                }
                else
                {
                    return;
                }

                LoadCurrentPosition();
                DisplayCurrentGame();
            }
            catch (Exception ex)
            {
                DisplayCatchMessage(ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetState(FormState.Add);
            txtGameID.ReadOnly = true;
            this.DisplayParentStatusStripMessage("Adding...");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string gameId = txtGameID.Text;
            int assignments = Convert.ToInt32(DataAccess.GetValue($"SELECT COUNT(1) FROM Library_Games WHERE GameId = {gameId};"));

            if (assignments == 0)
            {
                DeleteGame();
                LoadFirstGame();
            }
            else
            {
                MessageBox.Show("This Game could not be deleted because it is associated with a platform in the database.");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.DisplayParentStatusStripMessage("Editing...");

                if (currentState == FormState.View)
                {
                    SetState(FormState.Edit);
                }
                else
                {
                    if (ValidateChildren())
                    {
                        
                        if (txtGameID.Text == string.Empty)
                        {
                            CreateGame();
                            LoadFirstGame();
                        }
                        else
                        {
                            UpdateGame();
                        }

                        SetState(FormState.View);
                        DisplayPosition();
                    }
                    else
                    {
                        MessageBox.Show("Solve your errors");
                    }

                }
            }
            catch (Exception ex)
            {
                DisplayCatchMessage(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetState(FormState.View);
            DisplayCurrentGame();
        }
        #endregion

        #region Load Data

        private void LoadFirstGame()
        {
            currentId = GetFirstGame();
            LoadCurrentPosition();
            DisplayCurrentGame();
        }

        private int GetFirstGame()
        {
            string sql = $"SELECT TOP (1) GameID FROM Game ORDER BY Title";
            int id = Convert.ToInt32(DataAccess.GetValue(sql));

            return id;
        }

        private DataRow GetGameDataRow(int id)
        {
            string sql = $"SELECT * FROM Game WHERE GameId = {id}";
            DataTable dt = DataAccess.GetData(sql);
            return dt.Rows[0];
        }

        private void LoadCurrentPosition()
        {
            DataRow positionInfoRow = GetPositionDataRow(currentId);
            LoadPositionInfo(positionInfoRow);
            NavigationButtonManagement();
        }

        private void LoadPositionInfo(DataRow positionRow)
        {
            currentId = Convert.ToInt32(positionRow["GameId"]);
            firstId = Convert.ToInt32(positionRow["FirstGameId"]);
            lastId = Convert.ToInt32(positionRow["LastGameId"]);
            rowNumber = Convert.ToInt32(positionRow["RowNumber"]);

            nextId = positionRow["NextGameId"] != DBNull.Value ?
                Convert.ToInt32(positionRow["NextGameId"]) : null;

            previousId = positionRow["PreviousGameId"] != DBNull.Value ?
                Convert.ToInt32(positionRow["PreviousGameId"]) : null;
        }

        private DataRow GetPositionDataRow(int id)
        {
            string sql = $@"SELECT GameId,
(
	SELECT TOP 1 GameId AS FirstGameId FROM Game ORDER BY Title
) AS FirstGameId,
g.PreviousGameId,
g.NextGameId,
(
	SELECT TOP 1 GameId AS FirstGameId FROM Game ORDER BY Title DESC
) AS LastGameId,
g.RowNumber
FROM
(
	SELECT GameId , Title,
	LEAD(GameId) OVER (ORDER BY Title) AS NextGameId,
	LAG(GameId) OVER (ORDER BY Title) AS PreviousGameId,
	 ROW_NUMBER() OVER(ORDER BY Title) AS 'RowNumber'
	FROM Game
) AS g
WHERE g.GameId = {id}
ORDER BY Title ASC;";

            DataTable dt = DataAccess.GetData(sql);
            return dt.Rows[0];
        }
        #endregion

        #region Displaying Data
        private void DisplayCurrentGame()
        {
            DataRow currentRow = GetGameDataRow(currentId);
            DisplayGame(currentRow);
        }

        private void DisplayGame(DataRow selectedRow)
        {
            txtGameID.Text = selectedRow["GameID"].ToString();
            txtTitle.Text = selectedRow["Title"].ToString();
            txtDate.Text = selectedRow["ReleaseDate"].ToString();
            txtPublisher.Text = selectedRow["Publisher"].ToString();
            txtGenre.Text = selectedRow["Genre"].ToString();
            txtPrice.Text = selectedRow["Price"].ToString();
            txtSize.Text = selectedRow["DownloadSize"].ToString();
            txtRating.Text = selectedRow["Rating"].ToString();

            DisplayPosition();

        }
        #endregion

        #region Form State
        private void LoadState(FormState state)
        {
            if (state == FormState.View)
            {
                btnAdd.Enabled = true;
                btnCancel.Enabled = false;
                btnDelete.Enabled = true;
                btnSave.Text = "Edit";
                InputsReadOnly(true);
                NavigationButtonManagement();
            }
            else
            {
                btnAdd.Enabled = false;
                btnCancel.Enabled = true;
                btnDelete.Enabled = false;
                btnSave.Text = "Save";
                InputsReadOnly(false);

                if (state == FormState.Add)
                    UIUtilities.ClearControls(grpNavigation.Controls);

                DisableNavigation();
            }
        }

        private void SetState(FormState state)
        {
            currentState = state;
            LoadState(state);
        }
        #endregion

        #region Buttons / Textboxes Management
        private void NavigationButtonManagement()
        {
            btnPrevious.Enabled = previousId != null;
            btnNext.Enabled = nextId != null;

            btnFirst.Enabled = currentId != firstId;
            btnLast.Enabled = currentId != lastId;
        }

        private void DisableNavigation()
        {
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;
            btnFirst.Enabled = false;
            btnLast.Enabled = false;
        }

        private void InputsReadOnly(bool readOnly)
        {
            txtGameID.ReadOnly = readOnly;
            txtTitle.ReadOnly = readOnly;
            txtPublisher.ReadOnly = readOnly;
            txtDate.ReadOnly = readOnly;
            txtPrice.ReadOnly = readOnly;
            txtGenre.ReadOnly = readOnly;
            txtRating.ReadOnly = readOnly;
            txtSize.ReadOnly = readOnly;
        }

        private void txt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            string errMsg = null;

            if (txt.Text == string.Empty)
            {
                errMsg = $"{txt.Tag} is required.";
                e.Cancel = true;
            }

            if (sender == txtPrice || sender == txtRating || sender == txtSize)
            {
                if (!isNumeric(txt.Text))
                {
                    errMsg = $"{txt.Tag} must be a valid number";
                    e.Cancel = true;
                }
            }

            if (sender == txtDate)
            {
                if (!DateTime.TryParse(txt.Text, out DateTime dateValue))
                {
                    errMsg = $"{txt.Tag} must be a valid date";
                    e.Cancel = true;
                }
            }

            errorProvider1.SetError(txt, errMsg);
        }

        private bool isNumeric(string value)
        {
            return decimal.TryParse(value, out _);
        }
        #endregion

        #region Make it easier Methods
        private void DisplayCatchMessage(Exception ex)
        {
            MessageBox.Show(ex.Message, ex.GetType().ToString());
        }

        private void DisplayPosition()
        {
            DataTable dt = DataAccess.GetData("SELECT * FROM Game");
            this.DisplayParentStatusStripMessage($"Loaded {rowNumber} out of {dt.Rows.Count} Games");
        }
        #endregion

        #region Action Methods
        private void CreateGame()
        {
            string sqlEnterPlatform = $@"
                     INSERT INTO Game
                     (
                        Title,
                        ReleaseDate,
                        Publisher,
                        Price,
                        Genre,
                        Rating,
                        DownloadSize    
                     )
                     VALUES
                     (
                        '{DataAccess.SQLFix(txtTitle.Text.Trim())}'
                        ,'{txtDate.Text.Trim()}'
                        ,'{DataAccess.SQLFix(txtPublisher.Text.Trim())}'
                        ,'{txtPrice.Text}'
                        ,'{DataAccess.SQLFix(txtGenre.Text.Trim())}'
                        ,' {txtRating.Text}'
                        ,'{txtSize.Text}'
                     )";

            int rowsAffected = DataAccess.SendData(sqlEnterPlatform);

            if (rowsAffected == 1)
            {
                MessageBox.Show("Game has been added");
            }
            else
            {
                MessageBox.Show("Game could not be created");
            }

        }

        private void DeleteGame()
        {
            string sqlDelete = $"DELETE FROM Game WHERE GameId = {txtGameID.Text}";

            int rowsAffected = DataAccess.SendData(sqlDelete);

            if (rowsAffected == 1)
            {
                MessageBox.Show("Game has been deleted");
            }
            else
            {
                MessageBox.Show("No rows affected");
            }
        }

        private void UpdateGame()
        {
            string sql = $@"UPDATE Game
            SET 
            Title = '{DataAccess.SQLFix(txtTitle.Text.Trim())}',
            ReleaseDate = '{txtDate.Text}',
            Publisher = '{DataAccess.SQLFix(txtPublisher.Text.Trim())}',
            Price = '{txtPrice.Text}',
            Genre = '{DataAccess.SQLFix(txtGenre.Text.Trim())}',
            Rating = '{txtRating.Text}',
            DownloadSize = '{txtSize.Text}'
            WHERE GameID = '{txtGameID.Text}'";

            int rowsAffected = DataAccess.SendData(sql);

            if (rowsAffected == 0)
            {
                MessageBox.Show("No rows affected");
            }
            else if (rowsAffected == 1)
            {
                MessageBox.Show("Game has been updated");
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }
        }
        #endregion
    }
}
