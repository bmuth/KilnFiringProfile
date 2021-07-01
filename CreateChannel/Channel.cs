using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateChannel
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class ApiKey
    {
        public string api_key { get; set; }
        public bool write_flag { get; set; }
    }

    public class ChannelDef
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public DateTime created_at { get; set; }
        public string elevation { get; set; }
        public int? last_entry_id { get; set; }
        public bool public_flag { get; set; }
        public string url { get; set; }
        public int ranking { get; set; }
        public string metadata { get; set; }
        public int license_id { get; set; }
        public object github_url { get; set; }
        public List<object> tags { get; set; }
        public List<ApiKey> api_keys { get; set; }
    }

    public class RootChannel
    {
        public List<ChannelDef> channels { get; set; }
    }


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
        public string created_at { get; set; }
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

    public class FileKilnData
    {
        public FileKilnData (ChannelDef c, List<Feed> f)
        {
            channel = c;
            feeds = f;
        }
        public ChannelDef channel {get; set;}
        public List<Feed> feeds { get; set; }
    }
