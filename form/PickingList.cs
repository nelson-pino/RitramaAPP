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
        public IEnumerable<Producto> List_products { get; set; }

        
        readonly ProduccionManager produccionManager = new ProduccionManager();

        private void PickingList_Load(object sender, EventArgs e)
        {
            Lista_rollos = new List<Roll_Details>();
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

            CALCULATE_DATA();

            grid_productos.DataSource = List_products.ToList();

            
            REGISTROS_TOTALES.Text = "Numero de Registros : "+Lista_rollos.Count.ToString();

        }
        private void CALCULATE_DATA() 
        {
            List_products = from line in Lista_rollos
                            group line by new { line.Product_id, line.Width, line.Large } into g
                            select new Producto
                            {
                                Product_id = g.First().Product_id,
                                Product_name = g.First().Product_name,
                                Product_quantity = g.Count().ToString(),
                                width = g.First().Width,
                                lenght = g.First().Large,
                                msi = g.First().Msi
                            };

            grid_productos.DataSource = List_products.ToList();
        }
        private void AplicarEstiloGrid() 
        {
            grid_itemRC.AutoGenerateColumns = false;
            AGREGAR_COLUMN_GRID("unique_code",60,"Codigo Unico","unique_code",grid_itemRC);
            AGREGAR_COLUMN_GRID("product_id", 60, "Product Id.", "product_id", grid_itemRC);
            AGREGAR_COLUMN_GRID("product_name", 180, "Nombre del Proudcto", "product_name", grid_itemRC);
            AGREGAR_COLUMN_GRID("roll_number", 40, "Roll number", "roll_number", grid_itemRC);
            AGREGAR_COLUMN_GRID("width", 50, "Width", "width", grid_itemRC);
            AGREGAR_COLUMN_GRID("large", 50, "Largo", "large", grid_itemRC);
            AGREGAR_COLUMN_GRID("msi", 50, "Msi", "msi", grid_itemRC);
            AGREGAR_COLUMN_GRID("splice", 60, "Splice", "splice", grid_itemRC);
            AGREGAR_COLUMN_GRID("roll_id", 60, "Roll Id.", "roll_id", grid_itemRC);
            AGREGAR_COLUMN_GRID("code_person", 60, "Codigo Perso.", "code_person", grid_itemRC);
            AGREGAR_COLUMN_GRID("status", 60, "Status Calidad", "status", grid_itemRC);
            grid_productos.AutoGenerateColumns = false;
            AGREGAR_COLUMN_GRID("product_id", 60, "Product_id", "product_id", grid_productos);
            AGREGAR_COLUMN_GRID("product_name", 200, "Nombre del Producto", "product_name", grid_productos);
            AGREGAR_COLUMN_GRID("cant", 60, "Cantida Rollos", "product_quantity", grid_productos);
            AGREGAR_COLUMN_GRID("width", 60, "Width", "width", grid_productos);
            AGREGAR_COLUMN_GRID("lenght", 60, "Lenght", "lenght", grid_productos);
            AGREGAR_COLUMN_GRID("msi", 60, "Msi", "msi", grid_productos);
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
            if (File.Exists(R.PATH_FILES.FILE_TXT_DATA_PICKING_DESPACHO))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(R.PATH_FILES.FILE_TXT_DATA_PICKING_DESPACHO))
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
       private void LoadRC() 
       {
            string prefix;
            if(txt_uniqueCode.Text.Length == 7)
            {
                prefix = "";
            }
            else 
            {
                prefix = "RC";
            }
            Roll_Details rollo = produccionManager.GetDataUniqueCode(prefix + txt_uniqueCode.Text.Trim());
            //verificar valores vacios.
            if (rollo.Unique_code == "" || rollo.Unique_code == null) return;
            //verificar valores repetidos
            foreach (Roll_Details item in Lista_rollos)
            {
                if (item.Unique_code.Equals(prefix + txt_uniqueCode.Text.Trim()))
                {
                    MessageBox.Show("esta repetido");
                    txt_uniqueCode.Text = "";
                    return; 
                }
            }


            Lista_rollos.Add(rollo);
            grid_itemRC.DataSource = Lista_rollos.ToList();
            txt_uniqueCode.Text = "";
            REGISTROS_TOTALES.Text = "Numero de Registros : " + Lista_rollos.Count.ToString();
        }
        private void txt_uniqueCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (txt_uniqueCode.Text == string.Empty) 
                {
                    return;
                }
                LoadRC();
                CALCULATE_DATA();
            }
        }
    }
    public class Producto 
    {
        public string Product_id { get; set; }
        public string Product_name { get; set; }
        public string Product_quantity { get; set; }
        public decimal width { get; set; }
        public decimal lenght { get; set; }
        public decimal msi { get; set; }

    }
}
