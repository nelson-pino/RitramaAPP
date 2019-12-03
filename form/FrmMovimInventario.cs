using RitramaAPP.Clases;
using System;
using System.Windows.Forms;

namespace RitramaAPP.form
{
    public partial class FrmMovimInventario : Form
    {
        public FrmMovimInventario()
        {
            InitializeComponent();
        }
        InventarioManager manager = new InventarioManager();
        public string SetProduct_Id { get; set; }
        public string SetProduct_Name { get; set; }
        public string SetProduct_Tipo { get; set; }
        int productTipo = 0;
        private void FrmMovimInventario_Load(object sender, EventArgs e)
        {
            SelectProductTipo();
            product_id.Text = "Product Id.:" + SetProduct_Id;
            product_name.Text = "Nombre del Producto :" + SetProduct_Name;
            product_tipo.Text = "Tipo Producto :" + SetProduct_Tipo;
            FORMAT_DATAGRID();
        }
        private void FORMAT_DATAGRID()
        {
            switch (productTipo)
            {
                //master
                case 1:
                    //se buscan las entradas en las recepciones. 
                    FORMAT_GRIDS_MASTER();
                    grid_entradas.DataSource = manager.CargarMovimientoEntradaMaster(SetProduct_Id);
                    break;
                case 2:
                    //rollo cortado
                    FORMAT_ROLLO_CORTADO();
                    grid_entradas.DataSource = manager.CargaMovimientoEntradaRollosCortados(SetProduct_Id);
                    grid_salidas.DataSource = manager.CargaMovimientoSalidasRollosCortados(SetProduct_Id);

                    break;
                case 3:

                    break;
                case 4:

                    break;
            }
        }
        private void SelectProductTipo()
        {
            switch (SetProduct_Tipo)
            {
                case "Master":
                    productTipo = 1;
                    break;
                case "Rollo Cortado":
                    productTipo = 2;
                    break;
                case "Graphics":
                    productTipo = 3;
                    break;
                case "Hojas":
                    productTipo = 4;
                    break;
            }
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
        private void FORMAT_GRIDS_MASTER()
        {
            grid_entradas.AutoGenerateColumns = false;
            AGREGAR_COLUMN_GRID("numdoc", 60, "Num Orden", "OrderPurchase", grid_entradas);
            AGREGAR_COLUMN_GRID("fecha", 80, "Fecha", "fecha_reg", grid_entradas);
            AGREGAR_COLUMN_GRID("embarque", 60, "Embarque", "embarque", grid_entradas);
            AGREGAR_COLUMN_GRID("rollid", 80, "Roll Id.", "Roll_Id", grid_entradas);
            AGREGAR_COLUMN_GRID("prov", 180, "Nombre del Proveedor", "Proveedor_Name", grid_entradas);
            AGREGAR_COLUMN_GRID("width", 60, "Width", "width", grid_entradas);
            AGREGAR_COLUMN_GRID("lenght", 55, "Lenght", "lenght", grid_entradas);
            AGREGAR_COLUMN_GRID("splice", 55, "Splice", "splice", grid_entradas);
            AGREGAR_COLUMN_GRID("core", 55, "Core", "core", grid_entradas);
            AGREGAR_COLUMN_GRID("ubic", 70, "Ubicacion", "Ubicacion", grid_entradas);

        }
        private void FORMAT_ROLLO_CORTADO()
        {
            grid_entradas.AutoGenerateColumns = false;
            AGREGAR_COLUMN_GRID("oc", 60, "Orden Corte", "numero", grid_entradas);
            AGREGAR_COLUMN_GRID("fecha", 80, "Fecha", "fecha", grid_entradas);
            AGREGAR_COLUMN_GRID("roll#", 60, "Roll #", "roll_number", grid_entradas);
            AGREGAR_COLUMN_GRID("code_unique", 60, "Code Unique", "unique_code", grid_entradas);
            AGREGAR_COLUMN_GRID("width", 60, "Width", "width", grid_entradas);
            AGREGAR_COLUMN_GRID("lenght", 60, "Lenght", "large", grid_entradas);
            AGREGAR_COLUMN_GRID("msi", 60, "Msi", "msi", grid_entradas);
            AGREGAR_COLUMN_GRID("splice", 60, "Splice", "splice", grid_entradas);
            AGREGAR_COLUMN_GRID("rollid", 60, "Roll Id.", "roll_id", grid_entradas);
            AGREGAR_COLUMN_GRID("code_perso", 60, "Codigo Person.", "code_person", grid_entradas);
            AGREGAR_COLUMN_GRID("status", 60, "Status.", "status", grid_entradas);
            grid_salidas.AutoGenerateColumns = false;
            AGREGAR_COLUMN_GRID("conduce", 65, "Numero Conduce", "conduce", grid_salidas);
            AGREGAR_COLUMN_GRID("fecha", 65, "Fecha Conduce", "fecha", grid_salidas);
            AGREGAR_COLUMN_GRID("code_unique", 80, "Codigo Unico", "unique_code", grid_salidas);
            AGREGAR_COLUMN_GRID("width", 70, "Width", "width", grid_salidas);
            AGREGAR_COLUMN_GRID("lenght", 70, "Lenght", "lenght", grid_salidas);
            AGREGAR_COLUMN_GRID("msi", 70, "Msi", "msi", grid_salidas);
            AGREGAR_COLUMN_GRID("splice", 70, "Splice", "splice", grid_salidas);
            AGREGAR_COLUMN_GRID("rollid", 80, "Roll Id.", "roll_id", grid_salidas);
            AGREGAR_COLUMN_GRID("Customer_Name", 120, "Nombre del Cliente", "Customer_Name", grid_salidas);
        }
    }
}
