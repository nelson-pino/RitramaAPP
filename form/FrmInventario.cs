using System;
using System.Windows.Forms;

namespace RitramaAPP
{
    public partial class FrmInventario : Form
    {
        public FrmInventario()
        {
            InitializeComponent();
        }
        private void FrmInventario_Load(object sender, EventArgs e)
        {
            grid_iniciales.AutoGenerateColumns = false;
            AGREGAR_COLUMN_GRID("product_id",60,"Product Id.","product_id",grid_iniciales);
            AGREGAR_COLUMN_GRID("product_name", 200, "Nombre del Producto", "product_name", grid_iniciales);
            AGREGAR_COLUMN_GRID("product_type", 60, "Tipo", "", grid_iniciales);
            AGREGAR_COLUMN_GRID("cantidad", 60, "Cantidad Inicial", "cantidad", grid_iniciales);
            AGREGAR_COLUMN_GRID("width", 50, "Width", "width", grid_iniciales);
            AGREGAR_COLUMN_GRID("large", 50, "Large", "large", grid_iniciales);
            AGREGAR_COLUMN_GRID("core", 50, "Core", "core", grid_iniciales);
            AGREGAR_COLUMN_GRID("ubicacion", 50, "Ubicacion", "ubicacion", grid_iniciales);
            AGREGAR_COLUMN_GRID("numero_id", 50, "RC/Roll Id", "numero_id", grid_iniciales);

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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
