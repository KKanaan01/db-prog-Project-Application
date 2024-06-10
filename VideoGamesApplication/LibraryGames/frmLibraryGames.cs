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
    public partial class frmLibraryGames : Form
    {
        public frmLibraryGames()
        {
            InitializeComponent();
        }

        #region Private Fields
        int currentGameId;
        int currentPlatformId;

        int firstGameId;
        int firstPlatformId;

        int lastGameId;
        int lastPlatformId;

        int? previousGameId;
        int? previousPlatformId;

        int? nextGameId;
        int? nextPlatformId;

        private FormState currentState;

        #endregion

        #region Event Handlers
        private void frmLibraryGames_Load(object sender, EventArgs e)
        {
            try
            {
                LoadGames();
                LoadPlatforms();
                LoadFirstLibraryGame();

                SetState(FormState.View);
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
                LoadGames();
                LoadPlatforms();

                SetState(FormState.Add);
            }
            catch (Exception ex)
            {
                DisplayCatchMessage(ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to delete this Game", "Are you sure?",
                   MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DeleteLibraryGame();
                    LoadFirstLibraryGame();
                }
            }
            catch (Exception ex)
            {
                DisplayCatchMessage(ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentState == FormState.View)
                {
                    SetState(FormState.Edit);
                }
                else
                {
                    if (this.ValidateChildren())
                    {
                        if (currentState == FormState.Add)
                        {
                            CreateLibraryGame();
                            LoadFirstLibraryGame();
                        }
                        else
                        {
                            MessageBox.Show("Could not create");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please resolve your validation errors");
                    }

                    SetState(FormState.View);
                }
            }
            catch (Exception ex)
            {
                DisplayCatchMessage(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                SetState(FormState.View);
                DisplayCurrentLibraryGame();
            }
            catch (Exception ex)
            {
                DisplayCatchMessage(ex);
            }
        }
        #endregion

        #region Form State
        private void SetState(FormState state)
        {
            currentState = state;
            LoadState(state);
        }

        private void LoadState(FormState state)
        {
            if (state == FormState.View)
            {
                btnAdd.Enabled = true;
                btnCancel.Enabled = false;
                btnDelete.Enabled = true;
                btnSave.Text = "Edit";
                AllowInputs(false);
            }
            else
            {
                btnAdd.Enabled = false;
                btnCancel.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Text = "Save";
                AllowInputs(true);
                if (state == FormState.Add)
                {
                    grpLibrary.Controls.ClearControls(defaultSelectedIndex: -1);
                }
            }

            EnableNavigation(currentState == FormState.View);
        }

        private void AllowInputs(bool allowInput)
        {
            cmbGame.Enabled = allowInput;
            cmbPlatforms.Enabled = allowInput;
        }

        private void Navigation_Handler(object sender, EventArgs e)
        {
            if (sender == btnFirst)
            {
                currentGameId = firstGameId;
                currentPlatformId = firstPlatformId;
            }
            else if (sender == btnNext)
            {
                currentGameId = nextGameId.Value;
                currentPlatformId = nextPlatformId.Value;
            }
            else if (sender == btnPrevious)
            {
                currentGameId = previousGameId.Value;
                currentPlatformId = previousPlatformId.Value;
            }
            else if (sender == btnLast)
            {
                currentPlatformId = lastPlatformId;
                currentGameId = lastGameId;
            }
            else
            {
                return;
            }

            LoadCurrentPosition();
            DisplayCurrentLibraryGame();
        }
        #endregion

        #region Load Data
        private void LoadFirstLibraryGame()
        {
            DataTable firstLibraryGame = DataAccess.GetData("SELECT TOP 1 GameId, PlatformId FROM Library_Games " +
                "ORDER BY GameID, PlatformId");

            if (firstLibraryGame.Rows.Count > 0)
            {
                DataRow firstRow = firstLibraryGame.Rows[0];
                currentGameId = Convert.ToInt32(firstRow["GameId"]);
                currentPlatformId = Convert.ToInt32(firstRow["PlatformId"]);

                LoadCurrentPosition();
                DisplayCurrentLibraryGame();
            }
        }
        private void LoadGames()
        {
            string sql = "SELECT GameId, Title FROM Game ORDER BY Title";
            DataTable dtGames = DataAccess.GetData(sql);

            cmbGame.Bind("Title", "GameId", dtGames);
        }

        private void LoadPlatforms()
        {
            string sql = "SELECT PlatformId , PlatformName FROM Platform ORDER BY PlatformName";
            DataTable dtPlatforms = DataAccess.GetData(sql);

            cmbPlatforms.Bind("PlatformName", "PlatformID", dtPlatforms);
        }

        private void LoadCurrentPosition()
        {
            DataTable dt = GetLibraryGameDataTable();
            LoadCurrentPosition(dt.Rows[0]);
            EnableNavigation(currentState == FormState.View);
        }

        private void LoadCurrentPosition(DataRow dataRow)
        {
            firstGameId = Convert.ToInt32(dataRow["FirstGameId"]);
            firstPlatformId = Convert.ToInt32(dataRow["FirstPlatformId"]);

            previousGameId = DataAccess.GetInteger(dataRow, "PreviousGameId");
            previousPlatformId = dataRow.GetInteger("PreviousPlatformId");

            nextGameId = dataRow.GetInteger("NextGameId");
            nextPlatformId = dataRow.GetInteger("NextPlatformId");

            lastGameId = Convert.ToInt32(dataRow["LastGameId"]);
            lastPlatformId = Convert.ToInt32(dataRow["LastPlatformId"]);
        }

        private DataTable GetLibraryGameDataTable()
        {
            string sql = $@"SELECT
                GameId,
                PlatformId,
                q.NextGameId,
                q.NextPlatformId,
                q.PreviousGameId,
                q.PreviousPlatformId,
                q.RowNumber,
                (SELECT TOP 1 GameId FROM Library_Games ORDER BY GameId, PlatformId) AS FirstGameId,
                (SELECT TOP 1 PlatformId FROM Library_Games ORDER BY GameId, PlatformId) AS FirstPlatformId,
                (SELECT TOP 1 GameId FROM Library_Games ORDER BY GameId DESC, PlatformId DESC) AS LastGameId,
                (SELECT TOP 1 PlatformId FROM Library_Games ORDER BY GameId DESC, PlatformId DESC) AS LastPlatformId
            FROM (
                SELECT 
                    GameId, 
                    PlatformId,
                    LEAD(GameId) OVER (ORDER BY GameId, PlatformId) AS NextGameId,
                    LEAD(PlatformId) OVER (ORDER BY GameId, PlatformId) AS NextPlatformId,
                    LAG(GameId) OVER (ORDER BY GameId, PlatformId) AS PreviousGameId,
                    LAG(PlatformId) OVER (ORDER BY GameId, PlatformId) AS PreviousPlatformId,
                    ROW_NUMBER() OVER (ORDER BY GameId, PlatformId) AS RowNumber
                FROM Library_Games
            ) AS q
        WHERE q.GameId = {currentGameId} AND q.PlatformID = {currentPlatformId}";

            DataTable dt = DataAccess.GetData(sql);
            return dt;
        }
        #endregion

        #region Display Data
        private void DisplayCurrentLibraryGame()
        {
            DataTable dtLibraryGame = GetLibraryGameData();

            if (dtLibraryGame.Rows.Count == 1)
            {
                DisplayCurrentLibraryGame(dtLibraryGame.Rows[0]);
            }
        }

        private void DisplayCurrentLibraryGame(DataRow dataRow)
        {
            int PlatformId = Convert.ToInt32(dataRow["PlatformId"]);

            cmbGame.SelectedValue = dataRow["GameId"];
            cmbPlatforms.SelectedValue = PlatformId;

        }

        private DataTable GetLibraryGameData()
        {
            string sql = $"SELECT * FROM Library_Games WHERE GameId = {currentGameId} AND PlatformId = {currentPlatformId}";
            DataTable dt = DataAccess.GetData(sql);
            return dt;
        }

        #endregion

        #region Button Management
        private void EnableNavigation(bool enable)
        {
            if (enable)
            {
                btnPrevious.Enabled = previousGameId != null
                    && previousPlatformId != null;

                btnNext.Enabled = nextGameId != null && nextPlatformId != null;
            }
            else
            {
                btnPrevious.Enabled = false;
                btnNext.Enabled = false;
            }

            btnFirst.Enabled = enable;
            btnLast.Enabled = enable;
        }
        #endregion

        #region Action Methods

        private void CreateLibraryGame()
        {
            int gameId = Convert.ToInt32(cmbGame.SelectedValue);
            int platformId = Convert.ToInt32(cmbPlatforms.SelectedValue);

            string sql = $@"INSERT INTO Library_Games(GameID , PlatformID)
                          VALUES
                            ({gameId}, {platformId})";

            int rowsAffected = DataAccess.SendData(sql);

            if (rowsAffected == 1)
            {
                MessageBox.Show("Library Game created sucessfully");
            }
            else
            {
                MessageBox.Show("Failed to create");
            }
        }

        private void DeleteLibraryGame()
        {
            string sql = $@"DELETE FROM Library_Games WHERE GameId = {currentGameId} AND PlatformID = {currentPlatformId}";

            int rowsAffected = DataAccess.SendData(sql);

            if (rowsAffected == 1)
            {
                MessageBox.Show("Library Game was deleted");
            }
            else
            {
                MessageBox.Show("No rows affected");
            }
        }

        #endregion

        #region Make it easy Methods
        private void DisplayCatchMessage(Exception ex)
        {
            MessageBox.Show(ex.Message, ex.GetType().ToString());
        }
        #endregion

    }
}
