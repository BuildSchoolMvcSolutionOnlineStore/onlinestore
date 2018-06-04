using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreData.Models
{
    public class Messages
    {
        public string OrderID { get; set; }
        public string Message { get; set; }
        public string Reply { get; set; }
        public DateTime Time { get; set; }
        public DateTime? ReplayTime { get; set; }
    }
}