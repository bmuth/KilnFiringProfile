using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using CreateChannel;
using Newtonsoft.Json;


namespace KilnFiringProfile
{

    public partial class frmKilnFiringProfile : Form
    {
        string ChannelID = "1410216";
        string ReadKey = "ITCEDQN7BSWMSTID";
        string UserID = "7ZOLSL6SNVAUZLMB";

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

        private async void btnFetch_Click (object sender, EventArgs e)
        {

 
            string http = string.Format ("https://api.thingspeak.com/channels/{0}/feeds.json?api_key={1}&results=1000", ChannelID, ReadKey);
            var content = await client.GetStringAsync (http);
            Root KilnDataRoot = JsonConvert.DeserializeObject<Root> (content);
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

        /**********************************************
         * 
         * Load () - get list of channels
         * 
         * *******************************************/

        private async void frmKilnFiringProfile_Load (object sender, EventArgs e)
        {
            string http = string.Format ("https://api.thingspeak.com/users/brianmuth/channels.json?api_key={0}", UserID);
            var content = await client.GetStringAsync (http);
            RootChannel Channels = JsonConvert.DeserializeObject<RootChannel> (content);

        }
    }
}
