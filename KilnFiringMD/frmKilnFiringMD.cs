using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MySqlConnector;

namespace KilnFiringMD
{
    public partial class frmKilnFiringMD : Form
    {
        private MySqlConnection m_con = null;
        private bool bSettingWidthsToBeSaved = false;
        private System.Collections.Specialized.StringCollection ColumnWidths;
        private bool m_bEditingEnabled = false;
        private string m_ConnectionString;
        private bool m_DirtyPicture = false;
        private int m_CurrentPic = -1;

        public frmKilnFiringMD ()
        {
            InitializeComponent ();

            AdjustWidths ();

            m_ConnectionString = new MySqlConnectionStringBuilder
            {
                Server = "192.168.1.4",
                Port = 3306,
                UserID = "root",
                Password = "red",
                Database = "Kiln"
            }.ToString ();
        }

        private void frmKilnFiringMD_FormClosing (object sender, FormClosingEventArgs e)
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

            for (int i = 0; i < dgvFiring.Columns.Count; i++)
            {
                int col_width;
                if (i < ColumnWidths.Count)
                {
                    if (int.TryParse (ColumnWidths[i], out col_width))
                    {
                        dgvFiring.Columns[i].Width = col_width;
                    }
                }
            }
        }

        private void dgvFiring_ColumnWidthChanged (object sender, DataGridViewColumnEventArgs e)
        {
            if (bSettingWidthsToBeSaved)
            {
                ColumnWidths = new System.Collections.Specialized.StringCollection ();

                for (int i = 0; i < dgvFiring.Columns.Count; i++)
                {
                    ColumnWidths.Add (dgvFiring.Columns[i].Width.ToString ());
                }
            }
        }

