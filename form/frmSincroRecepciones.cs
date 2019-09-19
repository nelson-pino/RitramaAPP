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
    public partial class frmSincroRecepciones : Form
    {
        public frmSincroRecepciones()
        {
            InitializeComponent();
        }
        public DataTable dtsupply { get; set; }
        public List<ClassRecepcion> lista { get; set; }
        int fila_actual = 0;
        private void FrmSincroRecepciones_Load(object sender, EventArgs e)
        {
            SetStyleGrid();
            grid_item.DataSource = lista;
            REGISTROS_TRANSFERIDOS.Text = "Registros transferidos :" + lista.Count().ToString();

        }
        private void SetStyleGrid()
        {
            grid_item.AutoGenerateColumns = false;
            CREATE_COLUMN_TEXTBOX_GRID("orden", 60, "Orden", "orden");
            CREATE_COLUMN_TEXTBOX_GRID("id_product", 75, "Codigo", "part_number");
            CREATE_COLUMN_TEXTBOX_GRID("product_name", 200, "Nombre del producto", "productname");
            CREATE_COLUMN_TEXTBOX_GRID("width", 100, "Width", "width");
            CREATE_COLUMN_TEXTBOX_GRID("lenght", 100, "Lenght", "lenght");
            CREATE_COLUMN_TEXTBOX_GRID("rollid", 120, "Roll Id.", "Roll_ID");
            CREATE_COLUMN_TEXTBOX_GRID("proveedor_id", 60, "Prov. Id", "Supply_Id");
            CREATE_COLUMN_TEXTBOX_GRID("proveedor_name", 200, "Nombre del Proveedor", "SupplyName");
        }
        public void CREATE_COLUMN_TEXTBOX_GRID(string name,int wid,string text,string campodb)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.Name =  name;
            col.Width = wid;
            col.HeaderText = text;
            col.DataPropertyName = campodb;
            grid_item.Columns.Add(col);
        }

        private void Bot_search_proveedor_Click(object sender, EventArgs e)
        {
            SeleccionProveedores BrowseProviders = new SeleccionProveedores
            {
                dtsupply = this.dtsupply
            };
            BrowseProviders.ShowDialog();
            txt_id_proveedor.Text = BrowseProviders.GetProviderID;
            txt_proveedor_name.Text = BrowseProviders.GetProviderName;
        }

        private void Bot_register_select_Click(object sender, EventArgs e)
        {
            grid_item.Rows[fila_actual].Cells["proveedor_id"].Value = txt_id_proveedor.Text;
            grid_item.Rows[fila_actual].Cells["proveedor_name"].Value = txt_proveedor_name.Text;
        }

        private void Grid_item_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fila_actual = e.RowIndex;
        }

        private void Bot_register_all_Click(object sender, EventArgs e)
        {
            for (int i=0; i<= grid_item.Rows.Count-1; i++)
            {
                if (Convert.ToString(grid_item.Rows[i].Cells["proveedor_id"].Value) == "")
                {
                    grid_item.Rows[i].Cells["proveedor_id"].Value = txt_id_proveedor.Text;
                    grid_item.Rows[i].Cells["proveedor_name"].Value = txt_proveedor_name.Text;
                }
            }
        }
    }
}
