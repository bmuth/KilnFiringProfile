using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace KilnFiringProfileMD
{
    public partial class frmKilnFiringProfileMD : Form
    {
        private bool bSettingWidthsToBeSaved = false;
        private System.Collections.Specialized.StringCollection ColumnWidths;
        private MySqlConnection m_con = null;

        public frmKilnFiringProfileMD ()
        {
            InitializeComponent ();

            AdjustWidths ();

            var builder = new MySqlConnectionStringBuilder
            {
                Server = "192.168.1.4",
                Port = 3306,
                UserID = "root",
                Password = "red",
                Database = "Kiln"
            };

            // open a connection asynchronously
            m_con = new MySqlConnection (builder.ConnectionString);
            m_con.Open ();
        }
        private void frmKilnFiringProfileMD_FormClosing (object sender, FormClosingEventArgs e)
        {
            if (bSettingWidthsToBeSaved)
            {
                Properties.Settings.Default.ColumnWidths = ColumnWidths;
                Properties.Settings.Default.Save ();
            }
        }

        /*****************************************************
         * 
         * Adjust Widths
         * 
         * ***************************************************/

        private void AdjustWidths ()
        {
            ColumnWidths = Properties.Settings.Default.ColumnWidths;

            for (int i = 0; i < dgvKilnFiring.Columns.Count; i++)
            {
                int col_width;
                if (i < ColumnWidths.Count)
                {
                    if (int.TryParse (ColumnWidths[i], out col_width))
                    {
                        dgvKilnFiring.Columns[i].Width = col_width;
                    }
                }
            }
        }

        private void dgvKilnFiring_ColumnWidthChanged (object sender, DataGridViewColumnEventArgs e)
        {
            if (bSettingWidthsToBeSaved)
            {
                ColumnWidths = new System.Collections.Specialized.StringCollection ();

                for (int i = 0; i < dgvKilnFiring.Columns.Count; i++)
                {
                    ColumnWidths.Add (dgvKilnFiring.Columns[i].Width.ToString ());
                }
            }
        }

        public int ExecuteNonQuery (string sql)
        {
            try
            {
                int affected;
                MySqlTransaction mytransaction = m_con.BeginTransaction ();
                MySqlCommand cmd = m_con.CreateCommand ();
                cmd.CommandText = sql;
                affected = cmd.ExecuteNonQuery ();
                mytransaction.Commit ();
                return affected;
            }
            catch (Exception ex)
            {
                MessageBox.Show (ex.Message);
            }
            return -1;
        }

        public DataSet ExecuteDataSet (string sql)
        {
            try
            {
                DataSet ds = new DataSet ();
                MySqlDataAdapter da = new MySqlDataAdapter (sql, m_con);
                da.Fill (ds, "result");
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show (ex.Message);
            }
            return null;
        }
        private void frmKilnFiringProfileMD_Shown (object sender, EventArgs e)
        {
            bSettingWidthsToBeSaved = true; // can save now

            /*          Load data
             *          --------- */

            var ds = ExecuteDataSet ("SELECT * from FiringRun;");

            if (ds != null)
            {
                dgvKilnFiring.DataSource = ds;
            }
        }
    }
}
