using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RitramaAPP.Clases;
using RitramaAPP.form;
using System.IO;

namespace RitramaAPP
{
    public partial class FrmOrdenCorte : Form
    {
        public FrmOrdenCorte()
        {
            InitializeComponent();
        }
        readonly OrdenCorteManager manager_orden = new OrdenCorteManager();
        readonly ConfigManager config = new ConfigManager();
        readonly BindingSource bs = new BindingSource();
        readonly BindingSource bsdetalle = new BindingSource();
        readonly System.Data.DataTable dtrolls = new System.Data.DataTable();
        System.Data.DataTable dtproducts = new System.Data.DataTable();
        DataSet ds = new DataSet();
        DataRowView ParentRow, ChildRows;
        DataGridViewComboBoxColumn ComboUnidad = new DataGridViewComboBoxColumn();
        int renglon,ConsecOrden;
        double factor = 0.012;
        Orden orden = new Orden();
        private void FrmOrdenCorte_Load(object sender, EventArgs e)
        {
            AplicarEstilosGridItems();
            AplicarEstilosGridRollos();
            ds = manager_orden.ds;
            bs.DataSource = ds;
            bs.DataMember = "dtordenes";
            txt_numero_oc.DataBindings.Add("text",bs,"numero");
            txt_fecha_orden.DataBindings.Add("text", bs, "fecha");
            txt_numero_pedido.DataBindings.Add("text",bs,"pedido");
            txt_customer_id.DataBindings.Add("text",bs,"customer_id");
            txt_customer_name.DataBindings.Add("text",bs,"customer_name");
            txt_total_roll.DataBindings.Add("text",bs,"total_rollos");
            bsdetalle.DataMember = "FK_ORDENES_DETALLE";
            bsdetalle.DataSource = bs;
            grid_items.DataSource = bsdetalle;
            grid_rollos.DataSource = dtrolls;
            ContadorRegistros();
        }
        private void ContadorRegistros()
        {
            contador.Text = "Documento :" + (bs.Position + 1).ToString() +"/"+ bs.Count.ToString();
            DataRow parent = ds.Tables["dtordenes"].Rows[bs.Position];
            //Mostrar los roll id relacionados con la orden en la navegacion.
            list_roll_id.Items.Clear();
            foreach (DataRow item in parent.GetChildRows("FK_ORDEN_ROLL_ID"))
            {
                list_roll_id.Items.Add(item["roll_id"]);
            }
        }
        private void Grid_items_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string product_id =  grid_items.Rows[e.RowIndex].Cells[0].Value.ToString();
            string orden = txt_numero_oc.Text.Trim();
            grid_rollos.DataSource = manager_orden.GetRollDetails(orden, product_id);
        }
        private void Bot_siguiente_Click(object sender, EventArgs e)
        {
            bs.Position += 1;
            ContadorRegistros();
            grid_rollos.DataSource = "";
        }

        private void Bot_anterior_Click(object sender, EventArgs e)
        {
            bs.Position -= 1;
            ContadorRegistros();
            grid_rollos.DataSource = "";
        }

        private void Bot_primero_Click(object sender, EventArgs e)
        {
            bs.Position = 0;
            ContadorRegistros();
            grid_rollos.DataSource = "";
        }

        private void Bot_ultimo_Click(object sender, EventArgs e)
        {
            bs.Position = bs.Count - 1;
            ContadorRegistros();
            grid_rollos.DataSource = "";
        }

