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
    public partial class frmPlatforms : Form
    {

        #region Private fields
        int currentId;
        private int firstId;
        private int lastId;
        private int? nextId;
        private int? previousId;
        private int? rowNumber;
        private FormState currentState;
        #endregion
        public frmPlatforms()
        {
            InitializeComponent();
        }

        #region Event Handlers
        private void frmPlatforms_Load(object sender, EventArgs e)
        {
            try
            {
                LoadFirstPlatform();
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
                        MessageBox.Show("Last Platform currently displayed");

                }
                else if (sender == btnPrevious)
                {
                    if (previousId != null)
                        currentId = previousId.Value;
                    else
                        MessageBox.Show("First Platform currently displayed");
                }
                else
                {
                    return;
                }

                LoadCurrentPosition();
                DisplayCurrentPlatform();
            }
            catch (Exception ex)
            {
                DisplayCatchMessage(ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetState(FormState.Add);
            txtPlatformID.ReadOnly = true;
            this.DisplayParentStatusStripMessage("Adding...");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.DisplayParentStatusStripMessage("Editing...");
                txtPlatformID.ReadOnly = true;

                if (currentState == FormState.View)
                {
                    SetState(FormState.Edit);
                }
                else
                {
                    if (ValidateChildren())
                    {
                        if (txtPlatformID.Text == string.Empty)
                        {
                            CreatePlatform();
                            LoadFirstPlatform();
                        }
                        else
                        {
                            UpdatePlatform();
                        }
                        SetState(FormState.View);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string platformId = txtPlatformID.Text;
                int assignments = Convert.ToInt32(DataAccess.GetValue($"SELECT COUNT(1) FROM Library_Games WHERE PlatformId = {platformId};"));

                if (assignments == 0)
                {
                    DeletePlatform();
                    LoadFirstPlatform() ;
                }
                else
                {
                    MessageBox.Show("This Platform could not be deleted because it is associated with a game in the database.");
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
            DisplayCurrentPlatform();
        }
        #endregion

        #region Loading Data
        private void LoadFirstPlatform()
        {
            currentId = GetFirstPlatform();
            LoadCurrentPosition();
            DisplayCurrentPlatform();

        }

        private int GetFirstPlatform()
        {
            string sql = $"SELECT TOP (1) PlatformId FROM Platform ORDER BY PlatformName";
            int id = Convert.ToInt32(DataAccess.GetValue(sql));

            return id;
        }

        private DataRow GetPlatformDataRow(int id)
        {
            string sql = $"SELECT * FROM Platform WHERE PlatformId = {id}";
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
            currentId = Convert.ToInt32(positionRow["PlatformId"]);
            firstId = Convert.ToInt32(positionRow["FirstPlatformId"]);
            lastId = Convert.ToInt32(positionRow["LastPlatformId"]);
            rowNumber = Convert.ToInt32(positionRow["RowNumber"]);

            nextId = positionRow["NextPlatformId"] != DBNull.Value ?
                Convert.ToInt32(positionRow["NextPlatformId"]) : null;

            previousId = positionRow["PreviousPlatformId"] != DBNull.Value ?
                Convert.ToInt32(positionRow["PreviousPlatformId"]) : null;
        }

        private DataRow GetPositionDataRow(int id)
        {
            string sql = $@"SELECT PlatformId,
(
	SELECT TOP 1 PlatformId AS FirstPlatformId FROM Platform ORDER BY PlatformName
) AS FirstPlatformId,
p.PreviousPlatformId,
p.NextPlatformId,
(
	SELECT TOP 1 PlatformId AS FirstPlatformId FROM Platform ORDER BY PlatformName DESC
) AS LastPlatformId,
p.RowNumber
FROM
(
	SELECT PlatformId , PlatformName,
	LEAD(PlatformId) OVER (ORDER BY PlatformName) AS NextPlatformId,
	LAG(PlatformId) OVER (ORDER BY PlatformName) AS PreviousPlatformId,
	 ROW_NUMBER() OVER(ORDER BY PlatformName) AS 'RowNumber'
	FROM Platform
) AS p
 WHERE p.PlatformId = {id}
ORDER BY PlatformName ASC";

            DataTable dt = DataAccess.GetData(sql);
            return dt.Rows[0];
        }

        #endregion

        #region Displaying Data
        private void DisplayCurrentPlatform()
        {
            DataRow currentRow = GetPlatformDataRow(currentId);
            DisplayPlatform(currentRow);
        }


        private void DisplayPlatform(DataRow selectedRow)
        {
            txtPlatformID.Text = selectedRow["PlatformID"].ToString();
            txtName.Text = selectedRow["PlatformName"].ToString();
            txtDate.Text = selectedRow["ReleaseDate"].ToString();
            txtManufacturer.Text = selectedRow["Manufacturer"].ToString();
            txtDesc.Text = selectedRow["Description"].ToString();
            txtPrice.Text = selectedRow["Price"].ToString();

            DisplayPosition();
        }
        #endregion

        #region FormState
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
                    UIUtilities.ClearControls(grpPlats.Controls);

                DisableNavigation();
            }
        }

        private void SetState(FormState state)
        {
            currentState = state;
            LoadState(state);
        }
        #endregion

        #region Button/Textboxes Management
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
            txtPlatformID.ReadOnly = readOnly;
            txtName.ReadOnly = readOnly;
            txtManufacturer.ReadOnly = readOnly;
            txtDate.ReadOnly = readOnly;
            txtPrice.ReadOnly = readOnly;
            txtDesc.ReadOnly = readOnly;
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

            if (sender == txtPrice)
            {
                if (!isNumeric(txt.Text))
                {
                    errMsg = $"{txt.Tag} must be a valid price";
                    e.Cancel = true;
                }
            }

            if(sender == txtDate)
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

        #region Make it easier methods
        private void DisplayCatchMessage(Exception ex)
        {
            MessageBox.Show(ex.Message, ex.GetType().ToString());
        }

        private void DisplayPosition()
        {
            DataTable dt = DataAccess.GetData("SELECT * FROM Platform");
            this.DisplayParentStatusStripMessage($"Loaded {rowNumber} out of {dt.Rows.Count} Platforms");
        }


        #endregion

        #region Action Methods

        private void CreatePlatform()
        {
            string sqlEnterPlatform = $@"
                     INSERT INTO Platform
                     (
                        PlatformName,
                        ReleaseDate,
                        Manufacturer,
                        Description,
                        Price)
                     VALUES
                     (
                        '{DataAccess.SQLFix(txtName.Text.Trim())}'
                        ,'{txtDate.Text.Trim()}'
                        ,'{DataAccess.SQLFix(txtManufacturer.Text.Trim())}'
                        ,'{DataAccess.SQLFix(txtDesc.Text.Trim())}'
                        ,'{txtPrice.Text}'
                     )";

            int rowsAffected = DataAccess.SendData(sqlEnterPlatform);

            if (rowsAffected == 1)
            {
                MessageBox.Show("Platform has been added");
            }
            else
            {
                MessageBox.Show("Platform could not be created");
            }
        }

        private void DeletePlatform()
        {
            string sqlDelete = $"DELETE FROM Platform WHERE PlatformId = {txtPlatformID.Text}";

            int rowsAffected = DataAccess.SendData(sqlDelete);

            if (rowsAffected == 1)
            {
                MessageBox.Show("Platform has been deleted");
            }
            else
            {
                MessageBox.Show("No rows affected");
            }
        }

        public void UpdatePlatform()
        {
            string sql = $@"UPDATE [Platform]
                SET
                PlatformName = '{DataAccess.SQLFix(txtName.Text.Trim())}',
                ReleaseDate = '{txtDate.Text}',
                Manufacturer = '{DataAccess.SQLFix(txtManufacturer.Text)}',
                [Description] = '{DataAccess.SQLFix(txtDesc.Text)}',
                Price = '{txtPrice.Text}'
                WHERE PlatformID = '{txtPlatformID.Text}'";

            int rowsAffected = DataAccess.SendData(sql);

            if (rowsAffected == 0)
            {
                MessageBox.Show("No rows affected");
            }
            else if (rowsAffected == 1)
            {
                MessageBox.Show("Platform has been updated");
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }
        }
        #endregion
    }
}

