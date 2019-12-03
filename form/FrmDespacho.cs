using CrystalDecisions.CrystalReports.Engine;
using RitramaAPP.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;


namespace RitramaAPP.form
{
    public partial class FrmDespacho : Form
    {
        public FrmDespacho()
        {
            InitializeComponent();
        }
        readonly DespachosManager despachomanager = new DespachosManager();
        DataSet ds = new DataSet();
        readonly BindingSource bs = new BindingSource();
        readonly ConfigManager config = new ConfigManager();
        readonly BindingSource bsitem = new BindingSource();
        DataRowView ParentRow, ChildRows;
        int EditMode = 0, Consec = 0;
        readonly decimal PORC_ITBIS = 18;
        ClassDespacho despacho;
        List<Roll_Details> listarc;
        private void FrmDespacho_Load(object sender, EventArgs e)
        {
            AplicarEstilosGrid();
            ds = despachomanager.ds;
            bs.DataSource = ds;
            bs.DataMember = "dtdespacho";
            txt_numero_despacho.DataBindings.Add("text", bs, "numero");
            txt_fecha_despacho.DataBindings.Add("text", bs, "fecha");
            txt_customer_id.DataBindings.Add("text", bs, "customer_id");
            txt_customer_name.DataBindings.Add("text", bs, "customer_name");
            txt_customer_direc.DataBindings.Add("text", bs, "customer_dir");
            txt_contact_person.DataBindings.Add("text", bs, "person_contact");
            txt_vendor_id.DataBindings.Add("text", bs, "vendor_id");
            txt_vendor_name.DataBindings.Add("text", bs, "vendor_name");
            txt_transport_id.DataBindings.Add("text", bs, "transport_id");
            txt_transport_name.DataBindings.Add("text", bs, "transport_name");
            txt_chofer_id.DataBindings.Add("text", bs, "chofer_id");
            txt_chofer_name.DataBindings.Add("text", bs, "chofer_name");
            txt_placas.DataBindings.Add("text", bs, "placas_id");
            txt_camion.DataBindings.Add("text", bs, "camion_name");
            txt_tipo_embalaje.DataBindings.Add("text", bs, "packing");
            txt_ocompra.DataBindings.Add("text", bs, "orden_compra");
            txt_otrabajo.DataBindings.Add("text", bs, "orden_trabajo");
            txt_subtotal.DataBindings.Add("text", bs, "subtotal");
            txt_monto_itbis.DataBindings.Add("text", bs, "itbis");
            txt_total_despacho.DataBindings.Add("text", bs, "total$rd");
            txt_porc_itbis.DataBindings.Add("text", bs, "porc_itbis");
            bsitem.DataSource = bs;
            bsitem.DataMember = "FK_MASTER_DETAILS";
            grid_items.DataSource = bsitem;
            LoadDataRC();
        }
        private void AplicarEstilosGrid()
        {
            //grid renglones
            grid_items.AutoGenerateColumns = false;
            AGREGAR_COLUMN_GRID("product_id", 50, "Product Id.", "product_id", grid_items);
            AGREGAR_COLUMN_GRID("product_name", 180, "Nombre del Producto", "product_name", grid_items);
            AGREGAR_COLUMN_GRID("unidad", 50, "Unidad", "unid_id", grid_items);
            DataGridViewButtonColumn col3 = new DataGridViewButtonColumn
            {
                Name = "SeachProduct",
                Width = 25,
                HeaderText = "..."
            };
            grid_items.Columns.Add(col3);
            AGREGAR_COLUMN_GRID("cant", 45, "Cant.", "cant", grid_items);
            AGREGAR_COLUMN_GRID("ancho", 45, "Ancho (inch)", "width", grid_items);
            AGREGAR_COLUMN_GRID("largo", 45, "Largo (pies)", "lenght", grid_items);
            AGREGAR_COLUMN_GRID("msi", 45, "Msi.", "msi", grid_items);
            AGREGAR_COLUMN_GRID("pie_lin", 45, "Total Pie Lin.", "total_pie_lin", grid_items);
            AGREGAR_COLUMN_GRID("ratio", 45, "Ratio", "ratio", grid_items);
            AGREGAR_COLUMN_GRID("kilo_rollo", 45, "kilo rollo", "kilo_rollo", grid_items);
            AGREGAR_COLUMN_GRID("kilo_total", 45, "kilo Total", "kilo_total", grid_items);
            AGREGAR_COLUMN_GRID("precio", 60, "precio", "precio", grid_items);
            AGREGAR_COLUMN_GRID("total_renglon", 80, "Total renglon", "total_renglon", grid_items);
            // grid detalle rc.
            grid_UniqueCode.AutoGenerateColumns = false;
            AGREGAR_COLUMN_GRID("code_unique", 60, "Codigo Unico", "unique_code", grid_UniqueCode);
            AGREGAR_COLUMN_GRID("product_id", 60, "Product Id", "product_id", grid_UniqueCode);
            AGREGAR_COLUMN_GRID("product_name", 200, "Nombre del Producto", "product_name", grid_UniqueCode);
            AGREGAR_COLUMN_GRID("roll_number", 50, "Roll Number", "roll_number", grid_UniqueCode);
            AGREGAR_COLUMN_GRID("width", 50, "Width", "width", grid_UniqueCode);
            AGREGAR_COLUMN_GRID("lenght", 50, "Lenght", "large", grid_UniqueCode);
            AGREGAR_COLUMN_GRID("msi", 50, "Msi", "msi", grid_UniqueCode);
            AGREGAR_COLUMN_GRID("splice", 50, "Splice", "splice", grid_UniqueCode);
            AGREGAR_COLUMN_GRID("rollid", 50, "Roll Id", "roll_id", grid_UniqueCode);
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
        private void BOT_IMPRIMIR_Click(object sender, EventArgs e)
        {
            //entra al detalle de los Unique Code RC
            if (chk_print_unique.Checked)
            {
                using (FrmReportViewCrystal frmReportView = new FrmReportViewCrystal())
                {
                    ReportDocument reporte = new ReportDocument();
                    reporte.Load(R.PATH_FILES.PATH_REPORTS_DETALLE_RC);
                    reporte.SetParameterValue("NUMERO", txt_numero_despacho.Text.Trim());
                    frmReportView.crystalReportViewer1.ReportSource = reporte;
                    frmReportView.crystalReportViewer1.Zoom(80);
                    frmReportView.Text = "Detalle de los Unique Code (RC)";
                    frmReportView.Width = 920;
                    frmReportView.Height = 820;
                    frmReportView.ShowDialog();
                }
            }
            //formato de conduce sin precio
            else if (chk_without_price.Checked)
            {
                using (FrmReportViewCrystal frmReportView = new FrmReportViewCrystal())
                {
                    ReportDocument reporte = new ReportDocument();
                    reporte.Load(R.PATH_FILES.PATH_REPORTS_FORMAT_CONDUCE_SP);
                    reporte.SetParameterValue("NUMERO", txt_numero_despacho.Text.Trim());
                    frmReportView.crystalReportViewer1.ReportSource = reporte;
                    frmReportView.crystalReportViewer1.Zoom(150);
                    frmReportView.Text = "(Formato de Conduce Ritrama Sin precio)";
                    frmReportView.Width = 920;
                    frmReportView.Height = 820;
                    frmReportView.ShowDialog();
                }

            }
            //formato de conduce con precio
            else
            {
                using (FrmReportViewCrystal frmReportView = new FrmReportViewCrystal())
                {
                    ReportDocument reporte = new ReportDocument();
                    reporte.Load(R.PATH_FILES.PATH_REPORTS_FORMAT_CONDUCE);
                    reporte.SetParameterValue("NUMERO", txt_numero_despacho.Text.Trim());
                    frmReportView.crystalReportViewer1.ReportSource = reporte;
                    frmReportView.crystalReportViewer1.Zoom(150);
                    frmReportView.Text = "Formato de Conduce Ritrama";
                    frmReportView.Width = 920;
                    frmReportView.Height = 820;
                    frmReportView.ShowDialog();
                }
            }




        }

        private void Bot_nuevo_Click(object sender, EventArgs e)
        {
            Consec = Convert.ToInt32(config.GetParameterControl("CONSEC_DP")) + 1;
            ParentRow = (DataRowView)bs.AddNew();
            ParentRow.BeginEdit();
            ParentRow["numero"] = Convert.ToString(Consec);
            ParentRow["fecha"] = DateTime.Today;
            ParentRow.EndEdit();
            txt_numero_despacho.Focus();
            ContadorRegistros();
            OptionsMenu(0);
            OptionsForm(0);
            txt_porc_itbis.Text = PORC_ITBIS.ToString();
            EditMode = 1;
        }
        private void ContadorRegistros()
        {

        }
        private void OptionsMenu(int state)
        {
            switch (state)
            {
                case 0:
                    //modo agregar nuevo orden.
                    BOT_PRIMERO.Enabled = false;
                    BOT_SIGUIENTE.Enabled = false;
                    BOT_ANTERIOR.Enabled = false;
                    BOT_ULTIMO.Enabled = false;
                    bot_nuevo.Enabled = false;
                    BOT_BUSCAR.Enabled = false;
                    BOT_CANCELAR.Enabled = true;
                    BOT_SAVE.Enabled = true;
                    bot_modificar.Enabled = false;
                    BOT_IMPRIMIR.Enabled = false;
                    break;
                case 1:
                    //modo despues de grabar
                    BOT_PRIMERO.Enabled = true;
                    BOT_SIGUIENTE.Enabled = true;
                    BOT_ANTERIOR.Enabled = true;
                    BOT_ULTIMO.Enabled = true;
                    bot_nuevo.Enabled = true;
                    BOT_BUSCAR.Enabled = true;
                    BOT_CANCELAR.Enabled = false;
                    BOT_SAVE.Enabled = false;
                    bot_modificar.Enabled = true;
                    BOT_IMPRIMIR.Enabled = true;
                    break;
                case 2:
                    break;
            }

        }
        private void OptionsForm(int state)
        {
            switch (state)
            {
                case 0:
                    //abrir el formulario para agregar un nuevo despacho
                    txt_fecha_despacho.Enabled = true;
                    txt_customer_id.ReadOnly = false;
                    txt_contact_person.ReadOnly = false;
                    txt_ocompra.ReadOnly = false;
                    txt_otrabajo.ReadOnly = false;
                    txt_tipo_embalaje.ReadOnly = false;
                    bot_vendor_search.Enabled = true;
                    bot_chofer_search.Enabled = true;
                    BOT_CAMION.Enabled = true;
                    bot_transport_search.Enabled = true;
                    bot_agregar_renglon.Enabled = true;
                    bot_eliminar_renglon.Enabled = true;
                    bot_buscar_clientes.Enabled = true;
                    bot_sincro.Enabled = true;
                    BOT_DESPACHOS_RC.Enabled = true;
                    grid_items.Enabled = true;
                    grid_items.ReadOnly = false;
                    break;
                case 1:
                    // cerrar el formulario para no permitir mas cambio y colocarlo en modo readonly.
                    txt_fecha_despacho.Enabled = false;
                    txt_customer_id.ReadOnly = true;
                    txt_contact_person.ReadOnly = true;
                    txt_ocompra.ReadOnly = true;
                    txt_otrabajo.ReadOnly = true;
                    txt_tipo_embalaje.ReadOnly = true;
                    bot_buscar_clientes.Enabled = false;
                    BOT_CAMION.Enabled = false;
                    bot_chofer_search.Enabled = false;
                    bot_vendor_search.Enabled = false;
                    bot_transport_search.Enabled = false;
                    bot_agregar_renglon.Enabled = false;
                    bot_eliminar_renglon.Enabled = false;
                    bot_sincro.Enabled = false;
                    grid_items.Enabled = false;
                    break;
                case 2:
                    break;
            }
        }
        private void Bot_buscar_clientes_Click(object sender, EventArgs e)
        {
            using (SeleccionCustomers selectcustomer = new SeleccionCustomers())
            {
                selectcustomer.dtcustomer = ds.Tables["dtcustomer"];
                selectcustomer.ShowDialog();
                txt_customer_id.Text = selectcustomer.GetCustomerId;
                txt_customer_name.Text = selectcustomer.GetCustomerName;
                txt_customer_direc.Text = selectcustomer.GetCustomerDirecc;
            }
        }

        private void Bot_vendor_search_Click(object sender, EventArgs e)
        {
            SeleccionVendedores selectvendedores = new SeleccionVendedores
            {
                dtvendedor = ds.Tables["dtvendor"]
            };
            selectvendedores.ShowDialog();
            txt_vendor_id.Text = selectvendedores.GetVendedorId;
            txt_vendor_name.Text = selectvendedores.GetVendedorName;
        }

        private void Bot_transport_search_Click(object sender, EventArgs e)
        {
            SeleccionTransporte selecttransporte = new SeleccionTransporte
            {
                dttransporte = ds.Tables["dttransporte"]
            };
            selecttransporte.ShowDialog();
            txt_transport_id.Text = selecttransporte.GetTransporteId;
            txt_transport_name.Text = selecttransporte.GetTransporteName;
        }
        private void Bot_chofer_search_Click(object sender, EventArgs e)
        {
            SeleccionChofer selectchofer = new SeleccionChofer
            {
                dtchofer = ds.Tables["dtchofer"]
            };
            selectchofer.ShowDialog();
            txt_chofer_id.Text = selectchofer.GetChoferId;
            txt_chofer_name.Text = selectchofer.GetChoferName;
        }

        private void BOT_CAMION_Click(object sender, EventArgs e)
        {
            SeleccionCamion selectcamion = new SeleccionCamion
            {
                dtcamion = ds.Tables["dtcamion"]
            };
            selectcamion.ShowDialog();
            txt_placas.Text = selectcamion.GetCamionPlaca;
            txt_camion.Text = selectcamion.GetCamionModelo;
        }

        private void Agregar_renglon_Click(object sender, EventArgs e)
        {
            AgregarRenglon();
        }

        private void Grid_items_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                SeleccionProductos selectProducts = new SeleccionProductos
                {
                    Dtproducto = ds.Tables["dtproducto"]
                };
                selectProducts.ShowDialog();
                grid_items.Rows[e.RowIndex].Cells["product_id"].Value = selectProducts.GetProductId;
                //establecer la unidad.
                if (selectProducts.GetMasterRolls)
                {
                    grid_items.Rows[e.RowIndex].Cells["unidad"].Value = "Master";
                }
                if (selectProducts.GetResma)
                {
                    grid_items.Rows[e.RowIndex].Cells["unidad"].Value = "Resma";
                }
                if (selectProducts.Getgraphics)
                {
                    grid_items.Rows[e.RowIndex].Cells["unidad"].Value = "Graphics";
                }
            }
        }

