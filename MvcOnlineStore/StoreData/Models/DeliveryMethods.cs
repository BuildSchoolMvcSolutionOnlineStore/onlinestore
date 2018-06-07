using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Models
{
    public partial class DeliveryMethods
    {
        public int DeliveryMethodID { get; set; }
        public string DeliveryMethod { get; set; }
        public int Freight { get; set; }
    }
}
