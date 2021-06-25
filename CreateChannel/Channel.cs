using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateChannel
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Channel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string field1 { get; set; }
        public string field2 { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int last_entry_id { get; set; }
    }

    public class Feed
    {
        public DateTime created_at { get; set; }
        public int entry_id { get; set; }
        public double field1 { get; set; }
        public long field2 { get; set; }
        public override bool Equals (object obj)
        {
            return this.entry_id == ((Feed) obj).entry_id && this.entry_id == ((Feed) obj).entry_id;
        }
        public override int GetHashCode ()
        {
            //Get the ID hash code value
            return this.entry_id.GetHashCode ();
        }
    }

    public class Root
    {
        public Channel channel { get; set; }
        public List<Feed> feeds { get; set; }
    }
}
