using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KilnFiringProfileMD
{
    internal class FiringRun
    {
        public int id { get; set; }
        public string title { get; set; }
        public DateTime created_at { get; set; }
        public string description { get; set; }
    }
}
