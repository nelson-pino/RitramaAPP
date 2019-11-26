using System;
using System.Data;
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
        public string GetrollId { get; set; }
        public string Getproduct_id { get; set; }
        public string GetProduct_name { get; set; }
        public string GetValueWidth { get; set; }
        public string GetvalueLenght { get; set; }
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
            AGREGAR_COLUMN_GRID("rollid", 62, "Roll Id", "Roll_Id");
            AGREGAR_COLUMN_GRID("product_id", 55, "Product Id", "part_number");
            AGREGAR_COLUMN_GRID("product_name", 250, "Nombre del Producto", "product_name");
            AGREGAR_COLUMN_GRID("width", 50, "Width", "width");
            AGREGAR_COLUMN_GRID("lenght", 50, "Lenght", "lenght");
            AGREGAR_COLUMN_GRID("fecha_pro", 67, "Fecha produccion", "fecha_pro");
            AGREGAR_COLUMN_GRID("fecha_doc", 67, "Fecha Recepcion", "fecha_recep");
            AGREGAR_COLUMN_GRID("splice", 40, "Splice", "splice");
            AGREGAR_COLUMN_GRID("ubicacion", 60, "Ubicacion", "ubicacion");
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

        private void Grid_Items_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            GetrollId = Grid_Items.Rows[e.RowIndex].Cells[0].Value.ToString();
            Getproduct_id = Grid_Items.Rows[e.RowIndex].Cells[1].Value.ToString();
            GetProduct_name = Grid_Items.Rows[e.RowIndex].Cells[2].Value.ToString();
            GetValueWidth = Grid_Items.Rows[e.RowIndex].Cells[3].Value.ToString();
            GetvalueLenght = Grid_Items.Rows[e.RowIndex].Cells[4].Value.ToString();
            this.Close();
        }
    }
}
