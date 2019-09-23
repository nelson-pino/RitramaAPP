﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RitramaAPP
{
    public class ClassRecepcion
    {
        public int Numero { get; set; }
        public string Supply_Id { get; set; }
        public DateTime Fecha_reg { get; set; }
        public string Hora_reg { get; set; }
        public string SupplyName { get; set; }
        public string Orden { get; set; }
        public decimal Width { get; set; }
        public decimal Lenght { get; set; }
        public int Splice { get; set; }
        public decimal Core { get; set; }
        public string Roll_ID { get; set; }
        public string Ubicacion { get; set; }
        public string Part_Number { get; set; }
        public string Unidad { get; set; }
        public string ProductName { get; set; }
        public Boolean Anulado { get; set; }
        public DateTime Fecha_produccion { get; set; }
        public Boolean Master { get; set; }
        public Boolean Resma { get; set; }
        public Boolean Graphics { get; set; }
        public string Embarque { get; set; }
        public string Palet_number { get; set; }
        public int Palet_cant { get; set; }
        public int Palet_paginas { get; set; }
        public string  Tipo { get; set; }
    }
}
