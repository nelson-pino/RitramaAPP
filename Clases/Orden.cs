using RitramaAPP.Clases;
using System;
using System.Collections.Generic;
namespace RitramaAPP
{
    public class Orden
    {
        public Orden()
        {

        }
        public string Numero { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Fecha_produccion { get; set; }
        public string Rollid_1 { get; set; }
        public decimal Width_1 { get; set; }
        public decimal Lenght_1 { get; set; }
        public string Rollid_2 { get; set; }
        public decimal Width_2 { get; set; }
        public decimal Lenght_2 { get; set; }
        public string Product_id { get; set; }
        public string Product_name { get; set; }
        public int Cant_cortados { get; set; }
        public decimal Widht_cortados { get; set; }
        public decimal Lenght_cortados { get; set; }
        public decimal Msi_cortados { get; set; }
        public Boolean Anulada { get; set; }
        public Boolean Procesado { get; set; }
        public int Status { get; set; }

        public List<Roll_Details> rollos;
    }
}
