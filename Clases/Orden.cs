using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RitramaAPP.Clases;
namespace RitramaAPP
{
    public class Orden
    {
        public string Numero { get; set; }
        public DateTime Fecha { get; set; }
        public string Pedido { get; set; }
        public int Total_rolls { get; set; }
        public string Customer_id { get; set; }
        public string Customer_Name { get; set; }
        public string Roll_id { get; set; }

        public List<Orden_Items> items;
        public Boolean anulada { get; set; }
        public int status { get; set; }
    }
}
