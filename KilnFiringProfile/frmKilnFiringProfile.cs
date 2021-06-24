using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

            DateTime dtStart = dtpFiringDate.Value.Date;
            string Start = dtStart.ToString ("yyyy'-'MM'-'dd'T'HH':'mm':'ss'Z'");

            string http = string.Format ("https://api.thingspeak.com/channels/{0}/feeds.json?api_key={1}&results=500&start={2}", ChannelID, ReadKey, Start);

            //var content = await client.GetStringAsync (http);

            //Root KilnData = JsonConvert.DeserializeObject<Root> (content);

            TempChart.Series["Temperature"].ChartType = SeriesChartType.Line;
            //var points = (from f in KilnData.feeds select new { temp = f.field1, hours = f.field2 / 3600.0 });

            List<T> p = new List<T> ();
            p.Add (new T (25, 15));
            p.Add (new T (27, 22));
            p.Add (new T (33, 27));

            foreach (var t in p)
            {
                TempChart.Series["Temperature"].Points.AddXY (t.temp, t.hours);
            }

            TempChart.ChartAreas[0].AxisY.Title = "Temperature (Celsius)";
            TempChart.ChartAreas[0].AxisX.Title = "Hours";
            // TempChart.Series["Temperature"].Points.DataBind (points, "temp", "hours", null);
        }
    }
}