        private void Grid_items_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void Grid_items_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //Calcular el subtotal
            if (e.ColumnIndex == 4 || e.ColumnIndex == 12)
            {
                if (Convert.ToString(grid_items.Rows[e.RowIndex].Cells["cant"].Value) == "")
                {
                    return;
                }
                grid_items.Rows[e.RowIndex].Cells["total_renglon"].Value =
                Convert.ToDouble(grid_items.Rows[e.RowIndex].Cells["pie_lin"].Value) *
                Convert.ToDouble(grid_items.Rows[e.RowIndex].Cells["precio"].Value);
                //calcular el subtotal.
                txt_subtotal.Text = CalcularSubtotal();
                txt_monto_itbis.Text = CalcularIva(PORC_ITBIS, Convert.ToDecimal(txt_subtotal.Text));
                txt_total_despacho.Text = CalcularTotal(Convert.ToDecimal(txt_subtotal.Text), Convert.ToDecimal(txt_monto_itbis.Text));
            }
            //Calcular los pesos 
            if (e.ColumnIndex == 9)
            {
                grid_items.Rows[e.RowIndex].Cells["kilo_rollo"].Value = Convert.ToDouble(grid_items.Rows[e.RowIndex].Cells["msi"].Value) /
                    Convert.ToDouble(grid_items.Rows[e.RowIndex].Cells["ratio"].Value);

                grid_items.Rows[e.RowIndex].Cells["kilo_total"].Value = Convert.ToDouble(grid_items.Rows[e.RowIndex].Cells["kilo_rollo"].Value) *
                    Convert.ToDouble(grid_items.Rows[e.RowIndex].Cells["cant"].Value);
            }
        }

        private void AgregarRenglon()
        {
            //Agregar detalle de la factura.

            ChildRows = (DataRowView)bsitem.AddNew();
            ChildRows.BeginEdit();
            ChildRows["numero"] = txt_numero_despacho.Text;
            ChildRows["cant"] = 0;
            ChildRows["ratio"] = 0;
            ChildRows["width"] = 0;
            ChildRows["msi"] = 0;
            ChildRows["kilo_rollo"] = 0;
            ChildRows["precio"] = 0.0;
            ChildRows["total_renglon"] = 0;
            ChildRows.Row.SetParentRow(ParentRow.Row);
            ChildRows.EndEdit();
            bsitem.Position = bsitem.Count - 1;
            ContadorRegistros();
        }
        private string CalcularSubtotal()
        {
            decimal subtotal = 0;
            for (int i = 0; i <= grid_items.Rows.Count - 1; i++)
            {
                subtotal += Convert.ToDecimal(grid_items.Rows[i].Cells["total_renglon"].Value);
            }
            return string.Format("{0,12:N2}", subtotal);
        }
        private string CalcularIva(decimal PORC_ITBIS, decimal subtotal)
        {
            decimal monto_itbis = PORC_ITBIS * subtotal / 100;
            return string.Format("{0,12:N2}", monto_itbis);
        }

        private void BOT_SAVE_Click(object sender, EventArgs e)
        {
            switch (EditMode)
            {
                case 1:
                    ToSaveAdd();
                    break;
                case 2:
                    ToSaveUpdate();
                    break;
            }
        }
        private void ToSaveAdd()
        {
            //validar el formulario
            if (txt_customer_id.Text.Length == 0)
            {
                MessageBox.Show("Introduzca el codigo del Cliente.?");
                return;
            }
            if (txt_vendor_id.Text.Length == 0)
            {
                MessageBox.Show("Introduzca el codigo del Vendedor.?");
                return;
            }
            if (txt_transport_id.Text.Length == 0)
            {
                MessageBox.Show("Introduzca el codigo del transporte.?");
                return;
            }
            if (txt_chofer_id.Text.Length == 0)
            {
                MessageBox.Show("Introduzca el codigo del chofer.?");
                return;
            }
            if (txt_placas.Text.Length == 0)
            {
                MessageBox.Show("Introduzca el codigo placas.?");
                return;
            }
            //validar que exista 
            if (grid_items.Rows.Count < 1)
            {
                MessageBox.Show("Ingrese los datos del renglon antes de grabar.?");
                return;
            }
            //validar renglones
            if (!ValidarRenglon())
            {
                return;
            };
            // grabar la orden de conduce.
            despachomanager.Add(CrearObjectDespacho(), false);
            // grabar el detalle de los uniques code
            despachomanager.AddRC(listarc, txt_numero_despacho.Text.Trim());
            //grabar el consecutivo en la tabla de parametros.
            config.SetParametersControl(Consec.ToString(), "CONSEC_DP");
            //Actualizar los inventarios
            Actualizarinventarios();

            OptionsMenu(1);
            OptionsForm(1);

        }
        private void ToSaveUpdate()
        {

        }

        private void BOT_SIGUIENTE_Click(object sender, EventArgs e)
        {
            bs.Position += 1;
            ContadorRegistros();
            LoadDataRC();
        }

        private void BOT_ANTERIOR_Click(object sender, EventArgs e)
        {
            bs.Position -= 1;
            ContadorRegistros();
            LoadDataRC();
        }

        private void BOT_PRIMERO_Click(object sender, EventArgs e)
        {
            bs.Position = 0;
            ContadorRegistros();
            LoadDataRC();
        }

        private void BOT_ULTIMO_Click(object sender, EventArgs e)
        {
            bs.Position = bs.Count - 1;
            ContadorRegistros();
            LoadDataRC();
        }
        private string CalcularTotal(decimal subtotal, decimal monto_itbis)
        {
            decimal total = subtotal + monto_itbis;
            return string.Format("{0,12:N2}", total);
        }

        private void BOT_CANCELAR_Click(object sender, EventArgs e)
        {
            if (EditMode == 1)
            {
                DataRowView rowcurrent;
                rowcurrent = (DataRowView)bs.Current;
                rowcurrent.Row.Delete();
                bs.EndEdit();
                ContadorRegistros();
                bs.Position = bs.Count - 1;
                //activo la funciones del menu
                OptionsMenu(1);
                OptionsForm(1);
                EditMode = 0;
            }
            if (EditMode == 2)
            {
                OptionsMenu(1);
                OptionsForm(1);
                EditMode = 0;
            }
        }

        private void Bot_sincro_Click(object sender, EventArgs e)
        {
            using (PickingList pl = new PickingList())
            {
                pl.ShowDialog();
                int fila = 0;
                if (pl.List_products.Count() == 0)
                {
                    return;
                }
                //llenar el grid de renglones desde la sincronizacion. 
                foreach (Producto item in pl.List_products)
                {
                    AgregarRenglon();
                    grid_items.Rows[fila].Cells["product_id"].Value = pl.List_products.ElementAt(fila).Product_id;
                    grid_items.Rows[fila].Cells["cant"].Value = pl.List_products.ElementAt(fila).Product_quantity;
                    grid_items.Rows[fila].Cells["unidad"].Value = "rollo cortado.";
                    grid_items.Rows[fila].Cells["ancho"].Value = pl.List_products.ElementAt(fila).width;
                    grid_items.Rows[fila].Cells["largo"].Value = pl.List_products.ElementAt(fila).lenght;
                    grid_items.Rows[fila].Cells["msi"].Value = pl.List_products.ElementAt(fila).msi;
                    grid_items.Rows[fila].Cells["pie_lin"].Value = Convert.ToDouble(pl.List_products.ElementAt(fila).msi) *
                        Convert.ToDouble(pl.List_products.ElementAt(fila).Product_quantity);
                    grid_items.Rows[fila].Cells["ratio"].Value = despachomanager
                        .GetRatioProduct(pl.List_products.ElementAt(fila).Product_id);
                    grid_items.Rows[fila].Cells["kilo_rollo"].Value =
                        Convert.ToDouble(grid_items.Rows[fila].Cells["msi"].Value) /
                        Convert.ToDouble(grid_items.Rows[fila].Cells["ratio"].Value);

                    grid_items.Rows[fila].Cells["kilo_total"].Value =
                        Convert.ToDouble(grid_items.Rows[fila].Cells["kilo_rollo"].Value) *
                        Convert.ToDouble(grid_items.Rows[fila].Cells["cant"].Value);

                    fila += 1;
                }
                //llenar el grid de unique_code.
                grid_UniqueCode.DataSource = pl.Lista_rollos.ToList();



                listarc = pl.Lista_rollos.ToList();
            }

        }
        private void LoadDataRC()
        {
            grid_UniqueCode.DataSource = despachomanager.GetDataUniqueCode(txt_numero_despacho.Text.Trim());
        }

        private ClassDespacho CrearObjectDespacho()
        {
            despacho = new ClassDespacho
            {
                numero = (txt_numero_despacho.Text),
                fecha_despacho = Convert.ToDateTime(txt_fecha_despacho.Text),
                curstomer_id = txt_customer_id.Text,
                curstomer_name = txt_customer_name.Text,
                curstomer_direc = txt_customer_direc.Text,
                persona_entrega = txt_contact_person.Text,
                vendedor_id = txt_vendor_id.Text,
                vendedor_name = txt_vendor_name.Text,
                transport_id = txt_transport_id.Text,
                transport_name = txt_transport_name.Text,
                chofer_id = txt_chofer_id.Text,
                chofer_name = txt_chofer_name.Text,
                placas_id = txt_placas.Text,
                modelo_camion = txt_camion.Text,
                tipo_embalaje = txt_tipo_embalaje.Text,
                orden_trabajo = txt_otrabajo.Text,
                orden_compra = txt_ocompra.Text,
                subtotal = Convert.ToDecimal(txt_subtotal.Text),
                monto_itbis = Convert.ToDecimal(txt_monto_itbis.Text),
                total = Convert.ToDecimal(txt_total_despacho.Text)
            };
            despacho.items = new List<Items_despacho>();
            for (int fila = 0; fila <= grid_items.Rows.Count - 1; fila++)
            {
                Items_despacho item = new Items_despacho
                {
                    product_id = grid_items.Rows[fila].Cells["product_id"].Value.ToString(),
                    product_name = grid_items.Rows[fila].Cells["product_name"].Value.ToString(),
                    cantidad = Convert.ToDecimal(grid_items.Rows[fila].Cells["cant"].Value),
                    unidad = grid_items.Rows[fila].Cells["unidad"].Value.ToString(),
                    width = Convert.ToDecimal(grid_items.Rows[fila].Cells["ancho"].Value),
                    lenght = Convert.ToDecimal(grid_items.Rows[fila].Cells["largo"].Value),
                    msi = Convert.ToDecimal(grid_items.Rows[fila].Cells["msi"].Value),
                    total_pie_lineal = Convert.ToDecimal(grid_items.Rows[fila].Cells["pie_lin"].Value),
                    ratio = Convert.ToDecimal(grid_items.Rows[fila].Cells["ratio"].Value),
                    kilo_rollo = Convert.ToDecimal(grid_items.Rows[fila].Cells["kilo_rollo"].Value),
                    kilo_total = Convert.ToDecimal(grid_items.Rows[fila].Cells["kilo_total"].Value),
                    precio = Convert.ToDecimal(grid_items.Rows[fila].Cells["precio"].Value),
                    subtotal = Convert.ToDecimal(grid_items.Rows[fila].Cells["total_renglon"].Value)
                };
                despacho.items.Add(item);
            }
            return despacho;
        }

        private void Bot_modificar_Click(object sender, EventArgs e)
        {

        }

        private Boolean ValidarRenglon()
        {
            Boolean chk = true;
            for (int i = 0; i <= grid_items.Rows.Count - 1; i++)
            {
                if (Convert.ToString(grid_items.Rows[i].Cells["product_id"].Value) == "")
                {
                    MessageBox.Show("falta el codigo del articulo.?");
                    chk = false;
                    break;
                }
                if (Convert.ToDecimal(grid_items.Rows[i].Cells["cant"].Value) <= 0)
                {
                    MessageBox.Show("Introduzca la cantidad.?");
                    chk = false;
                    break;
                }
                if (Convert.ToDecimal(grid_items.Rows[i].Cells["precio"].Value) <= 0)
                {
                    MessageBox.Show("Introduzca el precio.?");
                    chk = false;
                    break;
                }
            }
            return chk;
        }
        private void Actualizarinventarios()
        {

        }
    }
}