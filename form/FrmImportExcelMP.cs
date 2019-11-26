using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace RitramaAPP.form
{
    public partial class FrmImportExcelMP : Form
    {
        public FrmImportExcelMP()
        {
            InitializeComponent();
        }

        private void FrmImportExcelMP_Load(object sender, EventArgs e)
        {
            GRID_IMPORT.AutoGenerateColumns = false;
            AGREGAR_COLUMN_GRID("embarque", 60, "Numero Embarque", "embarque", GRID_IMPORT);
            AGREGAR_COLUMN_GRID("orden", 60, "Orden", "orden", GRID_IMPORT);
            AGREGAR_COLUMN_GRID("cantidad", 60, "Cantidad", "", GRID_IMPORT);
            AGREGAR_COLUMN_GRID("unidad", 60, "Unidad", "", GRID_IMPORT);
            AGREGAR_COLUMN_GRID("fecha", 60, "Fecha de Recepcion", "fecha_recepcion", GRID_IMPORT);
            AGREGAR_COLUMN_GRID("rollid", 60, "Roll Id", "Roll_ID", GRID_IMPORT);
            AGREGAR_COLUMN_GRID("id_proveedor", 60, "Proveedor Id.", "Supply_Id", GRID_IMPORT);
            AGREGAR_COLUMN_GRID("proveedor_name", 120, "Nombre del Proveedor", "SupplyName", GRID_IMPORT);
            AGREGAR_COLUMN_GRID("product_id", 60, "Product Id.", "Part_Number", GRID_IMPORT);
            AGREGAR_COLUMN_GRID("product_name", 120, "Nombre del Producto", "ProductName", GRID_IMPORT);
            AGREGAR_COLUMN_GRID("width", 60, "Width", "width", GRID_IMPORT);
            AGREGAR_COLUMN_GRID("lenght", 60, "Lenght", "lenght", GRID_IMPORT);
            AGREGAR_COLUMN_GRID("splice", 60, "Splice", "splice", GRID_IMPORT);
            AGREGAR_COLUMN_GRID("core", 60, "Core", "core", GRID_IMPORT);
            AGREGAR_COLUMN_GRID("numpalet", 60, "Numero de Palet", "Palet_cant", GRID_IMPORT);
            AGREGAR_COLUMN_GRID("cantidad", 60, "Cantidad Recibida", "Palet_paginas", GRID_IMPORT);
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

        private void bot_import_data_Click(object sender, EventArgs e)
        {
            IMPORT_DATA_EXCEL();
        }

        private void IMPORT_DATA_EXCEL()
        {
            try
            {

                Microsoft.Office.Interop.Excel.Application oExcel = null;
                Workbook wb = null;
                Worksheet sheet = null;
                oExcel = new Microsoft.Office.Interop.Excel.Application();
                string filePath = Path.GetFullPath(R.PATH_FILES.PATH_DATA_IMPORT_EXCEL_RECEPCIONES + TXT_PATH.Text + ".xlsx");
                //oExcel.Visible = true;
                wb = oExcel.Workbooks.Open(filePath);
                sheet = wb.Worksheets[1];
                Range range = sheet.UsedRange;
                int rw = range.Rows.Count;
                int cl = range.Columns.Count;
                List<ClassRecepcion> lista = new List<ClassRecepcion>();

                for (int fila = 2; fila <= rw; fila++)
                {
                    ClassRecepcion item = new ClassRecepcion();
                    item.Embarque = Convert.ToString(sheet.Cells[fila, 3].Value);
                    item.Orden = Convert.ToString(sheet.Cells[fila, 4].Value);
                    item.Fecha_recepcion = Convert.ToDateTime(sheet.Cells[fila, 5].Value);
                    item.Roll_ID = Convert.ToString(sheet.Cells[fila, 7].Value);
                    item.Supply_Id = Convert.ToString(sheet.Cells[fila, 8].Value);
                    item.SupplyName = Convert.ToString(sheet.Cells[fila, 9].Value);
                    item.Part_Number = Convert.ToString(sheet.Cells[fila, 10].Value);
                    item.ProductName = Convert.ToString(sheet.Cells[fila, 11].Value);
                    item.Width = Convert.ToDouble(sheet.Cells[fila, 12].Value);
                    item.Lenght = Convert.ToDouble(sheet.Cells[fila, 13].Value);
                    item.Splice = Convert.ToInt32(sheet.Cells[fila, 14].Value);
                    item.Core = Convert.ToDecimal(sheet.Cells [fila, 15].Value);
                    item.Palet_cant = Convert.ToInt32(sheet.Cells[fila, 16].Value);
                    item.Palet_paginas = Convert.ToInt32(sheet.Cells[fila, 17].Value);
                    lista.Add(item);
                    GRID_IMPORT.DataSource = lista.ToList();
                }
                wb.Close(null, null, null);
                oExcel.Quit();

            }
            catch (Exception)
            {

                
            }
       
        }   
    }
}
