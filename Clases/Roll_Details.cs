using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RitramaAPP.Clases
{
    public class Roll_Details
    {
        public DateTime Fecha { get; set; }
        public string Numero_Orden { get; set; }
        public string Roll_number { get; set; }
        public string Product_id { get; set; }
        public string Product_name { get; set; }
        public string Roll_id { get; set; }
        public decimal Width { get; set; }
        public decimal Large { get; set; }
        public decimal Msi { get; set; }
        public int Splice { get; set; }
        public string Code_Person { get; set; }
        public string Code_Unique { get; set; }
    }
}
