using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CreateChannel
{
    class Program
    {

        static string user_key = "7ZOLSL6SNVAUZLMB";
        static async Task Main (string[] args)
        {
            using var client = new HttpClient ();
            client.BaseAddress = new Uri ("https://api.thinkspeak.com");
            var content = new FormUrlEncodedContent (new[]
            {
                new KeyValuePair<string, string> ("api_key", user_key),
                new KeyValuePair<string, string> ("name", "Kiln " + DateTime.Now.ToString ("'yyyy'-'MM'-'dd' 'HH'"))
            });
            var result = await client.PostAsync ("/channels.json", content);
            string resultContent = await result.Content.ReadAsStringAsync ();
            Console.WriteLine (resultContent);
        }
    }
}