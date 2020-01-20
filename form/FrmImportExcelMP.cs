using System;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using RitramaAPP.Clases;
using System.Globalization;

namespace RitramaAPP.form
{
    public partial class FrmImportExcelMP : Form
    {
        public FrmImportExcelMP()
        {
            InitializeComponent();
        }
       
        string fileName;
        OpenFileDialog openFileDialog1;
        DataTable tbContainer;
        string strConn;
        DataView dv = new DataView();
        public List<ClassRecepcion> lista = new List<ClassRecepcion>();
        readonly RecepcionManager manager = new RecepcionManager();
        readonly ProduccionManager managerorden = new ProduccionManager();
        string filtro_codigo = "";
        string filtro_name = "";
        string filtro_id = "";

        private void FrmImportExcelMP_Load(object sender, EventArgs e)
        {
            
        }
        private void Bot_import_data_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();  //crea un Objeto openfileDialog. 
            openFileDialog1.Filter = "XML Files (*.xml; *.xls; *.xlsx; *.xlsm; *.xlsb) |*.xml; *.xls; *.xlsx; *.xlsm; *.xlsb";//open file format define Excel Files(.xls)|*.xls| Excel Files(.xlsx)|*.xlsx| 
            openFileDialog1.FilterIndex = 3;
            openFileDialog1.Multiselect = false;        // no permite seleccionar multiples archivos
            openFileDialog1.Title = "Seleccione la hoja de excel a Exportar";   // define el nombre de la ventana
            openFileDialog1.InitialDirectory = @"Desktop"; // define el directorio inicial
            if (openFileDialog1.ShowDialog() == DialogResult.OK)        //executing when file open
            {
                string pathName = openFileDialog1.FileName;
                fileName = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                tbContainer = new System.Data.DataTable();
                strConn = string.Empty;
                string sheetName = fileName;

                FileInfo file = new FileInfo(pathName);
                if (!file.Exists) { throw new Exception("Error, file doesn't exists!"); }
                string extension = file.Extension;
                switch (extension)
                {
                    case ".xls":
                        strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathName + ";Extended Properties='Excel 8.0;HDR=No;IMEX=1;'";
                        break;
                    case ".xlsx":
                        strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathName + ";Extended Properties='Excel 12.0;HDR=No;IMEX=1;'";
                        break;
                    default:
                        strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathName + ";Extended Properties='Excel 8.0;HDR=No;IMEX=1;'";
                        break;
                }
                TXT_PATH_FILENAME.Text = file.FullName;
                TXT_NOMBRE_HOJA.Text = "Hoja1";
            }
        }
        private void LOAD_DATA_EXCEL() 
        {
            try
            {          
                OleDbConnection cnnxls = new OleDbConnection(strConn);
                OleDbCommand comando = new OleDbCommand("select * from ["+ TXT_NOMBRE_HOJA.Text.Trim()  + "$]", cnnxls);
                OleDbDataAdapter adapter = new OleDbDataAdapter(comando);
                adapter.Fill(tbContainer);
            DataRow dr = tbContainer.Rows[0];
            dr.Delete();
            tbContainer.AcceptChanges();
            tbContainer.Columns.Add("Fila",typeof(System.Int32));
                for(int i = 0; i <= tbContainer.Rows.Count-1; i++) 
                {
                    tbContainer.Rows[i]["Fila"] = i + 2;
                }
                dv = tbContainer.DefaultView;
                GRID_IMPORT.DataSource = dv;

                if (RA_MASTERS.Checked) 
                {
                    LOADATA_MASTERS();
                }
                if (RA_CORTADOS.Checked)
                {
                    LOADATA_CORTADOS();
                }
                GRID_IMPORT.Columns["Fila"].DisplayIndex = 0;
                TXT_ROWS.Text = (tbContainer.Rows.Count).ToString();
                // si la busqueda es por rollo cortado
            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }
        }
        private void BOT_LOAD_DATA_Click(object sender, EventArgs e)
        {
            LOAD_DATA_EXCEL();
        }
        private void LOADATA_MASTERS() 
        {

            GRID_IMPORT.Columns[0].HeaderText = "Factura";
            GRID_IMPORT.Columns[1].HeaderText = "Fecha Llegada";
            GRID_IMPORT.Columns[2].HeaderText = "Codigo";
            GRID_IMPORT.Columns[3].HeaderText = "Descripcion";
            GRID_IMPORT.Columns[4].HeaderText = "ROLL ID";
            GRID_IMPORT.Columns[5].HeaderText = "Fecha Produccion";
            GRID_IMPORT.Columns[6].HeaderText = "# Rollo";
            GRID_IMPORT.Columns[7].HeaderText = "Ancho mm & Pulg.";
            GRID_IMPORT.Columns[8].HeaderText = "ML & Pies Lineales";
            GRID_IMPORT.Columns[9].HeaderText = "# Empalmes";
            GRID_IMPORT.Columns[10].HeaderText = "Inventario";
            GRID_IMPORT.Columns[11].HeaderText = "Fecha Salida";
            GRID_IMPORT.Columns[12].HeaderText = "Doc. Salida OC";
            GRID_IMPORT.Columns[13].HeaderText = "Notas";
            GRID_IMPORT.Columns[14].HeaderText = "Kilo Neto";
            GRID_IMPORT.Columns[15].HeaderText = "Kilo Bruto";
            GRID_IMPORT.Columns[16].HeaderText = "Almacen";
            GRID_IMPORT.Columns[17].HeaderText = "Fila";
            GRID_IMPORT.Columns[18].HeaderText = "Visto";
            GRID_IMPORT.Columns[19].HeaderText = "M2";
            GRID_IMPORT.Columns[20].HeaderText = "Count";
        }
        private void LOADATA_CORTADOS() 
        {
            GRID_IMPORT.Columns["F1"].HeaderText = "Fecha OC.";
            GRID_IMPORT.Columns["F2"].HeaderText = "OC.";
            GRID_IMPORT.Columns["F3"].HeaderText = "# Rollo.";
            GRID_IMPORT.Columns["F4"].HeaderText = "Codigo";
            GRID_IMPORT.Columns["F5"].HeaderText = "Nombre del Producto";
            GRID_IMPORT.Columns["F6"].HeaderText = "Roll. ID";
            GRID_IMPORT.Columns["F7"].HeaderText = "Ancho [Pulg.]";
            GRID_IMPORT.Columns["F8"].HeaderText = "Largo [Pies]";
            GRID_IMPORT.Columns["F9"].HeaderText = "Msi.";
            GRID_IMPORT.Columns["F10"].HeaderText = "# Empalmes";
            GRID_IMPORT.Columns["F11"].HeaderText = "Code Perso.";
            GRID_IMPORT.Columns["F12"].HeaderText = "Codigo Unico";
            GRID_IMPORT.Columns["F13"].HeaderText = "Ratio Kilos";
            GRID_IMPORT.Columns["F14"].HeaderText = "Seccion";
            GRID_IMPORT.Columns["F15"].HeaderText = "Rack";
            GRID_IMPORT.Columns["F16"].HeaderText = "Inventario";
            GRID_IMPORT.Columns["F17"].HeaderText = "Fecha Salida";
            GRID_IMPORT.Columns["F18"].HeaderText = "Doc. Salida";
            GRID_IMPORT.Columns["F19"].HeaderText = "Cliente";
            GRID_IMPORT.Columns["F20"].HeaderText = "Comentario";
        }
        private void DEBUG_MASTERS()
        {
            double numero = 0;
            string cadena = "";
            string numerostr = "";
            foreach (DataRow row in tbContainer.Rows)
            {
                //Columna de Ancho.
                cadena = Convert.ToString(row["F8"]);
                numerostr = "";
                foreach (char str in cadena)
                {
                    if (!char.IsLetter(str))
                        numerostr += str.ToString();
                }
                if (Convert.ToString(row["F8"]).Contains("mm"))
                {
                    numero = Math.Round(double.Parse(numerostr,
                         CultureInfo.InvariantCulture)
                        * R.CONSTANTES.FACTOR_MM_PULGADAS, 4,
                        MidpointRounding.AwayFromZero);
                }
                else
                {
                    numero = double.Parse(numerostr,
                         CultureInfo.InvariantCulture);
                }
                row["F8"] = Convert.ToString(numero);
                GRID_IMPORT.Columns[7].HeaderText = "Ancho [PULGADAS]";

                //Columna de Largo.
                cadena = Convert.ToString(row["F9"]);
                numerostr = "";
                foreach (char str in cadena)
                {
                    if (!char.IsLetter(str))
                        numerostr += str.ToString();
                }
                if (Convert.ToString(row["F9"]).Contains("Mts"))
                {

                    numero = Math.Round(double.Parse(numerostr,
                         CultureInfo.InvariantCulture)
                        * R.CONSTANTES.FACTOR_METROS_PIES, 4,
                        MidpointRounding.AwayFromZero);
                }
                else
                {
                    numero = double.Parse(numerostr,
                         CultureInfo.InvariantCulture);
                }
                row["F9"] = Convert.ToString(numero);
                GRID_IMPORT.Columns[8].HeaderText = "Largo [PIES]";

                //Columna splice.
                if (Convert.ToString(row["F10"]) == "")
                {
                    row["F10"] = 0;
                }
            }
            tbContainer.AcceptChanges();
            MessageBox.Show("Proceso realizado con exito.");
            TXT_LOG_PROCESS.Text += "Conversiones de Ancho y Largo realizadas con exito...";
        }
        private void DEBUG_CORTADOS() 
        {
        
        }
        private void SAVEDATA_MASTERS() 
        {
            int ord = 1;
            foreach (DataGridViewRow row in GRID_IMPORT.Rows)
            {
                ClassRecepcion data = new ClassRecepcion
                {
                    Orden = ord.ToString(),
                    Embarque = "1",
                    Fecha_recepcion = DateTime.Today,
                    Fecha_produccion = DateTime.Today,
                    Fecha_reg = DateTime.Today,
                    Hora_reg = DateTime.Now.ToShortTimeString(),
                    Roll_ID = Convert.ToString(row.Cells["F5"].Value),
                    Supply_Id = "999",
                    Part_Number = Convert.ToString(row.Cells["F3"].Value),
                    Master = true,
                    Resma = false,
                    Graphics = false,
                    Palet_number = "0",
                    Palet_cant = 0,
                    Palet_paginas = 0,
                    Width = double.Parse(Convert.ToString(row.Cells["F8"].Value),
                    System.Globalization.NumberStyles.AllowDecimalPoint),
                    Lenght = Convert.ToDouble(row.Cells["F9"].Value),
                    Width_metros = Convert.ToDouble(row.Cells["F8"].Value) *
                    R.CONSTANTES.FACTOR_PULGADAS_METROS,
                    Lenght_metros = Convert.ToDouble(row.Cells["F9"].Value) *
                    R.CONSTANTES.FACTOR_PIES_METROS,
                    Splice = Convert.ToInt16(row.Cells["F10"].Value),
                    Core = 0,
                    Ubicacion = "",
                    Anulado = false,
                    Disponible = true
                };
                ord++;
                lista.Add(data);
            }
            foreach (ClassRecepcion item in lista)
            {
                manager.Add(item, false);
            }
            MessageBox.Show("Se enviaron los datos correctamente...");
        }
        private void SAVEDATA_CORTADOS()
        {
            int OrdenCorte = 1;
            Orden ocorte = new Orden
            {
                Numero = OrdenCorte.ToString(),
                Fecha = DateTime.Today,
                Fecha_produccion = DateTime.Today,
                Product_id = Convert.ToString(GRID_IMPORT.Rows[0].Cells["F4"].Value),
                Rollid_1 = "1",
                Rollid_2 = "2",
                Width_1 = 0,
                Width_2 = 0,
                Lenght_1 = 0,
                Rest1_width = 0,
                Rest2_width = 0,
                Rest1_lenght = 0,
                Rest2_lenght = 0,
                Cantidad_Rollos = 0,
                Cantidad_Rollos2 = 0,
                Util1_real_Lenght = 0,
                Util2_real_Lenght = 0,
                Util1_Real_Width = 0,
                Util2_Real_Width = 0,
                Anulada = false,
                Procesado = false,
                Status = 0
            };
            ocorte.rollos = new List<Roll_Details>();
            ocorte.Cortes = new List<Corte>();
            Corte c = new Corte();
            c.Num = 0;
            c.Msi = 0;
            c.Width = 0;
            c.Lenght = 0;
            c.Orden = Convert.ToString(OrdenCorte);
            ocorte.Cortes.Add(c);
            int fil = 1;
            foreach (DataGridViewRow row in GRID_IMPORT.Rows)
            {
                Roll_Details data = new Roll_Details
                {
                    Fecha = DateTime.Today,
                    Numero_Orden = Convert.ToString(OrdenCorte),
                    Product_id = "0" + Convert.ToString(row.Cells["F4"].Value),
                    Product_name = Convert.ToString(GRID_IMPORT.Rows[fil - 1].Cells["F5"].Value),
                    Roll_number = Convert.ToString(fil),
                    Code_Person = Convert.ToString(row.Cells["F11"].Value),
                    Unique_code = Convert.ToString(row.Cells["F12"].Value),
                    Width = Convert.ToDecimal(row.Cells["F7"].Value),
                    Large = Convert.ToDecimal(row.Cells["F8"].Value),
                    Msi = Convert.ToDecimal(row.Cells["F9"].Value),
                    Roll_id = Convert.ToString(row.Cells["F6"].Value),
                    Splice = Convert.ToInt16(row.Cells["F10"].Value),
                    Status = "Ok",
                    Disponible = true
                };
                fil += 1;
                ocorte.rollos.Add(data);
               
            }
            managerorden.Add(ocorte, false);
            MessageBox.Show("se guardaron los datos correctamente");
        }
        private void TXT_BUSCAR_TextChanged(object sender, EventArgs e)
        {
            
            if (RA_MASTERS.Checked) 
            {
                filtro_codigo = "F3 LIKE '%" + this.TXT_BUSCAR.Text + "%'";
                filtro_name = "F4 LIKE '%" + this.TXT_BUSCAR.Text + "%'";
                filtro_id = "F5 LIKE '%" + this.TXT_BUSCAR.Text + "%'";
            }
            if (RA_CORTADOS.Checked)
            {
                filtro_codigo = "F4 LIKE '%" + this.TXT_BUSCAR.Text + "%'";
                filtro_name = "F5 LIKE '%" + this.TXT_BUSCAR.Text + "%'";
                filtro_id = "F6 LIKE '%" + this.TXT_BUSCAR.Text + "%'";
            }

            if (RA_CODIGO.Checked)
            {
                dv.RowFilter = filtro_codigo;
            }
            if (RA_PRODUCTNAME.Checked)
            {
                dv.RowFilter = filtro_name;
            }
            if (RA_ROLLID.Checked)
            {
                dv.RowFilter = filtro_id;
            }

            ROWS_FOUND.Text = Convert.ToString(dv.Count) + " registros encontrados.";
        }

        private void GRID_IMPORT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bot_borrar_data_Click(object sender, EventArgs e)
        {
            GRID_IMPORT.DataSource = "";
        }

        private void bot_convertir_Click(object sender, EventArgs e)
        {
            if (RA_MASTERS.Checked) 
            {
                DEBUG_MASTERS();
            }
            if (RA_CORTADOS.Checked) 
            {
                DEBUG_CORTADOS();
            }
           
        }
        
        private void BOT_SEND_DATA_Click(object sender, EventArgs e)
        {
            if (RA_MASTERS.Checked) 
            {
                SAVEDATA_MASTERS();
            }
            if (RA_CORTADOS.Checked) 
            {
                SAVEDATA_CORTADOS();
            }
        }
    }
}
