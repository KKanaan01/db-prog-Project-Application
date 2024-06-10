using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryGames
{
    public static class UIUtilities
    {
        public static void Bind(this ListControl ctrl, string displayMember, string valueMember, DataTable dt)
        {
            ctrl.DisplayMember = displayMember;
            ctrl.ValueMember = valueMember;
            ctrl.DataSource = dt;
        }

        public static void AddEmptyRow(this DataTable dt, string columnName, string columnValue, object? emptyValue)
        {
            if (emptyValue is null)
                emptyValue = DBNull.Value;

            DataRow dr = dt.NewRow();
            dr[columnName] = "-- Please make a selection --";
            dr[columnValue] = emptyValue;
            dt.Rows.InsertAt(dr, 0);
        }

        public static void ClearControls(this Control.ControlCollection controlsCollection, int defaultSelectedIndex = 0)
        {
            foreach (Control control in controlsCollection)
            {
                switch (control)
                {
                    case TextBox textBox:
                        textBox.Text = string.Empty;
                        break;
                    case CheckBox checkBox:
                        checkBox.Checked = false;
                        break;
                    case ComboBox combo:
                        combo.SelectedIndex = defaultSelectedIndex;
                        break;
                    case ListBox listBox:
                        listBox.SelectedIndex = defaultSelectedIndex;
                        break;
                    case GroupBox groupBox:
                        ClearControls(groupBox.Controls);
                        break;
                    case Panel panel:
                        ClearControls(panel.Controls);
                        break;
                    case RadioButton rb:
                        rb.Checked = false;
                        break;
                }
            }
        }

        public static void DisplayParentStatusStripMessage(this Form form , string message)
        {
            DisplayParentStatusStripMessage(form, message, Color.Black);
        }

        public static void DisplayParentStatusStripMessage(this Form form , string message, Color color)
        {
            frmMDI? parentMdi = form.MdiParent as frmMDI;

            if (parentMdi != null)
            {
                parentMdi.DisplayStatusMessage(message, color);
            }
        }
    }
}