        private void BOT_NUEVO_Click(object sender, EventArgs e)
        {
            //Buscar los productos para el buscador
            ProductsManager pm = new ProductsManager();
            dtproducts = pm.GetTableProductsOnly();
            //Preparo el formulario abriendo los textbox.
            txt_fecha_orden.Enabled = true;
            txt_customer_id.ReadOnly = false;
            txt_roll_id.ReadOnly = false;
            grid_items.ReadOnly = false;
            //busco el proximo numero de consecutivo de la orden.
            ConsecOrden = Convert.ToInt32(config.GetParameterControl("COC"));
            //Agregar encabezado de la Factura.
            ParentRow = (DataRowView)bs.AddNew();
            ParentRow.BeginEdit();
            ParentRow["numero"] = ConsecOrden;
            ParentRow["pedido"] = "0";
            ParentRow["anulada"] = false;
            ParentRow["status"] = 0;
            ParentRow["total_rollos"] = 0;
            ParentRow.EndEdit();
            AgregarRenglon();
        }
        private void AgregarRenglon()
        {
            //Agregar detalle de la factura.
            renglon += 1;
            ChildRows = (DataRowView)bsdetalle.AddNew();
            ChildRows.BeginEdit();
            ChildRows["numero"] = "4094";
            ChildRows["reng_num"] = renglon;
            ChildRows["cantidad"] = 0;
            ChildRows["width"] = 0;
            ChildRows["large"] = 0;
            ChildRows.Row.SetParentRow(ParentRow.Row);
            ChildRows.EndEdit();
            bs.Position = bs.Count - 1;
            ContadorRegistros();
        }
        private void AplicarEstilosGridRollos()
        {
            grid_rollos.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn
            {
                Name = "roll",
                Width = 45,
                HeaderText = "rolls #",
                DataPropertyName = "roll_number"
            };
            grid_rollos.Columns.Add(col1);
            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn
            {
                Name = "product_id",
                Width = 65,
                HeaderText = "Prod. Id",
                DataPropertyName = "product_id"
            };
            grid_rollos.Columns.Add(col2);
            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn
            {
                Name = "product_name",
                Width = 190,
                HeaderText = "Descripcion Producto",
                DataPropertyName = "product_name"
            };
            grid_rollos.Columns.Add(col3);
            DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn
            {
                Name = "Unique_Code",
                Width = 70,
                HeaderText = "Unique Code",
                DataPropertyName = "unique_code"
            };
            grid_rollos.Columns.Add(col4);
            DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn
            {
                Name = "ancho",
                Width = 52,
                HeaderText = "Ancho",
                DataPropertyName = "width"
            };
            grid_rollos.Columns.Add(col5);
            DataGridViewTextBoxColumn col6 = new DataGridViewTextBoxColumn
            {
                Name = "largo",
                Width = 52,
                HeaderText = "largo",
                DataPropertyName = "large"
            };
            grid_rollos.Columns.Add(col6);
            DataGridViewTextBoxColumn col61 = new DataGridViewTextBoxColumn
            {
                Name = "msi",
                Width = 55,
                HeaderText = "Msi",
                DataPropertyName = "msi"
            };
            grid_rollos.Columns.Add(col61);
            DataGridViewTextBoxColumn col7 = new DataGridViewTextBoxColumn
            {
                Name = "splice",
                Width = 53,
                HeaderText = "Splice",
                DataPropertyName = "splice"
            };
            grid_rollos.Columns.Add(col7);
            DataGridViewTextBoxColumn col8 = new DataGridViewTextBoxColumn
            {
                Name = "roll_id",
                Width = 115,
                HeaderText = "Roll Id.",
                DataPropertyName = "roll_id"
            };
            grid_rollos.Columns.Add(col8);
            DataGridViewTextBoxColumn col9 = new DataGridViewTextBoxColumn
            {
                Name = "code_personalize",
                Width = 150,
                HeaderText = "Code Person.",
                DataPropertyName = "code_perso"
            };
            grid_rollos.Columns.Add(col9);
        }
        private void Grid_items_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                double msi = (Convert.ToDouble(grid_items.Rows[e.RowIndex].Cells["width"].Value) *
                Convert.ToDouble(grid_items.Rows[e.RowIndex].Cells["large"].Value) * factor);
                grid_items.Rows[e.RowIndex].Cells["msi"].Value = msi;
            }

            txt_total_roll.Text = CalcularTotalRollos();


        }

        private void Bot_add_items_Click(object sender, EventArgs e)
        {
            AgregarRenglon();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            CustomerManager custom = new CustomerManager();
            SeleccionCustomers miformc = new SeleccionCustomers();
            miformc.dtcustomer = custom.GetCustomersTableOnly();
            miformc.ShowDialog();
            txt_customer_id.Text = miformc.GetCustomerId;
            txt_customer_name.Text = miformc.GetCustomerName;
        }

        private void Grid_items_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                SeleccionProductos FormBuscarArticulos = new SeleccionProductos();
                FormBuscarArticulos.dtproducto = dtproducts;
                FormBuscarArticulos.ShowDialog();
                grid_items.Rows[e.RowIndex].Cells["product_id"].Value = FormBuscarArticulos.GetProductId;
            }
        }
        private string CalcularTotalRollos()
        {
            int rollos = 0;
            for (int i = 0; i <= grid_items.Rows.Count - 1; i++)
            {
                rollos = rollos + Convert.ToInt32(grid_items.Rows[i].Cells["cant"].Value);
            }
            return rollos.ToString();
        }

        private void Grid_items_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void BOT_SAVE_Click(object sender, EventArgs e)
        {
            //validar el formulario
            if (txt_customer_id.Text.Length == 0)
            {
                MessageBox.Show("Introduzca el codigo del Cliente.?");
                return;
            }
            //validar los renglones.
            //if (!ValidarRenglon())
            //{
            //    return;
            //};
            //llenar el encabezado de la factura
            orden.Numero = (txt_numero_oc.Text);
            orden.Fecha = Convert.ToDateTime(txt_fecha_orden.Text);
            orden.Pedido = txt_numero_pedido.Text;
            orden.Customer_id = txt_customer_id.Text;
            orden.Customer_Name = txt_customer_name.Text;
            orden.Roll_id = txt_roll_id.Text;
            orden.status = 0;
            orden.anulada = false;
            orden.Total_rolls = Convert.ToInt32(txt_total_roll.Text);
            //llenar el detalle de la Orden de Corte.
            orden.items = new List<Orden_Items>();
            for (int i = 0; i <= grid_items.Rows.Count - 1; i++)
            {
                Orden_Items item = new Orden_Items();
                item.renglon = (i + 1).ToString();
                item.numero = ConsecOrden.ToString();
                item.Product_id = grid_items.Rows[i].Cells["product_id"].Value.ToString();
                item.Product_name = grid_items.Rows[i].Cells["product_name"].Value.ToString(); ;
                item.Cantidad = Convert.ToInt32(grid_items.Rows[i].Cells["cant"].Value.ToString());
                item.Unidad = grid_items.Rows[i].Cells["ComboUnidad"].Value.ToString();
                item.Width = Convert.ToDecimal(grid_items.Rows[i].Cells["Width"].Value.ToString());
                item.Large = Convert.ToDecimal(grid_items.Rows[i].Cells["large"].Value.ToString());
                item.Msi = Convert.ToDecimal(grid_items.Rows[i].Cells["msi"].Value.ToString());
                orden.items.Add(item);
            }
            manager_orden.ToSave(orden);
            ConsecOrden += 1;
            config.SetParametersControl(ConsecOrden.ToString(),"COC");
            // Acomodar la barra de herramientas.
            //bot_nuevo.Enabled = true;
            //bot_cancelar.Enabled = false;
            //bot_guardar.Enabled = false;
            //bot_buscar.Enabled = true;
            //bot_anterior.Enabled = true;
            //bot_ultimo.Enabled = true;
            //bot_proximo.Enabled = true;
            //bot_primero.Enabled = true;
            //bot_imprimir_factura.Enabled = true;
            //bot_anular.Enabled = true;
            //txt_buscar.Enabled = true;
            //txt_contador.Enabled = true;
            //bot_renglon_new.Enabled = false;
            //bot_renglon_delete.Enabled = false;
            ////Acomodar el formulario.
            //txt_fecha_fact.Enabled = false;
            //txt_codcliente.Enabled = false;
            //txt_codvendor.Enabled = false;
            //ra_facturas_contado.Enabled = false;
            //ra_facturas_credito.Enabled = false;
            //ra_electronic.Enabled = false;
            //ra_cheque.Enabled = false;
            //grid_productos.Enabled = false;
            //txt_notas.Enabled = false;
            bs.Position = bs.Position - 1;
            bs.Position = bs.Position + 1;
            GenerarDetalleRollos();
        }

        private void ToolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void BOT_ROLLID_ADD_Click(object sender, EventArgs e)
        {
            if (txt_roll_id.Text.Length == 0) return; 
            list_roll_id.Items.Add(txt_roll_id.Text);
            manager_orden.AddNumberRollIdtoTable(txt_numero_oc.Text.Trim(),txt_roll_id.Text.Trim());
            DataRow dr = ds.Tables["dtrollid"].NewRow();
            dr["numero"] = txt_numero_oc.Text.Trim();
            dr["roll_id"] = txt_roll_id.Text.Trim();
            ds.Tables["dtrollid"].Rows.Add(dr);
            ds.Tables["dtrollid"].AcceptChanges();
            txt_roll_id.Text=string.Empty;
        }

        private void Bot_delete_roll_id_Click(object sender, EventArgs e)
        {
            if (list_roll_id.SelectedIndex == -1) return;
            string item = list_roll_id.Items[list_roll_id.SelectedIndex].ToString();
            list_roll_id.Items.RemoveAt(list_roll_id.SelectedIndex);
            manager_orden.DeleteNumberRollIdtoTable(txt_numero_oc.Text,item);
        }

        private void BOT_UPDATE_ROLLID_Click(object sender, EventArgs e)
        {
            if (list_roll_id.SelectedIndex == -1) return;
            if (grid_rollos.Rows.Count == 0) return;

            string item = list_roll_id.Items[list_roll_id.SelectedIndex].ToString();
            for (int i = 0; i < grid_rollos.Rows.Count; i++)
            {
                grid_rollos.Rows[i].Cells["roll_id"].Value = item;
            }
            manager_orden.UpdateDetailRollsNumberRollid(
                txt_numero_oc.Text, grid_rollos.Rows[0].Cells["product_id"].Value.ToString(),
                item);
        }

        private void GenerarDetalleRollos()
        {
            List<Roll_Details> rollos = new List<Roll_Details>();
            int code_unique = Convert.ToInt32(config.GetParameterControl("UC"));
            for (int i = 0; i < grid_items.Rows.Count; i++)
            {
                int filas = orden.items[i].Cantidad;

                for (int j = 0; j < filas; j++)
                {
                    Roll_Details item = new Roll_Details();
                    item.Roll_number = (j + 1).ToString();
                    item.Fecha = Convert.ToDateTime(txt_fecha_orden.Text);
                    item.Numero_Orden = txt_numero_oc.Text;
                    item.Product_id = grid_items.Rows[i].Cells["product_id"].Value.ToString();
                    item.Product_name = grid_items.Rows[i].Cells["product_name"].Value.ToString();
                    item.Roll_id = txt_roll_id.Text;
                    item.Width = Convert.ToDecimal(grid_items.Rows[i].Cells["width"].Value.ToString());
                    item.Large = Convert.ToDecimal(grid_items.Rows[i].Cells["large"].Value.ToString());
                    item.Msi = Convert.ToDecimal(grid_items.Rows[i].Cells["msi"].Value.ToString());
                    item.Splice = 0;
                    item.Code_Person = "XC80RP3000WG";
                    item.Code_Unique = "RC" + code_unique;
                    rollos.Add(item);
                    code_unique += 1;
                }
            }
            config.SetParametersControl(code_unique.ToString(),"UC");
            manager_orden.SaveDataDetailsRolls(rollos);
        }

        private void BOT_EXCEL_EXPORT_Click(object sender, EventArgs e)
        {
            ExportDatatoExcel();
        }

        private void BOT_BUSCAR_Click(object sender, EventArgs e)
        {
            FrmBuscarOrdenes fBuscarOrden = new FrmBuscarOrdenes();
            fBuscarOrden.dtordenes = ds.Tables["dtordenes"];
            fBuscarOrden.ShowDialog();
            int itemFound = bs.Find("numero", fBuscarOrden.orden);
            bs.Position = itemFound;
            grid_rollos.DataSource = "";
        }

        private void AplicarEstilosGridItems()
        {
            grid_items.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn
            {
                Name = "product_id",
                Width = 80,
                HeaderText = "Product Id",
                DataPropertyName = "Product_ID"
            };
            grid_items.Columns.Add(col0);

            DataGridViewButtonColumn col1 = new DataGridViewButtonColumn
            {
                Name = "SeachProduct",
                Width = 25,
                HeaderText = "..."
            };
            grid_items.Columns.Add(col1);
            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn
            {
                Name = "product_name",
                Width = 320,
                HeaderText = "Descripcion del Producto",
                DataPropertyName = "product_name"
            };
            grid_items.Columns.Add(col2);
            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn
            {
                Name = "cant",
                Width = 75,
                HeaderText = "Cantidad",
                DataPropertyName = "cantidad"
            };
            grid_items.Columns.Add(col3);
            ComboUnidad = new DataGridViewComboBoxColumn
            {
                Name = "ComboUnidad",
                HeaderText = "Unidad",
                Width = 75
            };
            ComboUnidad.Items.Add("Rollos");
            ComboUnidad.Items.Add("Cajas");
            ComboUnidad.Items.Add("graphics");
            grid_items.Columns.Add(ComboUnidad);

            DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn
            {
                Name = "width",
                Width = 60,
                HeaderText = "width",
                DataPropertyName = "width"
            };
            grid_items.Columns.Add(col5);
            DataGridViewTextBoxColumn col6 = new DataGridViewTextBoxColumn
            {
                Name = "large",
                Width = 60,
                HeaderText = "large",
                DataPropertyName = "large"
            };
            grid_items.Columns.Add(col6);
            DataGridViewTextBoxColumn col7 = new DataGridViewTextBoxColumn
            {
                Name = "msi",
                Width = 60,
                HeaderText = "Msi",
                DataPropertyName = "msi"
            };
            grid_items.Columns.Add(col7);
        }
        private void ExportDatatoExcel()
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application oExcel = null;
                Workbook wb = null;
                Worksheet sheet = null;
                oExcel = new Microsoft.Office.Interop.Excel.Application();
                string filePath = Path.GetFullPath(@"C:\Users\Npino\Desktop\DATA\tickets_oc.xlsx");
                //oExcel.Visible = true;
                wb = oExcel.Workbooks.Open(filePath);
                sheet = wb.Worksheets[1];
                sheet.Name = "prueba c#";
                int fila = 1;
                while (string.IsNullOrEmpty(((sheet.Cells[fila, 1]).Text.ToString())) == false)
                {
                    sheet.Rows.Delete();
                    fila += 1;
                }
                sheet.Cells[1, 1] = "Fecha";
                sheet.Cells[1, 2] = "Orden";
                sheet.Cells[1, 3] = "Roll #";
                sheet.Cells[1, 4] = "Product Id.";
                sheet.Cells[1, 5] = "Descripcion del Producto";
                sheet.Cells[1, 6] = "width (inch)";
                sheet.Cells[1, 7] = "large (pies)";
                sheet.Cells[1, 8] = "Msi";
                sheet.Cells[1, 9] = "Codigo Personalizado";
                sheet.Cells[1, 10] = "Roll ID";
                sheet.Cells[1, 11] = "Code Unique";
                sheet.Cells[1, 12] = "Splice";
                sheet.Cells[4].EntireColumn.NumberFormat = "@";
                string mproduct_id = grid_rollos.Rows[0].Cells["product_id"].Value.ToString();
                for (int i = 1; i <= grid_rollos.Rows.Count; i++)
                {
                    sheet.Cells[i + 1, 1] = Convert.ToDateTime(txt_fecha_orden.Text).Day + "-" + Convert.ToDateTime(txt_fecha_orden.Text).Month + "-" + Convert.ToDateTime(txt_fecha_orden.Text).Year;
                    sheet.Cells[i + 1, 2] = txt_numero_oc.Text;
                    sheet.Cells[i + 1, 3] = grid_rollos.Rows[i - 1].Cells["roll"].Value;
                    sheet.Cells[i + 1, 4] = mproduct_id;
                    sheet.Cells[i + 1, 5] = grid_rollos.Rows[i - 1].Cells["product_name"].Value;
                    sheet.Cells[i + 1, 6] = grid_rollos.Rows[i - 1].Cells["ancho"].Value;
                    sheet.Cells[i + 1, 7] = grid_rollos.Rows[i - 1].Cells["largo"].Value;
                    sheet.Cells[i + 1, 8] = grid_rollos.Rows[i - 1].Cells["msi"].Value;
                    sheet.Cells[i + 1, 9] = grid_rollos.Rows[i - 1].Cells["code_personalize"].Value;
                    sheet.Cells[i + 1, 10] = grid_rollos.Rows[i - 1].Cells["roll_id"].Value;
                    sheet.Cells[i + 1, 11] = grid_rollos.Rows[i - 1].Cells["Unique_Code"].Value;
                    sheet.Cells[i + 1, 12] = grid_rollos.Rows[i - 1].Cells["splice"].Value;
                }
                wb.Save();
                wb.Close();
                oExcel.Quit();
                MessageBox.Show("se sincronizo data con excel");
            }
            catch (Exception ex)
            {
                MessageBox.Show("error al transmitir data a excel. error code:"+ex);
            }
            
        }
    }
}
