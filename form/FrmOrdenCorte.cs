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
        readonly OrdenCorteManager managerorden = new OrdenCorteManager();
        readonly ConfigManager configmanager = new ConfigManager();
        readonly BindingSource bs = new BindingSource();
        readonly BindingSource bsdetalle = new BindingSource();
        readonly System.Data.DataTable dtproducts = new System.Data.DataTable();
        DataSet ds = new DataSet();
        private DataRowView ParentRow;
        readonly double factor = 0.012;
        int EditMode = 0;
   
        private void FrmOrdenCorte_Load(object sender, EventArgs e)
        {
            AplicarEstilosGridRollos();
            ds = managerorden.ds;
            bs.DataSource = ds;
            bs.DataMember = "dtordenes";
            txt_numero_oc.DataBindings.Add("text",bs,"numero");
            txt_fecha_orden.DataBindings.Add("text", bs, "fecha");
            txt_fecha_producc.DataBindings.Add("text", bs, "fecha_produccion");
            txt_rollid_1.DataBindings.Add("text", bs, "rollid_1");
            txt_width1_rollid.DataBindings.Add("text",bs,"width_1");
            txt_lenght1_rollid.DataBindings.Add("text",bs,"lenght_1");
            txt_rollid_2.DataBindings.Add("text", bs, "rollid_2");
            txt_width2_rollid.DataBindings.Add("text", bs, "width_2");
            txt_lenght2_rollid.DataBindings.Add("text", bs, "lenght_2");
            txt_product_id.DataBindings.Add("text", bs, "product_id");
            txt_product_name.DataBindings.Add("text", bs, "product_name");
            txt_cant_cortado.DataBindings.Add("text", bs, "cant_cortado");
            txt_width_cortado.DataBindings.Add("text",bs,"width_cortado");
            txt_lenght_cortado.DataBindings.Add("text",bs,"lenght_cortado");
            //binding del detalle
            bsdetalle.DataSource = bs;
            bsdetalle.DataMember = "FK_ORDEN_DETAILS";
            grid_rollos.DataSource = bsdetalle;
        }
        private void BOT_NUEVO_Click(object sender, EventArgs e)
        {
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
            ParentRow.EndEdit();
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
                    txt_msi_cortado.ReadOnly = false;
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
                    bot_buscar_rollid1.Enabled = false;
                    bot_buscar_rollid2.Enabled = false;
                    bot_generar_rollos_cortados.Enabled = false;
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
                    break;
            }
        }
        private void ContadorRegistros()
        {
            contador.Text = "Documento :" + (bs.Position + 1).ToString() +"/"+ bs.Count.ToString();
        }
        private void Bot_siguiente_Click(object sender, EventArgs e)
        {
            bs.Position += 1;
            ContadorRegistros();
        }

        private void Bot_anterior_Click(object sender, EventArgs e)
        {
            bs.Position -= 1;
            ContadorRegistros();
        }

        private void Bot_primero_Click(object sender, EventArgs e)
        {
            bs.Position = 0;
            ContadorRegistros();
        }

        private void Bot_ultimo_Click(object sender, EventArgs e)
        {
            bs.Position = bs.Count - 1;
            ContadorRegistros();
        }
        private void AGREGAR_COLUMN_GRID(string name,int size,string title,string field_bd) 
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
            col.Items.Add("Detalle");
            col.Items.Add("Rechazado");
            col.Name = "status";
            col.HeaderText="status";
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
        private void ToSaveUpdate() 
        {
            EditMode = 0;
        }
        private void ToSaveAdd()
        {
            //validar el formulario

            //llenar el encabezado de la orden de produccion
            Orden orden = new Orden
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
                msi_cortados = Convert.ToDecimal(txt_msi_cortado.Text),
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
                };
                orden.rollos.Add(rollo_cortado);
            }
            managerorden.Add(orden, false);
            OptionsMenu(1);
            OptionsForm(1);
            EditMode = 0;
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
                    Code_Person = "XC80RP3000WG",
                    Status ="Ok"
                };
                rollos.Add(item);
                code_unique += 1;
            }
            configmanager.SetParametersControl(code_unique.ToString(),"UC");
            return rollos;
        }

        private void BOT_EXCEL_EXPORT_Click(object sender, EventArgs e)
        {
            ExportDatatoExcel();
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
                MessageBox.Show("error al transmitir data a excel. error code:"+ex);
            }
            
        }
        private void Bot_buscar_rollid1_Click(object sender, EventArgs e)
        {
            using (FrmBuscarRollid rollid = new FrmBuscarRollid())
            {
                rollid.Dtrollid = ds.Tables["dtrollid"]; 
                rollid.ShowDialog();
                txt_rollid_1.Text = rollid.GetrollId;
                txt_width1_rollid.Text = rollid.GetValueWidth;
                txt_lenght1_rollid.Text = rollid.GetvalueLenght;
                txt_product_id.Text = rollid.Getproduct_id;
                txt_product_name.Text = rollid.GetProduct_name;
            }
        }
        private void Bot_buscar_rollid2_Click(object sender, EventArgs e)
        {
            using (FrmBuscarRollid rollid = new FrmBuscarRollid())
            {
                rollid.Dtrollid = ds.Tables["dtrollid"];
                rollid.ShowDialog();
                txt_rollid_2.Text = rollid.GetrollId;
                txt_width2_rollid.Text = rollid.GetValueWidth;
                txt_lenght2_rollid.Text = rollid.GetvalueLenght;
            }
        }
        private void Txt_lenght_cortado_TextChanged(object sender, EventArgs e)
        {
            CALCULAR_MSI();
        }
        private void CALCULAR_MSI() 
        {
            if (EditMode != 0) 
            {
                if (txt_lenght_cortado.Text != string.Empty)
                {
                    double msi = ((Convert.ToDouble(txt_width_cortado.Text)
                            * Convert.ToDouble(txt_lenght_cortado.Text)) * factor);
                    txt_msi_cortado.Text = msi.ToString();
                }
            }
        }
        private void Txt_width_cortado_TextChanged(object sender, EventArgs e)
        {
            CALCULAR_MSI();
        }

        private void Bot_generar_rollos_cortados_Click(object sender, EventArgs e)
        {
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
            DataRowView ChildRows; 
            foreach (Roll_Details item in lista) 
            {
                ChildRows = (DataRowView)bsdetalle.AddNew();
                ChildRows.BeginEdit();
                ChildRows["numero"] = item.Numero_Orden;
                ChildRows["roll_number"] = item.Roll_number;
                ChildRows["product_id"] = item.Product_id;
                ChildRows["product_name"] = item.Product_name;
                ChildRows["unique_code"] = item.Unique_code;
                ChildRows["width"] = item.Width;
                ChildRows["large"] = item.Large;
                ChildRows["Msi"] = item.Msi;
                ChildRows["Splice"] = item.Splice;
                ChildRows["Roll_id"] = item.Roll_id;
                ChildRows["Code_Person"] = item.Code_Person;
                ChildRows["Status"] = item.Status;
                ChildRows.Row.SetParentRow(ParentRow.Row);
                ChildRows.EndEdit();
            }
            bs.Position = bs.Count - 1;
            bot_generar_rollos_cortados.Enabled = false;
        }
        private void Bot_modificar_Click(object sender, EventArgs e)
        {

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
    }
}
