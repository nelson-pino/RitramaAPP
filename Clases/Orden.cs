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
        public int Total_rolls { get; set; }
        public string Roll_id { get; set; }

        public List<Orden_Items> items;
        public Boolean Anulada { get; set; }
        public int Status { get; set; }
    }
}
