using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RitramaAPP
{
    public class ClassProduct
    {
        public string Prodct_ID { get; set; }
        public string ProductName { get; set; }
        public string Descripcion { get; set; }
        public string Codebar { get; set; }
        public string Referencia { get; set; }
        public string Categoria { get; set; }
        public Boolean MasterRolls { get; set; }
        public Boolean Resmas { get; set; }
        public Boolean Graphics { get; set; }
        public Boolean Anulado { get; set; }
        public double Precio { get; set; }
    }
}
