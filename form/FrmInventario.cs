using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using RitramaAPP.Clases;

namespace RitramaAPP
{
    public partial class FrmInventario : Form
    {
        public FrmInventario()
        {
            InitializeComponent();
        }

        readonly ProductsManager productmanager = new ProductsManager();
        List<Item> items;
        readonly string pathfile = @"C:\Users\npino\Documents\RITRAMA\RitramaAPP\data\InventarioFisico.txt";
        
        private void FrmInventario_Load(object sender, EventArgs e)
        {
            grid_iniciales.AutoGenerateColumns = false;
            AGREGAR_COLUMN_GRID("product_id",60,"Product Id.","product_id",grid_iniciales);
            AGREGAR_COLUMN_GRID("product_name", 200, "Nombre del Producto", "product_name", grid_iniciales);
            AGREGAR_COLUMN_GRID("product_type", 60, "Tipo", "Tipo", grid_iniciales);
            AGREGAR_COLUMN_GRID("cantidad", 60, "Cantidad Inicial", "cantidad", grid_iniciales);
            AGREGAR_COLUMN_GRID("width", 50, "Width", "width", grid_iniciales);
            AGREGAR_COLUMN_GRID("lenght", 50, "Lenght", "lenght", grid_iniciales);
            AGREGAR_COLUMN_GRID("msi", 50, "Msi", "msi", grid_iniciales);
            AGREGAR_COLUMN_GRID("ubicacion", 50, "Ubicacion", "ubicacion", grid_iniciales);
            AGREGAR_COLUMN_GRID("numero_id", 65, "RC/Roll Id", "unique_code", grid_iniciales);
            CONTADOR_REGISTROS.Text = "Numero de Registros: 0";
        }
        private void AGREGAR_COLUMN_GRID(string name, int size, string title, string field_bd, DataGridView grid)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn
            {
                Name = name,
                Width = size,
                HeaderText = title,
                DataPropertyName = field_bd
            };
            grid.Columns.Add(col);
        }
        private void TabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Bot_sincro_Click(object sender, EventArgs e)
        {
            //extraer data del txt de inventario inicial
            items = new List<Item>();
            if (File.Exists(pathfile))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(pathfile))
                    {
                        while (sr.Peek() >= 0)
                        {
                                string str;
                                string[] strArray;
                                str = sr.ReadLine();
                                strArray = str.Split(',');
                                string tipo = strArray[0];
                                string product_id = strArray[1];
                              
                                Item elemento = new Item
                                {
                                    Product_id = strArray[1],
                                    Tipo = strArray[0]

                                };
                                if (tipo == "m" || tipo == "rc")
                                {
                                    elemento.Width = Convert.ToDecimal(strArray[2]);
                                    elemento.Lenght = Convert.ToDecimal(strArray[3]);
                                    elemento.Msi = Convert.ToDecimal(strArray[4]);
                                    elemento.Ubicacion = strArray[5];
                                    elemento.Unique_code = strArray[6];
                                    elemento.Cantidad = 1;
                                }
                                if (tipo == "g" || tipo == "r")
                                {
                                    elemento.Cantidad  = Convert.ToDecimal(strArray[2]);
                                    elemento.Ubicacion = strArray[3];
                                    elemento.Unique_code = "";
                                }
                                items.Add(elemento);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("no se encontro el archivo txt de inventario inicial" + ex);

                }
            }
            //buscar los nombre de los productos.
            foreach (Item elemento in items) 
            {
                elemento.Product_name = productmanager.GetProductName(elemento.Product_id);
                elemento.Tipo = productmanager.GetProductType(elemento.Product_id);
            }

            grid_iniciales.DataSource = items;
            CONTADOR_REGISTROS.Text = "Numero de Registros: "+items.Count.ToString();
            
        }
        private class Item 
        {
            public string Tipo { get; set; }
            public string Product_id { get; set; }
            public string Product_name { get; set; }
            public decimal Width { get; set; }
            public decimal Lenght { get; set; }
            public decimal Msi { get; set; }
            public string Ubicacion { get; set; }
            public string Unique_code { get; set; }
            public decimal Cantidad { get; set; }
        }
    }
}
