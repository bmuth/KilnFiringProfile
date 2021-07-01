using CreateChannel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Serialization;


namespace KilnFiringProfile
{

    public partial class frmKilnFiringProfile : Form
    {
        private readonly string UserID = "7ZOLSL6SNVAUZLMB";
        private System.Collections.Specialized.StringCollection ChannelColumnWidths;
        private bool bSettingWidthsToBeSaved = false;
        private RootChannel Channels;
        private Root KilnDataRoot;
        private bool bEnableDescription = false;

        public frmKilnFiringProfile ()
        {   
            InitializeComponent ();
        }

        private static readonly HttpClient client = new HttpClient ();

        /**********************************************************************
         * 
         * Fetch - fetch the data and display as a chart
         * 
         * *******************************************************************/

        private async void Fetch (ChannelDef channel, string ReadKey)
        {
            string http = string.Format ("https://api.thingspeak.com/channels/{0}/feeds.json?api_key={1}&results=1000", channel.id.ToString (), ReadKey);
            var content = await client.GetStringAsync (http);
            KilnDataRoot = JsonConvert.DeserializeObject<Root> (content);
            int CountReturned = KilnDataRoot.feeds.Count;

            List<Feed> KilnData = KilnDataRoot.feeds;

            while (CountReturned >= 1000)
            {
                http = string.Format ("https://api.thingspeak.com/channels/{0}/feeds.json?api_key={1}&results=1000&end={2}", channel.id.ToString (), ReadKey, KilnData[0].created_at);
                content = await client.GetStringAsync (http);
                KilnDataRoot = JsonConvert.DeserializeObject<Root> (content);
                CountReturned = KilnDataRoot.feeds.Count;
                KilnDataRoot.feeds.AddRange (KilnData);
                KilnData = KilnDataRoot.feeds;
            }

            KilnData = KilnData.Distinct ().ToList ();
            KilnData.RemoveRange (0, 180);
            KilnData.RemoveAt (KilnData.Count - 1);

            DisplayKilnData ();
        }

        private void DisplayKilnData ()
        {
            TempChart.Series["Temperature"].ChartType = SeriesChartType.Line;

            foreach (var k in KilnDataRoot)
            {
                TempChart.Series["Temperature"].Points.AddXY (k.field2 / 3600.0, k.field1 * 9.0 / 5.0 + 32.0);
            }

            TempChart.ChartAreas[0].AxisY.Title = "Temperature (Farenheit)";
            TempChart.ChartAreas[0].AxisX.Title = "Hours";

            Title title = new Title (channel.description, Docking.Top, new Font ("Century Gothic", 20, FontStyle.Bold), Color.DarkSlateBlue);
            TempChart.Titles.Add (title);
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
            try
            {
                string http = string.Format ("https://api.thingspeak.com/users/brianmuth/channels.json?api_key={0}", UserID);
                var content = await client.GetStringAsync (http);
                Channels = JsonConvert.DeserializeObject<RootChannel> (content);
                dgvChannel.AutoGenerateColumns = false;
                dgvChannel.DataSource = Channels.channels;
            }
            catch (Exception ex)
            {
                MessageBox.Show (string.Format ("Failed to reach ThingSpeak.com. {0}", ex.Message));
            }

            this.Size = Properties.Settings.Default.FormSize;
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
                Properties.Settings.Default.FormSize = this.Size;
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
            if (e.ColumnIndex != 3)
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
                Fetch (Channels.channels[e.RowIndex], ReadKey);
                return;
            }
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

        private async void dgvChannel_CellValueChanged (object sender, DataGridViewCellEventArgs e)
        {
            if (bEnableDescription)
            {
                await SaveDescription (e.RowIndex); 
                bEnableDescription = false;
            }
            Debug.Print (string.Format ("CellValueChanged"));// {0}, {1}", dgvChannel[3, 0].Value.ToString (), Channels.channels[e.RowIndex].description));
        }

        private void dgvChannel_CellLeave (object sender, DataGridViewCellEventArgs e)
        {
            Debug.Print (string.Format ("CellLeave {0}, {1}", dgvChannel[3, 0].Value.ToString (), Channels.channels[e.RowIndex].description));

            bEnableDescription = true;
        }

        private async Task SaveDescription (int row)
        {
            /* find the write key for this channel
                * ---------------------------------- */

            string WriteKey = string.Empty;

            foreach (var key in Channels.channels[row].api_keys)
            {
                if (key.write_flag)
                {
                    WriteKey = key.api_key;
                    break;
                }
            }

            try
            {
                var kvp = new List<KeyValuePair<string, string>> ();
                kvp.Add (new KeyValuePair<string, string> ("api_key", UserID));
                kvp.Add (new KeyValuePair<string, string> ("description", dgvChannel[3, 0].Value.ToString ()));

                using (var httpClient = new HttpClient ())
                {
                    using (var content = new FormUrlEncodedContent (kvp))
                    {
                        content.Headers.Clear ();
                        content.Headers.Add ("Content-Type", "application/x-www-form-urlencoded");

                        string url = string.Format ("https://api.thingspeak.com/channels/{0}.json", Channels.channels[row].id);
                        HttpResponseMessage response = await httpClient.PutAsync (url, content);
                        if (!response.IsSuccessStatusCode)
                        {
                            MessageBox.Show (response.ReasonPhrase);
                            return;
                        }

                        //var httpResponse = await response.Content.ReadAsStringAsync ();
                        //if (httpResponse != null)
                        //{
                        //    MessageBox.Show (httpResponse);
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show (string.Format ("Failed to reach ThingSpeak.com. {0}", ex.Message));
            }
        }

        /*************************************************************
         * 
         * Print
         * 
         * **********************************************************/

        private void btnPrint_Click (object sender, EventArgs e)
        {
            TempChart.Printing.PageSetup ();
        }

        /****************************************************************
         * 
         * Form Size Changed
         * 
         * *************************************************************/

        private void frmKilnFiringProfile_SizeChanged (object sender, EventArgs e)
        {
            Debug.Print (this.Size.ToString ());
        }

        /***************************************************************
         * 
         * Open JSON file
         * 
         * ************************************************************/

        private void openToolStripMenuItem_Click (object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog ())
            {
                //openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "JSON files|*.json|XML files|*.xml";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog () == DialogResult.OK)
                {
                    switch (openFileDialog.FilterIndex)
                    {
                        case 1:
                            //Read the contents of the file into a stream
                            var fileStream = openFileDialog.OpenFile ();

                            using (StreamReader reader = new StreamReader (fileStream))
                            {
                                string fileContent = reader.ReadToEnd ();
                                KilnDataRoot = JsonConvert.DeserializeObject<Root> (fileContent);
                            }
                            break;
                        case 2:
                            XmlSerializer ser = new XmlSerializer (typeof (Root));

                            using (StreamReader sr = new StreamReader (openFileDialog.FileName))
                            {
                                KilnDataRoot = (Root) ser.Deserialize (sr);
                            }
                            break;
                    }
                }
            }
        }
    }
}

