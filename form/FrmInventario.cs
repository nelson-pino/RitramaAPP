using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using RitramaAPP.Clases;
using System.Data;

namespace RitramaAPP
{
    public partial class FrmInventario : Form
    {
        public FrmInventario()
        {
            InitializeComponent();
        }
        readonly ProductsManager productmanager = new ProductsManager();
        readonly InventarioManager inimanager = new InventarioManager();
        List<Item> items;
        public IEnumerable<Item> ItemFilter { get; set; }
        DataView dvini = new DataView();
        DataView dvinventario = new DataView();
        DataTable dtinicial;
        DataTable dtinventario;
        
        private void FrmInventario_Load(object sender, EventArgs e)
        {
            dvini.RowFilter = "";
            AplicarEstilosGrid();
            dtinicial = inimanager.ToListIni();
            dvini = dtinicial.DefaultView;
            grid_iniciales.DataSource = dvini;
            CONTADOR_REGISTROS.Text = "Numero de Registros: " + Convert.ToString(dvini.Count);
            FormOptions();
        }
        private void FormOptions() 
        {
            if (dvini.Count > 0)
            {
                bot_sincro.Enabled = false;
            }
            else
            {
                bot_sincro.Enabled = true;
            }
        }
        private void Bot_sincro_Click(object sender, EventArgs e)
        {
            items = inimanager.GetDataIni();
            grid_iniciales.DataSource = items;
            CONTADOR_REGISTROS.Text = "Numero de Registros: "+items.Count.ToString();
            //buscar los nombre de los productos.
            foreach (Item elemento in items)
            {
                elemento.Product_name = productmanager.GetProductName(elemento.Product_id);
                elemento.Tipo = productmanager.GetProductType(elemento.Product_id);
            }
            inimanager.SaveDataIni(items); 
        }
        
        private void AplicarEstilosGrid() 
        {
            grid_iniciales.AutoGenerateColumns = false;
            AGREGAR_COLUMN_GRID("product_id", 60, "Product Id.", "product_id", grid_iniciales);
            AGREGAR_COLUMN_GRID("product_name", 200, "Nombre del Producto", "product_name", grid_iniciales);
            AGREGAR_COLUMN_GRID("product_type", 60, "Tipo", "tipo", grid_iniciales);
            AGREGAR_COLUMN_GRID("cantidad", 60, "Cantidad Inicial", "cantidad", grid_iniciales);
            AGREGAR_COLUMN_GRID("width", 50, "Width", "width", grid_iniciales);
            AGREGAR_COLUMN_GRID("lenght", 50, "Lenght", "lenght", grid_iniciales);
            AGREGAR_COLUMN_GRID("msi", 50, "Msi", "msi", grid_iniciales);
            AGREGAR_COLUMN_GRID("ubicacion", 50, "Ubicacion", "ubic", grid_iniciales);
            AGREGAR_COLUMN_GRID("numero_id", 65, "RC/Roll Id", "documento", grid_iniciales);
            //columnas de grid de inventario.
            AGREGAR_COLUMN_GRID("product_id", 60, "Product Id.", "product_id", grid_inventario);
            AGREGAR_COLUMN_GRID("product_name", 200, "Nombre del Producto", "product_name", grid_inventario);
            AGREGAR_COLUMN_GRID("product_type", 60, "Tipo", "tipo", grid_inventario);
            AGREGAR_COLUMN_GRID("cant_ini", 60, "Cantidad Inicial", "cant_ini", grid_inventario);
            AGREGAR_COLUMN_GRID("cant_ent", 60, "Entradas", "cant_ent", grid_inventario);
            AGREGAR_COLUMN_GRID("cant_sal", 60, "Salidas", "cant_sal", grid_inventario);
            AGREGAR_COLUMN_GRID("cant_final", 60, "Existencia", "cant_final", grid_inventario);
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

        private void Txt_buscar_TextChanged(object sender, EventArgs e)
        {
            if (RAD_PRODUCT_ID.Checked)
            {
                dvini.RowFilter = "product_id LIKE '%" + this.txt_buscar.Text + "%'";
            }
            if (RAD_PRODUCTNAME.Checked)
            {
                dvini.RowFilter = "product_name LIKE '%" + this.txt_buscar.Text + "%'";
            }
            if (RAD_TIPO.Checked)
            {
                dvini.RowFilter = "tipo LIKE '%" + this.txt_buscar.Text + "%'";
            }
            CONTADOR_REGISTROS.Text = "Numero de Registros: " + Convert.ToString(dvini.Count);
        }

        private void BOT_UPDATE_INVENTARIO_Click(object sender, EventArgs e)
        {
            dtinventario = inimanager.CargarInventario();
            dvinventario = dtinventario.DefaultView;
            grid_inventario.DataSource = dvinventario;
            //Calculo de la Columna de Existencia Final.
            for (int i = 0; i <= grid_inventario.Rows.Count-1; i++) 
            {
                grid_inventario.Rows[i].Cells["cant_final"].Value = Convert.ToDouble(grid_inventario.Rows[i].Cells["cant_ini"].Value) +
                    Convert.ToDouble(grid_inventario.Rows[i].Cells["cant_ent"].Value)-Convert.ToDouble(grid_inventario.Rows[i].Cells["cant_sal"].Value);
            }
            CONTA_REGISTER_INVENTARIO.Text = "Numero de Registros: "  + dvinventario.Count.ToString();

            
        }

        private void Txt_buscar_inventario_TextChanged(object sender, EventArgs e)
        {
            if(radinv_productid.Checked)
            {
                dvinventario.RowFilter = "product_id LIKE '%" + this.txt_buscar_inventario.Text + "%'";
            }
            if (radinv_productName.Checked)
            {
                dvinventario.RowFilter = "product_name LIKE '%" + this.txt_buscar_inventario.Text + "%'";
            }
            if (radinv_tipo.Checked)
            {
                dvinventario.RowFilter = "tipo LIKE '%" + this.txt_buscar_inventario.Text + "%'";
            }
            CONTA_REGISTER_INVENTARIO.Text = "Numero de Registros: " + Convert.ToString(dvinventario.Count);
        }
    }
}
