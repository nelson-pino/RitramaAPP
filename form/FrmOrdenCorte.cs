using Microsoft.Office.Interop.Excel;
using RitramaAPP.Clases;
using RitramaAPP.form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace RitramaAPP
{
    public partial class FrmOrdenCorte : Form
    {
        public FrmOrdenCorte()
        {
            InitializeComponent();
        }
        readonly ProduccionManager managerorden = new ProduccionManager();
        readonly ConfigManager configmanager = new ConfigManager();
        readonly BindingSource bs = new BindingSource();
        readonly BindingSource bsdetalle = new BindingSource();
        readonly System.Data.DataTable dtproducts = new System.Data.DataTable();
        DataSet ds = new DataSet();
        private DataRowView ParentRow;
        int EditMode = 0;
        string modproduct_id, modcan_cortado, modwidth, modlenght, modmsi;
        Boolean ischanged_rollos = false;
        Orden orden;

        private void FrmOrdenCorte_Load(object sender, EventArgs e)
        {
            AplicarEstilosGridRollos();
            ds = managerorden.ds;
            bs.DataSource = ds;
            bs.DataMember = "dtordenes";
            txt_numero_oc.DataBindings.Add("text", bs, "numero");
            txt_fecha_orden.DataBindings.Add("text", bs, "fecha");
            txt_fecha_producc.DataBindings.Add("text", bs, "fecha_produccion");
            txt_rollid_1.DataBindings.Add("text", bs, "rollid_1");
            txt_width1_rollid.DataBindings.Add("text", bs, "width_1");
            txt_lenght1_rollid.DataBindings.Add("text", bs, "lenght_1");
            txt_rollid_2.DataBindings.Add("text", bs, "rollid_2");
            txt_width2_rollid.DataBindings.Add("text", bs, "width_2");
            txt_lenght2_rollid.DataBindings.Add("text", bs, "lenght_2");
            txt_product_id.DataBindings.Add("text", bs, "product_id");
            txt_product_name.DataBindings.Add("text", bs, "product_name");
            txt_cant_cortado.DataBindings.Add("text", bs, "cant_cortado");
            txt_width_cortado.DataBindings.Add("text", bs, "width_cortado");
            txt_lenght_cortado.DataBindings.Add("text", bs, "lenght_cortado");
            txt_msi_cortado.DataBindings.Add("text", bs, "msi_cortado");
            chk_process.DataBindings.Add("Checked", bs, "procesado");
            chk_anulado.DataBindings.Add("Checked", bs, "anulada");
            //binding del detalle
            bsdetalle.DataSource = bs;
            bsdetalle.DataMember = "FK_ORDEN_DETAILS";
            grid_rollos.DataSource = bsdetalle;
            VERIFICAR_DOCUMENTO();
        }

        private void BOT_NUEVO_Click(object sender, EventArgs e)
        {
            chk_process.DataBindings.Clear();
            chk_anulado.DataBindings.Clear();
            ParentRow = (DataRowView)bs.AddNew();
            ParentRow.BeginEdit();
            ParentRow["numero"] = "0";
            ParentRow["width_1"] = "0";
            ParentRow["lenght_1"] = "0";
            ParentRow["width_2"] = "0";
            ParentRow["lenght_2"] = "0";
            ParentRow["cant_cortado"] = "0";
            ParentRow["width_cortado"] = "0";
            ParentRow["lenght_cortado"] = "0";
            ParentRow["procesado"] = false;
            ParentRow["anulada"] = false;
            ParentRow["lenght_cortado"] = "0";
            ParentRow.EndEdit();
            txt_width_cortado.Text = "0";
            txt_numero_oc.Focus();
            ContadorRegistros();
            OptionsMenu(0);
            OptionsForm(0);
            EditMode = 1;
        }
        private void OptionsForm(int state)
        {
            switch (state)
            {
                case 0:
                    //modo agregar nuevo orden.
                    txt_numero_oc.ReadOnly = false;
                    txt_fecha_orden.Enabled = true;
                    txt_fecha_producc.Enabled = true;
                    txt_lenght_cortado.ReadOnly = false;
                    txt_cant_cortado.ReadOnly = false;
                    txt_width_cortado.ReadOnly = false;
                    txt_rollid_1.ReadOnly = false;
                    txt_rollid_2.ReadOnly = false;
                    bot_buscar_rollid1.Enabled = true;
                    bot_buscar_rollid2.Enabled = true;
                    bot_generar_rollos_cortados.Enabled = true;
                    break;
                case 1:
                    // modo cerra forms despues de agregar orden colocar en lectura.
                    txt_numero_oc.ReadOnly = true;
                    txt_fecha_orden.Enabled = false;
                    txt_fecha_producc.Enabled = false;
                    txt_lenght_cortado.ReadOnly = true;
                    txt_cant_cortado.ReadOnly = true;
                    txt_msi_cortado.ReadOnly = true;
                    txt_width_cortado.ReadOnly = true;
                    txt_rollid_1.ReadOnly = true;
                    txt_rollid_2.ReadOnly = true;
                    txt_width1_rollid.ReadOnly = true;
                    txt_width2_rollid.ReadOnly = true;
                    txt_lenght1_rollid.ReadOnly = true;
                    txt_lenght2_rollid.ReadOnly = true;
                    bot_buscar_rollid1.Enabled = false;
                    bot_buscar_rollid2.Enabled = false;
                    bot_generar_rollos_cortados.Enabled = false;
                    grid_rollos.ReadOnly = true;
                    break;
                case 2:
                    txt_fecha_orden.Enabled = true;
                    txt_fecha_producc.Enabled = true;
                    txt_rollid_1.ReadOnly = false;
                    txt_width1_rollid.ReadOnly = false;
                    txt_lenght1_rollid.ReadOnly = false;
                    txt_rollid_2.ReadOnly = false;
                    txt_width2_rollid.ReadOnly = false;
                    txt_lenght2_rollid.ReadOnly = false;
                    txt_cant_cortado.ReadOnly = false;
                    txt_width_cortado.ReadOnly = false;
                    txt_lenght_cortado.ReadOnly = false;
                    bot_buscar_rollid1.Enabled = true;
                    bot_buscar_rollid2.Enabled = true;
                    bot_generar_rollos_cortados.Enabled = true;
                    Bot_procesar.Enabled = false;
                    Bot_Anular.Enabled = false;
                    btn_eliminar_renglon.Enabled = true;
                    grid_rollos.ReadOnly = false;
                    grid_rollos.Columns[0].ReadOnly = true;
                    grid_rollos.Columns[1].ReadOnly = true;
                    grid_rollos.Columns[2].ReadOnly = true;
                    grid_rollos.Columns[3].ReadOnly = true;
                    grid_rollos.Columns[6].ReadOnly = true;
                    grid_rollos.Columns[8].ReadOnly = true;


                    break;
            }
        }
        private void OptionsMenu(int state)
        {
            switch (state)
            {
                case 0:
                    //modo agregar nuevo orden.
                    bot_primero.Enabled = false;
                    bot_siguiente.Enabled = false;
                    bot_anterior.Enabled = false;
                    bot_ultimo.Enabled = false;
                    BOT_NUEVO.Enabled = false;
                    BOT_BUSCAR.Enabled = false;
                    BOT_EXCEL_EXPORT.Enabled = false;
                    BOT_CANCELAR.Enabled = true;
                    BOT_SAVE.Enabled = true;
                    bot_modificar.Enabled = false;
                    break;
                case 1:
                    //modo agregar despues de grabar.
                    bot_primero.Enabled = true;
                    bot_siguiente.Enabled = true;
                    bot_anterior.Enabled = true;
                    bot_ultimo.Enabled = true;
                    BOT_NUEVO.Enabled = true;
                    BOT_CANCELAR.Enabled = false;
                    BOT_BUSCAR.Enabled = true;
                    BOT_EXCEL_EXPORT.Enabled = true;
                    BOT_SAVE.Enabled = false;
                    bot_modificar.Enabled = true;
                    break;
            }
        }
        private void ContadorRegistros()
        {
            contador.Text = "Documento :" + (bs.Position + 1).ToString() + "/" + bs.Count.ToString();
        }
        private void Bot_siguiente_Click(object sender, EventArgs e)
        {
            bs.Position += 1;
            ContadorRegistros();
            VERIFICAR_DOCUMENTO();
        }
        private void Bot_anterior_Click(object sender, EventArgs e)
        {
            bs.Position -= 1;
            ContadorRegistros();
            VERIFICAR_DOCUMENTO();
        }
        private void Bot_primero_Click(object sender, EventArgs e)
        {
            bs.Position = 0;
            ContadorRegistros();
            VERIFICAR_DOCUMENTO();
        }
        private void Bot_ultimo_Click(object sender, EventArgs e)
        {
            bs.Position = bs.Count - 1;
            ContadorRegistros();
            VERIFICAR_DOCUMENTO();
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
            grid_rollos.Columns.Add(col);
        }
        private void AplicarEstilosGridRollos()
        {
            grid_rollos.AutoGenerateColumns = false;
            AGREGAR_COLUMN_GRID("roll", 30, "#", "roll_number");
            AGREGAR_COLUMN_GRID("product_id", 50, "Prod. Id", "product_id");
            AGREGAR_COLUMN_GRID("product_name", 190, "Descripcion Producto", "product_name");
            AGREGAR_COLUMN_GRID("Unique_Code", 65, "Unique Code", "unique_code");
            AGREGAR_COLUMN_GRID("ancho", 52, "Ancho", "width");
            AGREGAR_COLUMN_GRID("largo", 52, "largo", "large");
            AGREGAR_COLUMN_GRID("msi", 40, "Msi", "msi");
            AGREGAR_COLUMN_GRID("splice", 40, "Splice", "splice");
            AGREGAR_COLUMN_GRID("roll_id", 70, "Roll Id.", "Roll_id");
            AGREGAR_COLUMN_GRID("code_personalize", 100, "Code Person.", "code_person");
            DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
            col.Items.Add("Ok");
            col.Items.Add("Rechazado");
            col.Items.Add("Retenido");
            col.Items.Add("Reservado");
            col.Name = "status";
            col.HeaderText = "status";
            col.DataPropertyName = "status";
            col.Width = 80;
            col.FlatStyle = FlatStyle.Popup;
            grid_rollos.Columns.Add(col);
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            CustomerManager custom = new CustomerManager();
            using (SeleccionCustomers miformc = new SeleccionCustomers
            {
                dtcustomer = custom.GetCustomersTableOnly()
            })
            {
                miformc.ShowDialog();
            }
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
            if (txt_numero_oc.Text.Length == 0 || txt_numero_oc.Text == "0")
            {
                MessageBox.Show("introduzca el numero de la orden");
                return;
            }
            if (txt_rollid_1.Text.Length == 0)
            {
                MessageBox.Show("introduzca el numero de Roll ID.");
                return;
            }
            if (txt_product_id.Text.Length == 0)
            {
                MessageBox.Show("introduzca el product id.");
                return;
            }
            if (Convert.ToDouble(txt_cant_cortado.Text) <= 0)
            {
                MessageBox.Show("introduzca la cantidad a producir.");
                return;
            }
            if (Convert.ToDouble(txt_width_cortado.Text) <= 0)
            {
                MessageBox.Show("introduzca el width de la cantidad a producir.");
                return;
            }
            if (Convert.ToDouble(txt_lenght_cortado.Text) <= 0)
            {
                MessageBox.Show("introduzca el lenght de la cantidad a producir.");
                return;
            }
            if (grid_rollos.Rows.Count == 0)
            {
                MessageBox.Show("No puede grabar una orden sin renglones...");
                return;
            }
            //llenar el encabezado de la orden de produccion
            managerorden.Add(CrearObjectOrden(), false);
            //actualizar los rollid.
            managerorden.UpdateRollId(orden.Rollid_1);
            if (txt_rollid_2.Text.Length > 0)
            {
                managerorden.UpdateRollId(orden.Rollid_2);
            }
            chk_process.DataBindings.Add("Checked", bs, "procesado");
            chk_anulado.DataBindings.Add("Checked", bs, "anulada");
            OptionsMenu(1);
            OptionsForm(1);
            EditMode = 0;
        }
        private void ToSaveUpdate()
        {
            // Si hubo modificaciones en los renglones de rollos cortados.
            if (ischanged_rollos)
            {
                managerorden.DeleteRollDetailsOrden(txt_numero_oc.Text);
                managerorden.Update_INSERT(CrearObjectOrden(), false);
            }
            else
            {
                managerorden.Update_Only(CrearObjectOrden(), false);
            }

            EditMode = 0;
            ischanged_rollos = false;
            OptionsMenu(1);
            OptionsForm(1);
        }
        private Orden CrearObjectOrden()
        {
            orden = new Orden
            {
                Numero = (txt_numero_oc.Text),
                Fecha = Convert.ToDateTime(txt_fecha_orden.Text),
                Fecha_produccion = Convert.ToDateTime(txt_fecha_producc.Text),
                Product_id = txt_product_id.Text,
                Rollid_1 = txt_rollid_1.Text.ToString(),
                Width_1 = Convert.ToDecimal(txt_width1_rollid.Text),
                Lenght_1 = Convert.ToDecimal(txt_lenght1_rollid.Text),
                Rollid_2 = txt_rollid_2.Text,
                Width_2 = Convert.ToDecimal(txt_width2_rollid.Text),
                Lenght_2 = Convert.ToDecimal(txt_lenght2_rollid.Text),
                Cant_cortados = Convert.ToInt32(txt_cant_cortado.Text),
                Widht_cortados = Convert.ToDecimal(txt_width_cortado.Text),
                Lenght_cortados = Convert.ToDecimal(txt_lenght_cortado.Text),
                Msi_cortados = Convert.ToDecimal(txt_msi_cortado.Text),
                Anulada = false,
                Procesado = false
            };
            orden.rollos = new List<Roll_Details>();
            for (int fila = 0; fila <= grid_rollos.Rows.Count - 1; fila++)
            {
                Roll_Details rollo_cortado = new Roll_Details
                {
                    Numero_Orden = txt_numero_oc.Text,
                    Roll_number = grid_rollos.Rows[fila].Cells[0].Value.ToString(),
                    Product_id = grid_rollos.Rows[fila].Cells[1].Value.ToString(),
                    Product_name = grid_rollos.Rows[fila].Cells[2].Value.ToString(),
                    Unique_code = grid_rollos.Rows[fila].Cells[3].Value.ToString(),
                    Width = Convert.ToDecimal(grid_rollos.Rows[fila].Cells[4].Value),
                    Large = Convert.ToDecimal(grid_rollos.Rows[fila].Cells[5].Value),
                    Msi = Convert.ToDecimal(grid_rollos.Rows[fila].Cells[6].Value),
                    Splice = Convert.ToInt32(grid_rollos.Rows[fila].Cells[7].Value),
                    Roll_id = grid_rollos.Rows[fila].Cells[8].Value.ToString(),
                    Code_Person = grid_rollos.Rows[fila].Cells[9].Value.ToString(),
                    Status = grid_rollos.Rows[fila].Cells[10].Value.ToString(),
                    Disponible = true
                };
                orden.rollos.Add(rollo_cortado);
            }
            return orden;
        }

        private List<Roll_Details> GENERAR_DETALLE_ROLLOS_CORTADOS()
        {
            List<Roll_Details> rollos = new List<Roll_Details>();
            int code_unique = Convert.ToInt32(configmanager.GetParameterControl("UC"));
            int filas = Convert.ToInt32(txt_cant_cortado.Text);
            for (int j = 0; j < filas; j++)
            {
                Roll_Details item = new Roll_Details
                {
                    Roll_number = (j + 1).ToString(),
                    Fecha = Convert.ToDateTime(txt_fecha_orden.Text),
                    Numero_Orden = txt_numero_oc.Text,
                    Product_id = txt_product_id.Text.ToString(),
                    Product_name = txt_product_name.Text,
                    Unique_code = "RC" + code_unique,
                    Roll_id = txt_rollid_1.Text,
                    Width = Convert.ToDecimal(txt_width_cortado.Text),
                    Large = Convert.ToDecimal(txt_lenght_cortado.Text),
                    Msi = Convert.ToDecimal(txt_msi_cortado.Text),
                    Splice = 0,
                    Code_Person = "N/A",
                    Status = "Ok"
                };
                rollos.Add(item);
                code_unique += 1;
            }
            configmanager.SetParametersControl(code_unique.ToString(), "UC");
            return rollos;
        }

        private void BOT_EXCEL_EXPORT_Click(object sender, EventArgs e)
        {
            string separator = ",";

            using (StreamWriter sr = new StreamWriter(R.PATH_FILES.FILE_TXT_DATA_ETIQUETA))
            {
                foreach (DataGridViewRow row in grid_rollos.Rows)
                {
                    sr.WriteLine(row.Cells[0].Value.ToString() + separator +
                    row.Cells[1].Value.ToString().Trim() + separator +
                    row.Cells[2].Value.ToString() + separator +
                    row.Cells[3].Value.ToString() + separator +
                    Convert.ToString(row.Cells[4].Value).Replace(",", ".") + separator +
                    Convert.ToString(row.Cells[5].Value).Replace(",", ".") + separator +
                    Convert.ToString(row.Cells[6].Value).Replace(",", ".") + separator +
                    row.Cells[7].Value.ToString() + separator +
                    row.Cells[8].Value.ToString() + separator +
                    row.Cells[9].Value.ToString() + separator +
                    row.Cells[10].Value.ToString() + separator +
                    Convert.ToDateTime(txt_fecha_orden.Text).ToShortDateString() + separator +
                    txt_numero_oc.Text);
                }
                MessageBox.Show("se genero la data de etiquetado...");
            }
        }
        private void BOT_BUSCAR_Click(object sender, EventArgs e)
        {
            using (FrmBuscarOrdenes fBuscarOrden = new FrmBuscarOrdenes
            {
                dtordenes = ds.Tables["dtordenes"]
            })
            {
                fBuscarOrden.ShowDialog();
                int itemFound = bs.Find("numero", fBuscarOrden.orden);
                bs.Position = itemFound;
            }
            grid_rollos.DataSource = "";
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
                MessageBox.Show("error al transmitir data a excel. error code:" + ex);
            }

        }
        private void Bot_buscar_rollid1_Click(object sender, EventArgs e)
        {
            CargarRollIDNumber(0);
        }
        private void Bot_buscar_rollid2_Click(object sender, EventArgs e)
        {
            CargarRollIDNumber(1);
        }
        private void CargarRollIDNumber(int state)
        {
            using (FrmBuscarRollid rollid = new FrmBuscarRollid())
            {
                rollid.Dtrollid = managerorden.CargarRollsId();
                rollid.ShowDialog();

                if (state == 0)
                {
                    txt_rollid_1.Text = rollid.GetrollId;
                    txt_width1_rollid.Text = rollid.GetValueWidth;
                    txt_lenght1_rollid.Text = rollid.GetvalueLenght;
                    txt_product_id.Text = rollid.Getproduct_id;
                    txt_product_name.Text = rollid.GetProduct_name;
                }
                else
                {
                    txt_rollid_2.Text = rollid.GetrollId;
                    txt_width2_rollid.Text = rollid.GetValueWidth;
                    txt_lenght2_rollid.Text = rollid.GetvalueLenght;
                }
            }
        }
        private void CALCULAR_MSI()
        {
            if (EditMode != 0 || Convert.ToDouble(txt_lenght_cortado.Text) > 0 ||
                Convert.ToDouble(txt_width_cortado.Text) > 0)
            {
                try
                {
                    double msi = ((Convert.ToDouble(txt_width_cortado.Text)
                            * Convert.ToDouble(txt_lenght_cortado.Text))
                            * R.CONSTANTES.FACTOR_CALCULO_MSI);
                    txt_msi_cortado.Text = msi.ToString();
                }
                catch (Exception)
                {
                    txt_msi_cortado.Text = "0";
                }
            }
        }
        private void Txt_numero_oc_KeyPress(object sender, KeyPressEventArgs e)
        {
            string CaracValid = "0123456789";
            if (e.KeyChar != Convert.ToChar(8) && CaracValid.IndexOf(e.KeyChar) == -1)
            {
                // si no es bakcspace y no es un numero se omite.   
                e.Handled = true;
            }
        }
        private void Txt_cant_cortado_KeyPress(object sender, KeyPressEventArgs e)
        {
            string CaracValid = "0123456789";
            if (e.KeyChar != Convert.ToChar(8) && CaracValid.IndexOf(e.KeyChar) == -1)
            {
                // si no es bakcspace y no es un numero se omite.   
                e.Handled = true;
            }
        }

        private void Txt_width_cortado_KeyPress(object sender, KeyPressEventArgs e)
        {
            string CaracValid = "0123456789.";
            if (e.KeyChar != Convert.ToChar(8) && CaracValid.IndexOf(e.KeyChar) == -1)
            {
                // si no es bakcspace y no es un numero se omite.   
                e.Handled = true;
            }
        }

        private void Txt_lenght_cortado_KeyPress(object sender, KeyPressEventArgs e)
        {
            string CaracValid = "0123456789,.";
            if (e.KeyChar != Convert.ToChar(8) && CaracValid.IndexOf(e.KeyChar) == -1)
            {
                // si no es bakcspace y no es un numero se omite.   
                e.Handled = true;
            }
        }

        private void Txt_width_cortado_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_width_cortado.Text == "")
            {
                return;
            }
            if (Convert.ToDouble(txt_width_cortado.Text) > 0 && Convert.ToDouble(txt_lenght_cortado.Text) > 0)
            {
                CALCULAR_MSI();
               
            }
        }

        private void Txt_lenght_cortado_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_lenght_cortado.Text == "")
            {
                return;
            }
            if (Convert.ToDouble(txt_width_cortado.Text) > 0 && Convert.ToDouble(txt_lenght_cortado.Text) > 0)
            {
                CALCULAR_MSI();
                
            }
        }
        private void Txt_numero_oc_Validating(object sender, CancelEventArgs e)
        {
            if (managerorden.OrderExiste(txt_numero_oc.Text) && EditMode == 1)
            {
                MessageBox.Show("La Orden produccion : " + txt_numero_oc.Text + " ya existe.");
                txt_numero_oc.Text = "";
            }
        }
        private void Grid_rollos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 || e.ColumnIndex == 5)
            {
                CALCULAR_MSI_RENGLON(e.RowIndex);
            }
        }
        private void CALCULAR_MSI_RENGLON(int fila)
        {
            if (EditMode != 0 || Convert.ToDouble(grid_rollos.Rows[fila].Cells["largo"].Value) > 0 ||
                 Convert.ToDouble(grid_rollos.Rows[fila].Cells["ancho"].Value) > 0)
            {
                try
                {
                    double msi = ((Convert.ToDouble(grid_rollos.Rows[fila].Cells["ancho"].Value)
                            * Convert.ToDouble(grid_rollos.Rows[fila].Cells["largo"].Value))
                            * R.CONSTANTES.FACTOR_CALCULO_MSI);
                    grid_rollos.Rows[fila].Cells["msi"].Value = msi.ToString();
                }
                catch (Exception)
                {


                    grid_rollos.Rows[fila].Cells["msi"].Value = "0";
                }


            }
        }
        private void Btn_eliminar_renglon_Click(object sender, EventArgs e)
        {
            //ACTUALIZAR LA INTERFAZ GRAFICA.

            string rc = ""; ;
            foreach (DataGridViewRow item in this.grid_rollos.SelectedRows)
            {
                rc = item.Cells["unique_code"].Value.ToString();
                grid_rollos.Rows.RemoveAt(item.Index);
            }
            //ACTUALIZAR LA BASE DE DATOS. 
            managerorden.DeleteUniqueCode(rc);

        }
        private void Bot_procesar_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Esta seguro de procesar este documento (S/N)?",
                 "Advertencia", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    managerorden.ProcesarOrden(txt_numero_oc.Text.Trim());
                    chk_process.Checked = true;
                    VERIFICAR_DOCUMENTO();
                    break;
                case DialogResult.No:
                    break;
            }
        }
        private void Bot_Anular_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Esta seguro de Anular este documento (S/N)?",
                "Advertencia", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    managerorden.AnularOrden(txt_numero_oc.Text.Trim());
                    chk_anulado.Checked = true;
                    VERIFICAR_DOCUMENTO();
                    break;
                case DialogResult.No:
                    break;
            }
        }
        private void Txt_cant_cortado_Validating(object sender, CancelEventArgs e)
        {
            if (txt_cant_cortado.Text == string.Empty)
            {
                e.Cancel = true;
            }
        }
        private void Bot_generar_rollos_cortados_Click(object sender, EventArgs e)
        {

            if (EditMode == 2 || grid_rollos.Rows.Count > 0)
            {
                try
                {

                    if (modcan_cortado == txt_cant_cortado.Text &&
                        modproduct_id == txt_product_id.Text &&
                        modwidth == txt_width_cortado.Text)
                    {
                        MessageBox.Show("no ha cambiado los datos de la orden");
                        return;
                    }

                    //borrar los todos registros
                    List<DataRow> toDelete = new List<DataRow>();
                    foreach (DataGridViewRow row in grid_rollos.Rows)
                    {
                        toDelete.Add(((DataRowView)row.DataBoundItem).Row);
                    }
                    toDelete.ForEach(row => row.Delete());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            List<Roll_Details> lista = GENERAR_DETALLE_ROLLOS_CORTADOS();
            //Agregar encabezado a la orden.
            ParentRow.BeginEdit();
            ParentRow["numero"] = txt_numero_oc.Text;
            ParentRow["fecha"] = txt_fecha_orden.Text;
            ParentRow["fecha_produccion"] = txt_fecha_producc.Text;
            ParentRow["rollid_1"] = txt_rollid_1.Text;
            ParentRow["width_1"] = txt_width1_rollid.Text;
            ParentRow["lenght_1"] = txt_lenght1_rollid.Text;
            ParentRow["rollid_2"] = txt_rollid_2.Text;
            ParentRow["width_2"] = txt_width2_rollid.Text;
            ParentRow["lenght_2"] = txt_lenght2_rollid.Text;
            ParentRow["product_id"] = txt_product_id.Text;
            //ParentRow["product_name"] = txt_product_name.Text;
            ParentRow["cant_cortado"] = txt_cant_cortado.Text;
            ParentRow["width_cortado"] = txt_width_cortado.Text;
            ParentRow["lenght_cortado"] = txt_lenght_cortado.Text;
            ParentRow["anulada"] = false;
            ParentRow["procesado"] = false;
            ParentRow.EndEdit();
            //Agregar el detalle de la Orden.
            DataRowView ChildRows;
            string CodeRC = managerorden.GetCodeRC(txt_product_id.Text.Trim());
            foreach (Roll_Details item in lista)
            {
                ChildRows = (DataRowView)bsdetalle.AddNew();
                ChildRows.BeginEdit();
                ChildRows["numero"] = item.Numero_Orden;
                ChildRows["roll_number"] = item.Roll_number;
                ChildRows["product_id"] = CodeRC;
                ChildRows["product_name"] = item.Product_name;
                ChildRows["unique_code"] = item.Unique_code;
                ChildRows["width"] = double.Parse(item.Width.ToString(), CultureInfo.InvariantCulture);
                ChildRows["large"] = item.Large;
                ChildRows["Msi"] = item.Msi;
                ChildRows["Splice"] = item.Splice;
                ChildRows["Roll_id"] = item.Roll_id;
                ChildRows["Code_Person"] = item.Code_Person;
                ChildRows["Status"] = item.Status;
                ChildRows.Row.SetParentRow(ParentRow.Row);
                ChildRows.EndEdit();
            }
            bs.EndEdit();
            if (EditMode == 1)
            {
                bs.Position = bs.Count - 1;
                bot_generar_rollos_cortados.Enabled = false;
            }
            ischanged_rollos = true;
            CALCULAR_MSI();
        }
        private void Bot_modificar_Click(object sender, EventArgs e)
        {
            EditMode = 2;
            modproduct_id = txt_product_id.Text;
            modcan_cortado = txt_cant_cortado.Text;
            modwidth = txt_width_cortado.Text;
            modlenght = txt_lenght_cortado.Text;
            modmsi = txt_msi_cortado.Text;
            ParentRow = (DataRowView)bs.Current;
            OptionsMenu(0);
            OptionsForm(2);
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            CALCULAR_RENDIMIENTO_MASTER();
        }

        private void txt_tabla1_TextChanged(object sender, EventArgs e)
        {

        }

        private void VERIFICAR_DOCUMENTO()
        {
            if (chk_process.Checked || chk_anulado.Checked)
            {
                DOCUMENTO_CERRADO();
            }
            else
            {
                DOCUMENTO_ABIERTO();
            }
        }
        private void DOCUMENTO_CERRADO()
        {
            bot_modificar.Enabled = false;
            Bot_procesar.Enabled = false;
            Bot_Anular.Enabled = false;
            BOT_EXCEL_EXPORT.Enabled = false;
        }
        private void DOCUMENTO_ABIERTO()
        {
            bot_modificar.Enabled = true;
            Bot_procesar.Enabled = true;
            Bot_Anular.Enabled = true;
            BOT_EXCEL_EXPORT.Enabled = true;
        }
        private void CALCULAR_RENDIMIENTO_MASTER()
        {
            txt_tabla1.Text = "";
            txt_width_dif.Text = "";
            txt_lenght_dif.Text = "";
            txt_msi_dif.Text = "";
            txt_vueltas_real.Text = "";
            txt_sobran.Text = "";
            txt_rollos_real.Text = "";
            //VALIDAR LOS PAERAMETROS PARA EL CALCULO.


            //CALCULAR EL RENDIMIENTO DEL MASTER.

            Double rollosxmaster = Math.Round(Convert.ToDouble(txt_width1_rollid.Text) /
                Convert.ToDouble(txt_width_cortado.Text),2);

            Double nrovueltas = Math.Round(Convert.ToDouble(txt_lenght1_rollid.Text) /
                Convert.ToDouble(txt_lenght_cortado.Text),2);

            double cant = 0;

            if (chk_todo_master.Checked == false)
            {
                cant = Math.Truncate(rollosxmaster) * Math.Truncate(nrovueltas);
            }
            else
            {

            }

            if (cant >= Convert.ToDouble(txt_cant_cortado.Text))
            {
                //hay capacidad para producir lo planificado.
                chk_capacity.Checked = true;
                bot_generar_rollos_cortados.Enabled = true;

                //rollos x master a lo ancho y numero de vueltas.
                int rolloMax = Convert.ToInt32(Math.Truncate(rollosxmaster));
                int vueltaMax =  Convert.ToInt16(Math.Truncate(nrovueltas));

                //crear tabla de las vueltas
                List<TablaMaster> tabla = new List<TablaMaster>();
                int lim1 = 1;
                int lim2 = rolloMax;
                for (int i=0; i < vueltaMax; i++) 
                {
                    TablaMaster fila = new TablaMaster();
                    fila.L1 = lim1;
                    fila.L2 = lim2;
                    fila.Vuelta = (i + 1);
                    tabla.Add(fila);
                    txt_tabla1.Text = txt_tabla1.Text + lim1 + " - " + lim2 + " - " + (i + 1).ToString() + Environment.NewLine;
                    lim1 += rolloMax;
                    lim2 += rolloMax;
      
                }
                //calculo las vueltas reales
                foreach (TablaMaster item in tabla) 
                {
                    if (Convert.ToDouble(txt_cant_cortado.Text) >= item.L1 && Convert.ToDouble(txt_cant_cortado.Text) <= item.L2) 
                    {
                        txt_vueltas_real.Text = item.Vuelta.ToString();
                        txt_sobran.Text = (Convert.ToInt16(item.L2)-Convert.ToInt16(txt_cant_cortado.Text)).ToString();
                    }
                }

                txt_rollos_real.Text = (Convert.ToDouble(txt_vueltas_real.Text) * rolloMax).ToString();

                //calculo del master sobrante.
                double width_dif = Convert.ToDouble(txt_width1_rollid.Text) - 
                    (rolloMax * Convert.ToInt16(txt_width_cortado.Text));

                double lenght_dif = Convert.ToDouble(txt_lenght1_rollid.Text) -
                    (Convert.ToDouble(txt_lenght_cortado.Text) * Convert.ToInt16(txt_vueltas_real.Text));

                double msi_dif = (width_dif * lenght_dif) * R.CONSTANTES.FACTOR_CALCULO_MSI;



                txt_width_dif.Text = width_dif.ToString();
                txt_lenght_dif.Text = lenght_dif.ToString();
                txt_msi_dif.Text = msi_dif.ToString();


            }
            else
            {
                //no hay capacidad para producir lo planificado.
                chk_capacity.Checked = false;
                bot_generar_rollos_cortados.Enabled = false;
            }





            txt_rollosxmaster.Text = rollosxmaster.ToString();
            txt_numero_vueltas.Text = nrovueltas.ToString();
            txt_cant_master1.Text = cant.ToString();



        }
    }
    public class TablaMaster
    {
        public int L1 { get; set; }
        public int L2 { get; set; }
        public int Vuelta { get; set; }
    }
}
