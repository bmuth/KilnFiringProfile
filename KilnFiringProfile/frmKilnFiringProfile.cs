using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Serialization;
using CreateChannel;
using Newtonsoft.Json;


namespace KilnFiringProfile
{

    public partial class frmKilnFiringProfile : Form
    {
        private string UserID = "7ZOLSL6SNVAUZLMB";
        private System.Collections.Specialized.StringCollection ChannelColumnWidths;
        private bool bSettingWidthsToBeSaved = false;
        RootChannel Channels;
        Root KilnDataRoot;

        public frmKilnFiringProfile ()
        {   
            InitializeComponent ();
        }

        private static readonly HttpClient client = new HttpClient ();


        private class T
        {
            public double temp;
            public double hours;

            public T (double t, double h)
            {
                temp = t; hours = h;
            }
        }

        private async void Fetch (string ChannelID, string ReadKey)
        {
            string http = string.Format ("https://api.thingspeak.com/channels/{0}/feeds.json?api_key={1}&results=1000", ChannelID, ReadKey);
            var content = await client.GetStringAsync (http);
            KilnDataRoot = JsonConvert.DeserializeObject<Root> (content);
            int CountReturned = KilnDataRoot.feeds.Count;

            List<Feed> KilnData = KilnDataRoot.feeds;

            while (CountReturned >= 1000)
            {
                http = string.Format ("https://api.thingspeak.com/channels/{0}/feeds.json?api_key={1}&results=1000&end={2}", ChannelID, ReadKey, KilnData[0].created_at);
                content = await client.GetStringAsync (http);
                KilnDataRoot = JsonConvert.DeserializeObject<Root> (content);
                CountReturned = KilnDataRoot.feeds.Count;
                KilnDataRoot.feeds.AddRange (KilnData);
                KilnData = KilnDataRoot.feeds;
            }

            KilnData = KilnData.Distinct ().ToList ();
            KilnData.RemoveRange (0, 180);
            KilnData.RemoveAt (KilnData.Count - 1);

            //tbTitle.Text = "Firing " + KilnData[0].created_at.ToLongDateString ();
            //TempChart.Titles.Add (tbTitle.Text);

            TempChart.Series["Temperature"].ChartType = SeriesChartType.Line;

            foreach (var k in KilnData)
            {
                TempChart.Series["Temperature"].Points.AddXY (k.field2 / 3600.0, k.field1 * 9.0 / 5.0 + 32.0);
            }

            TempChart.ChartAreas[0].AxisY.Title = "Temperature (Farenheit)";
            TempChart.ChartAreas[0].AxisX.Title = "Hours";
        }

        /************************************************
         * 
         * AdjustWidths ()
         * 
         * *********************************************/
        private void AdjustWidths ()
        {
            ChannelColumnWidths = Properties.Settings.Default.ChannelColumnWidths;

            for (int i = 0; i < dgvChannel.Columns.Count; i++)
            {
                int col_width;
                if (i < ChannelColumnWidths.Count)
                {
                    if (int.TryParse (ChannelColumnWidths[i], out col_width))
                    {
                        dgvChannel.Columns[i].Width = col_width;
                    }
                }
            }
        }
        
        /**********************************************
        * 
        * Load () - get list of channels
        * 
        * *******************************************/

        private async void frmKilnFiringProfile_Load (object sender, EventArgs e)
        {
            string http = string.Format ("https://api.thingspeak.com/users/brianmuth/channels.json?api_key={0}", UserID);
            var content = await client.GetStringAsync (http);
            Channels = JsonConvert.DeserializeObject<RootChannel> (content);
            dgvChannel.AutoGenerateColumns = false;
            dgvChannel.DataSource = Channels.channels;

        }

        /************************************************
         * 
         * dgvChannel_ColumnWidthChanged
         * 
         * *********************************************/

        private void dgvChannel_ColumnWidthChanged (object sender, DataGridViewColumnEventArgs e)
        {
                if (bSettingWidthsToBeSaved)
                {
                    ChannelColumnWidths = new System.Collections.Specialized.StringCollection ();

                    for (int i = 0; i < dgvChannel.Columns.Count; i++)
                    {
                        ChannelColumnWidths.Add (dgvChannel.Columns[i].Width.ToString ());
                    }
                }
        }

        /**************************************************
         * 
         * Form Closing
         * 
         * ***********************************************/

        private void frmKilnFiringProfile_FormClosing (object sender, FormClosingEventArgs e)
        {
            if (bSettingWidthsToBeSaved)
            {
                Properties.Settings.Default.ChannelColumnWidths = ChannelColumnWidths;
                Properties.Settings.Default.Save ();
            }
        }

        /**************************************************
         * 
         * Form_Shown
         * 
         * ***********************************************/


        private void frmKilnFiringProfile_Shown (object sender, EventArgs e)
        {
            AdjustWidths ();
            bSettingWidthsToBeSaved = true; // can save now
        }

        private void dgvChannel_CellDoubleClick (object sender, DataGridViewCellEventArgs e)
        {
            /* find the read key for this channel
             * ---------------------------------- */

            string ReadKey = string.Empty;

            foreach (var key in Channels.channels[e.RowIndex].api_keys)
            {
                if (key.write_flag == false)
                {
                    ReadKey = key.api_key;
                }
            }
            Fetch (Channels.channels[e.RowIndex].id.ToString (), ReadKey);
        }

        /*********************************************************
         * 
         * btnSaveAs clicked
         * 
         * *****************************************************/

        private void btnSaveAs_Click (object sender, EventArgs e)
        {
            // Displays a SaveFileDialog so the user can save the Image
            // assigned to Button2.
            SaveFileDialog saveFileDialog1 = new SaveFileDialog ();
            saveFileDialog1.Filter = "JSON|*.json|XML|*.xml";
            saveFileDialog1.Title = "Save as JSON or XML File";
            saveFileDialog1.ShowDialog ();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.

                // Saves the Image in the appropriate ImageFormat based upon the
                // File type selected in the dialog box.
                // NOTE that the FilterIndex property is one-based.
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        //open file stream
                        using (StreamWriter sw = new StreamWriter (saveFileDialog1.OpenFile ()))
                        {
                            using (JsonWriter writer = new JsonTextWriter (sw))
                            {
                                JsonSerializer serializer = new JsonSerializer ();
                                //serialize object directly into file stream
                                serializer.Serialize (writer, KilnDataRoot);
                            }
                        }
                        break;

                    case 2:
                        XmlSerializer xs = new XmlSerializer (typeof (Root));

                        using (StreamWriter sw = new StreamWriter (saveFileDialog1.OpenFile ()))
                        {
                            xs.Serialize (sw, KilnDataRoot);
                        }
                        break;
                }
            }
        }
    }
}
