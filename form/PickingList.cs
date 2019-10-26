using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RitramaAPP.Clases;
using System.IO;
using System.Linq;

namespace RitramaAPP.form
{
    public partial class PickingList : Form
    {
        public PickingList()
        {
            InitializeComponent();
        }
        public List<Roll_Details> Lista_rollos { get; set; }
        public IEnumerable<producto> list_products { get; set; }

        readonly string path = R.PATH_FILES.FILE_TXT_MATERIA_PRIMA;
        readonly ProduccionManager produccionManager = new ProduccionManager();

        private void PickingList_Load(object sender, EventArgs e)
        {
            AplicarEstiloGrid();
        }
        private void Bot_leer_Click(object sender, EventArgs e)
        {
            ExtraerDataAppMovil();
            //getdata de los unique code.
           foreach (Roll_Details item in Lista_rollos) 
           {
                Roll_Details rollo = produccionManager.GetDataUniqueCode(item.Unique_code);
                item.Product_id = rollo.Product_id;
                item.Product_name = rollo.Product_name;
                item.Roll_number = rollo.Roll_number;
                item.Width = rollo.Width;
                item.Large = rollo.Large;
                item.Msi = rollo.Msi;
                item.Splice = rollo.Splice;
                item.Roll_id = rollo.Roll_id;
                item.Code_Person = rollo.Code_Person;
                item.Status = rollo.Status;
            }
            grid_itemRC.DataSource = Lista_rollos;
            //linq que consolida los renglones del conduce.

            list_products = from line in Lista_rollos
                         group line by line.Product_id into g
                         select new producto
                         {
                             product_id = g.First().Product_id,
                             product_name = g.First().Product_name,
                             product_quantity = g.Count().ToString()
                         };

            grid_productos.DataSource = list_products.ToList();

            
            REGISTROS_TOTALES.Text = "Numero de Registros : "+Lista_rollos.Count.ToString();

        }
        private void AplicarEstiloGrid() 
        {
            grid_itemRC.AutoGenerateColumns = false;
            AGREGAR_COLUMN_GRID("unique_code",60,"Codigo Unico","unique_code",grid_itemRC);
            AGREGAR_COLUMN_GRID("product_id", 60, "Product Id.", "product_id", grid_itemRC);
            AGREGAR_COLUMN_GRID("product_name", 200, "Nombre del Proudcto", "product_name", grid_itemRC);
            AGREGAR_COLUMN_GRID("roll_number", 40, "Roll number", "roll_number", grid_itemRC);
            AGREGAR_COLUMN_GRID("width", 60, "Width", "width", grid_itemRC);
            AGREGAR_COLUMN_GRID("large", 60, "Largo", "large", grid_itemRC);
            AGREGAR_COLUMN_GRID("msi", 60, "Msi", "msi", grid_itemRC);
            AGREGAR_COLUMN_GRID("splice", 60, "Splice", "splice", grid_itemRC);
            AGREGAR_COLUMN_GRID("roll_id", 60, "Roll Id.", "roll_id", grid_itemRC);
            AGREGAR_COLUMN_GRID("code_person", 60, "Codigo Perso.", "code_person", grid_itemRC);
            AGREGAR_COLUMN_GRID("status", 60, "Status Calidad", "status", grid_itemRC);
            grid_productos.AutoGenerateColumns = false;
            AGREGAR_COLUMN_GRID("product_id", 60, "Product_id", "product_id", grid_productos);
            AGREGAR_COLUMN_GRID("product_name", 200, "Nombre del Producto", "product_name", grid_productos);
            AGREGAR_COLUMN_GRID("cant", 60, "Cantida Rollos", "product_quantity", grid_productos);
        }
        private void AGREGAR_COLUMN_GRID(string name, int size, string title, string field_bd,DataGridView grid)
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
        private void ExtraerDataAppMovil() 
        {
            //extraigo los unique code
            Lista_rollos = new List<Roll_Details>();
            if (File.Exists(path))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        while (sr.Peek() >= 0)
                        {
                            try
                            {
                                string str;
                                string[] strArray;
                                str = sr.ReadLine();
                                strArray = str.Split(',');
                                string unique = strArray[0];

                                Roll_Details rollo = new Roll_Details
                                {
                                    Unique_code = strArray[0],

                                };
                                Lista_rollos.Add(rollo);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("error al leer la data y convertir el archivo txt de despacho: " + ex);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error al tratar de crear el txt de despacho" + ex);

                }
            }
        }

        private void Bot_transferir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    public class producto 
    {
        public string product_id { get; set; }
        public string product_name { get; set; }

        public string product_quantity { get; set; }

    }
}