        public int ExecuteNonQuery (string sql)
        {
            try
            {
                int affected;
                //MySqlTransaction mytransaction = m_con.BeginTransaction ();
                MySqlCommand cmd = m_con.CreateCommand ();
                cmd.CommandText = sql;
                affected = cmd.ExecuteNonQuery ();
                //mytransaction.Commit ();
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
                using (var con = new MySqlConnection (m_ConnectionString))
                {
                    con.Open ();

                    DataSet ds = new DataSet ();
                    MySqlDataAdapter da = new MySqlDataAdapter (sql, con);
                    da.Fill (ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show (ex.Message);
            }
            return null;
        }
        private void frmKilnFiringMD_Shown (object sender, EventArgs e)
        {
            pbPic.SizeMode = PictureBoxSizeMode.CenterImage;

            bSettingWidthsToBeSaved = true; // can save now
            dgvFiring.Columns[2].DefaultCellStyle.Format = "yyyy-MMM-dd HH:mm:ss";

            /*          Load data
             *          --------- */

            var ds = ExecuteDataSet ("SELECT id,title,started_at,description from FiringRun");

            if (ds != null)
            {
                dgvFiring.DataSource = ds.Tables[0];
                dgvFiring.Show ();
                m_bEditingEnabled = true;
            }
        }

        private async void dgvFiring_CellValueChanged (object sender, DataGridViewCellEventArgs e)
        {
            if (m_bEditingEnabled)
            {
                if (e.ColumnIndex == 1)
                {
                    await SaveTitle (e.RowIndex);
                }
                if (e.ColumnIndex == 3)
                {
                    await SaveDescription (e.RowIndex);
                }
            }
            Debug.Print (string.Format ("CellValueChanged"));
        }

        private async Task SaveTitle (int row)
        {
            using (var con = new MySqlConnection (m_ConnectionString))
            {
                con.Open ();
                MySqlCommand cmd = new MySqlCommand (); 
                StringBuilder sb = new StringBuilder ("UPDATE FiringRun SET title = '");
                sb.Append (dgvFiring.Rows[row].Cells[1].Value.ToString ());
                sb.Append ("' WHERE id=");
                sb.Append (dgvFiring.Rows[row].Cells[0].Value.ToString ());

                cmd.CommandText = sb.ToString ();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                await cmd.ExecuteNonQueryAsync ();
            }
        }
        private async Task SaveDescription (int row)
        {
            using (var con = new MySqlConnection (m_ConnectionString))
            {
                con.Open ();
                MySqlCommand cmd = new MySqlCommand ();
                StringBuilder sb = new StringBuilder ("UPDATE FiringRun SET description = '");

                StringBuilder sb1 = new StringBuilder ();
                foreach (var c in dgvFiring.Rows[row].Cells[3].Value.ToString ())
                {
                    sb1.Append (c);
                    if (c == '\'')
                    {
                        sb1.Append (c);
                    }
                }
                
                sb.Append (sb1.ToString ());
                sb.Append ("' WHERE id=");
                sb.Append (dgvFiring.Rows[row].Cells[0].Value.ToString ());

                cmd.CommandText = sb.ToString ();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                await cmd.ExecuteNonQueryAsync ();
            }
        }

        private void DisplayPicture (int id)
        {
            string query = "SELECT pic FROM FiringRun WHERE id=" + id.ToString ();
            using (var con = new MySqlConnection (m_ConnectionString))
            {
                con.Open ();

                if (m_CurrentPic != id)
                {
                    using (MySqlCommand cmd = new MySqlCommand (query, con))
                    {
                        using (MySqlDataReader r = cmd.ExecuteReader ())
                        {

                            Byte[] image = null;
                            if (r.Read ()) // advance to next (first) record
                            {
                                if (r["pic"] != System.DBNull.Value)
                                {
                                    image = (Byte[]) (r["pic"]);
                                }
                            }

                            if (image != null)
                            {
                                MemoryStream ms = new MemoryStream ();
                                ms.Write (image, 0, image.Length);
                                pbPic.Image = System.Drawing.Image.FromStream (ms, false, true);

                            }
                            else
                            {
                                pbPic.Image = null;
                            }
                        }
                    }
                    m_CurrentPic = id;
                }
            }
        }

        private void DisplayKilnData (DateTime start, string description, int id)
        {
            StringBuilder sql = new StringBuilder ("SELECT temp, time From DataPoint WHERE fid=");
            sql.Append (id.ToString ());

            var ds = ExecuteDataSet (sql.ToString ());

            TempChart.Series.Clear ();
            TempChart.Series.Add (new Series ("Temperature"));
            TempChart.Series["Temperature"].ChartType = SeriesChartType.Line;

            TempChart.Titles.Clear ();
            foreach (DataRow k in ds.Tables[0].Rows)
            {
                TimeSpan ts = ((DateTime) k[1]) - start;

                TempChart.Series["Temperature"].Points.AddXY (ts.TotalHours, k[0]);
            }

            TempChart.ChartAreas[0].AxisY.Title = "Temperature (Farenheit)";
            TempChart.ChartAreas[0].AxisX.Title = "Hours";

            if (!String.IsNullOrEmpty (description))
            {
                Title title = new Title (description, Docking.Top, new Font ("Century Gothic", 20, FontStyle.Bold), Color.DarkSlateBlue);
                TempChart.Titles.Add (title);
            }
            TempChart.ChartAreas[0].AxisX.RoundAxisValues ();
        }

        private void dgvFiring_RowStateChanged (object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged == DataGridViewElementStates.Selected)
            {
                DisplayKilnData ((DateTime) e.Row.Cells[2].Value, (string) e.Row.Cells[3].Value, (int) e.Row.Cells[0].Value);
                DisplayPicture ((int) e.Row.Cells[0].Value);

            }
        }

        private void dgvFiring_UserDeletingRow (object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show ("Confirm deleting " + e.Row.Cells[1].Value.ToString () + "?", 
                "Confirm row deletion", 
                MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }
            else
            {
                using (var con = new MySqlConnection (m_ConnectionString))
                {
                    con.Open ();
                    MySqlCommand cmd = new MySqlCommand ();

                    StringBuilder sb = new StringBuilder ("DELETE FROM DataPoint WHERE fid = ");
                    sb.Append (e.Row.Cells[0].Value.ToString ());
                    cmd.CommandText = sb.ToString ();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery ();

                    sb = new StringBuilder ("DELETE FROM FiringRun WHERE id  = ");
                    sb.Append (e.Row.Cells[0].Value.ToString ());

                    cmd.CommandText = sb.ToString ();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery ();
                }
            }
        }

        private void TempChart_MouseClick (object sender, MouseEventArgs e)
        {
            //var r = TempChart.HitTest (e.X, e.Y);
            //if (r.ChartElementType == ChartElementType.DataPoint)
            //{

            //    DataPoint p = (DataPoint) r.Object;
            //    Debug.Print (string.Format ("{0} {1}", p.XValue, p.YValues[0]));

            //    var pt = new PointF ((float) TempChart.Series[0].Points[r.PointIndex].XValue, (float) TempChart.Series[0].Points[r.PointIndex].YValues[0]);
            //    CalloutAnnotation ca = new CalloutAnnotation ();
            //    ca.AnchorDataPoint = TempChart.Series[0].Points[r.PointIndex];
            //    ca.Text = pt.ToString ();
            //    ca.CalloutStyle = CalloutStyle.SimpleLine;
            //    ca.ForeColor = Color.Red;
            //    ca.Font = new Font ("Tahoma", 12, FontStyle.Bold);
            //    TempChart.Annotations[0] = ca;
            //    TempChart.Invalidate ();
            //}
        }

        private void TempChart_MouseMove (object sender, MouseEventArgs e)
        {
            var r = TempChart.HitTest (e.X, e.Y);
            if (r.ChartElementType == ChartElementType.DataPoint)
            {

                DataPoint p = (DataPoint) r.Object;

                var pt = new PointF ((float) TempChart.Series[0].Points[r.PointIndex].XValue, (float) TempChart.Series[0].Points[r.PointIndex].YValues[0]);
                CalloutAnnotation ca = new CalloutAnnotation ();
                ca.AnchorDataPoint = TempChart.Series[0].Points[r.PointIndex];
                StringBuilder sb = new StringBuilder (pt.X.ToString ("0.00"));
                sb.Append (" hrs, ");
                sb.Append (pt.Y.ToString ("0.0 "));
                sb.Append ("°F");
                ca.Text = sb.ToString ();
                ca.CalloutStyle = CalloutStyle.SimpleLine;
                ca.ForeColor = Color.DarkSlateBlue;
                ca.Font = new Font ("Tahoma", 12, FontStyle.Bold);
                TempChart.Annotations[0] = ca;
                TempChart.Invalidate ();
            }
        }

        private void frmKilnFiringMD_Load (object sender, EventArgs e)
        {
            TempChart.Annotations.Add (new CalloutAnnotation());
            pbPic.AllowDrop = true;
        }

        private void TempChart_MouseLeave (object sender, EventArgs e)
        {
            TempChart.Annotations[0] = new CalloutAnnotation ();
            TempChart.Invalidate ();
        }

        private void pbPic_DragEnter (object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent (DataFormats.Bitmap))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /***********************************************************************
         * Resize the image to the specified width and height.
         *
         *
         * <param name="image">The image to resize.</param>
         * <param name="width">The width to resize to.</param>
         * <param name="height">The height to resize to.</param>
         * <returns>The resized image.</returns>
         * 
         * *********************************************************************/

        public static Bitmap ResizeImage (Image image, int width, int height)
        {
            var destRect = new Rectangle (0, 0, width, height);
            var destImage = new Bitmap (width, height);

            destImage.SetResolution (image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage (destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes ())
                {
                    wrapMode.SetWrapMode (WrapMode.TileFlipXY);
                    graphics.DrawImage (image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
        private void pbPic_MouseClick (object sender, MouseEventArgs e)
        {
            if (Clipboard.ContainsImage ())
            {
                Image image = Clipboard.GetImage ();
                double x_shrink = (double) pbPic.ClientSize.Width / (double) image.Width;
                double y_shrink = (double) pbPic.ClientSize.Height / (double) image.Height;
                Bitmap b;
                if (y_shrink < x_shrink) 
                {
                    b = ResizeImage (image, (int) (image.Width * y_shrink), (int) (image.Height * y_shrink));
                }
                else
                {
                    b = ResizeImage (image, (int) (image.Width * x_shrink), (int) (image.Height * x_shrink));

                }
                pbPic.SizeMode = PictureBoxSizeMode.CenterImage;

                pbPic.Image = b;
                m_DirtyPicture = true;
            }
        }

        private async void dgvFiring_RowLeave (object sender, DataGridViewCellEventArgs e)
        {
            if (m_DirtyPicture)
            {
                var dr = MessageBox.Show ("Do you want to save the picture?", "Confirm save picture", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    using (MemoryStream ms = new MemoryStream ())
                    {
                        pbPic.Image.Save (ms, System.Drawing.Imaging.ImageFormat.Png);
                        byte[] img = ms.ToArray ();

                        using (var con = new MySqlConnection (m_ConnectionString))
                        {
                            con.Open ();

                            var cmd = new MySqlCommand ("UPDATE FiringRun SET pic = @pic WHERE id = @id", con);

                            cmd.Parameters.Add ("@id", MySqlDbType.Int32);
                            cmd.Parameters.Add ("@pic", MySqlDbType.MediumBlob);

                            cmd.Parameters["@id"].Value = dgvFiring.Rows[e.RowIndex].Cells[0].Value;
                            cmd.Parameters["@pic"].Value = img;

                            await cmd.ExecuteNonQueryAsync ();
                        }
                    }
                }
                m_DirtyPicture = false;
            }
        }
    }
}
