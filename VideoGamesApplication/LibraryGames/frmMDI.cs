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
    public partial class frmMDI : Form
    {
        private int childFormNumber = 0;

        public frmMDI()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form? childForm = null;

            ToolStripItem? item = sender as ToolStripItem;

            if (item == null)
                return;

            switch (item.Tag)
            {
                case "Platforms":
                    childForm = new frmPlatforms();
                    break;
                case "Games":
                    childForm = new frmGames();
                    break;
                case "brwsGames":
                    childForm = new frmBrowseGames();
                    break;
                case "brwsePlats":
                    childForm = new frmBrowsePlatforms();
                    break;
                case "buy":
                    childForm = new frmBuy();
                    break;
            }

            if (childForm != null)
            {

                foreach (Form form in this.MdiChildren)
                {
                    if (form.GetType() == childForm.GetType())
                    {
                        form.Activate();
                        return;
                    }
                }

                childForm.MdiParent = this;
                childForm.Show();
            }
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void frmMDIParent_Load(object sender, EventArgs e)
        {
            frmSplash splash = new frmSplash();
            frmLogin login = new frmLogin();

            splash.ShowDialog();

            if (splash.DialogResult != DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                login.ShowDialog();
            }

            if (login.DialogResult != DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                this.Show();
            }
        }
    }
}
