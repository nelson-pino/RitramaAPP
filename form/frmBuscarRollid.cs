using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RitramaAPP.form
{
    public partial class FrmBuscarRollid : Form
    {
        public FrmBuscarRollid()
        {
            InitializeComponent();
        }
        public DataTable Dtrollid { get; set; }
        DataView dv = new DataView();
        private void FrmBuscarRollid_Load(object sender, EventArgs e)
        {
            dv = Dtrollid.DefaultView;
            Grid_Items.AutoGenerateColumns = false;
            AplicarEstilosGrid();
            Grid_Items.DataSource = Dtrollid;
            CONTADOR_REGISTRO.Text = Convert.ToString(dv.Count) + " registros encontrados.";
        }
        private void AplicarEstilosGrid() 
        {
            AGREGAR_COLUMN_GRID("rollid",80,"Roll Id", "Roll_Id");
            AGREGAR_COLUMN_GRID("product_id", 80, "Product Id", "part_number");
            AGREGAR_COLUMN_GRID("product_name", 270, "Nombre del Producto", "product_name");
        }
        private void AGREGAR_COLUMN_GRID(string name, int size, string title, string field_bd)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn
            {
                Name = name,
                Width = size,
                HeaderText = title,
                DataPropertyName = field_bd
            };
            Grid_Items.Columns.Add(col);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (RAD_ROLLID.Checked)
            {
                dv.RowFilter = "Roll_Id LIKE '%" + this.TXT_BUSCAR.Text + "%'";
            }
            if (RAD_NOMBRE_PRODUCTO.Checked)
            {
                dv.RowFilter = "Product_Name LIKE '%" + this.TXT_BUSCAR.Text + "%'";
            }
            CONTADOR_REGISTRO.Text = Convert.ToString(dv.Count) + " registros encontrados.";
        }
    }
}
