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

        private async void btnFetch_Click (object sender, EventArgs e)
        {

            DateTime dtStart = dtpFiringDate.Value.Date;
            string Start = dtStart.ToString ("yyyy'-'MM'-'dd'T'HH':'mm':'ss'Z'");

            string http = string.Format ("https://api.thingspeak.com/channels/{0}/feeds.json?api_key={1}&results=5&start={2}", ChannelID, ReadKey, Start);

            var content = await client.GetStringAsync (http);

            Root KilnData = JsonConvert.DeserializeObject<Root> (content);

            var temps = (from f in KilnData.feeds select f.field1).ToArray ();
        }
    }
}
