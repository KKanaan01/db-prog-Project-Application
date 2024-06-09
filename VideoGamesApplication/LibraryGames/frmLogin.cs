using System.Data;

namespace LibraryGames
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender , EventArgs e)
        {
            try
            {
                if (IsValidLogin())
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Login Failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }


        private bool IsValidLogin()
        {
            DataTable dtLogin = DataAccess.GetData("SELECT * FROM Login");

            string userName = Convert.ToString(dtLogin.Rows[0]["UserName"]); // Kenaan7
            string password = Convert.ToString(dtLogin.Rows[0]["Password"]); // Password

            return txtUserName.Text == userName && txtPassword.Text == password;
        }
    }
}
