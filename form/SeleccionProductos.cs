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
    public partial class SeleccionProductos : Form
    {
        public SeleccionProductos()
        {
            InitializeComponent();
        }
        public DataTable dtproducto { get; set; }
        public string itemSelected { get; set; }
        public string GetProductId { get; set; }
        public string GetProductName { get; set; }
        public Boolean GetMasterRolls { get; set; }
        public Boolean GetResma { get; set; }
        public Boolean Getgraphics { get; set; }

        DataView dv = new DataView();
        private void SeleccionProductos_Load(object sender, EventArgs e)
        {
            dv = dtproducto.DefaultView;
            grid_productos.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.Name = "id_product";
            col1.Width = 75;
            col1.HeaderText = "Codigo";
            col1.DataPropertyName = "Product_ID";
            grid_productos.Columns.Add(col1);
            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.Name = "part_name";
            col2.Width = 390;
            col2.HeaderText = "Fecha";
            col2.DataPropertyName = "Product_Name";
            grid_productos.Columns.Add(col2);
            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.Name = "masterRolls";
            col3.Width = 60;
            col3.HeaderText = "Master";
            col3.DataPropertyName = "masterRolls";
            grid_productos.Columns.Add(col3);
            DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
            col4.Name = "resmas";
            col4.Width = 60;
            col4.HeaderText = "Resma";
            col4.DataPropertyName = "Resmas";
            grid_productos.Columns.Add(col4);
            DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn();
            col5.Name = "graphics";
            col5.Width = 60;
            col5.HeaderText = "Graphics";
            col5.DataPropertyName = "graphics";
            grid_productos.Columns.Add(col5);
            dv.RowFilter = "";
            grid_productos.DataSource = dv;
            lbl_contador_registros.Text = Convert.ToString(dv.Count) + " registros encontrados.";
        }
        private void Txt_buscar_TextChanged(object sender, EventArgs e)
        {
            if (rad_codigo.Checked)
            {
                dv.RowFilter = "Product_ID LIKE '%" + this.txt_buscar.Text + "%'";
            }
            if (rad_producto.Checked)
            {
                dv.RowFilter = "Product_Name LIKE '%" + this.txt_buscar.Text + "%'";
            }
            lbl_contador_registros.Text = Convert.ToString(dv.Count) + " registros encontrados.";
        }

        private void Grid_productos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            itemSelected = grid_productos.Rows[e.RowIndex].Cells[0].Value.ToString();
            GetProductId = grid_productos.Rows[e.RowIndex].Cells[0].Value.ToString();
            GetProductName = grid_productos.Rows[e.RowIndex].Cells[1].Value.ToString();
            GetMasterRolls = Convert.ToBoolean(grid_productos.Rows[e.RowIndex].Cells[2].Value);
            GetResma = Convert.ToBoolean(grid_productos.Rows[e.RowIndex].Cells[3].Value);
            Getgraphics = Convert.ToBoolean(grid_productos.Rows[e.RowIndex].Cells[4].Value);
            this.Close();
        }
    }
}
