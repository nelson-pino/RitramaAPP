using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RitramaAPP.Clases;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;


namespace RitramaAPP.form
{
    public partial class FrmDespacho : Form
    {
        public FrmDespacho()
        {
            InitializeComponent();
        }
        DespachosManager despachomanager = new DespachosManager();
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
        BindingSource bsitem = new BindingSource();
        DataRowView ParentRow;
        int EditMode = 0;

        private void FrmDespacho_Load(object sender, EventArgs e)
        {
            AplicarEstilosGrid();
            ds = despachomanager.ds;
            grid_items.DataSource = ds.Tables["dtdespacho"];
            bs.DataSource = ds;
            bs.DataMember = "dtdespacho";
            txt_numero_despacho.DataBindings.Add("text", bs, "numero");
            txt_fecha_despacho.DataBindings.Add("text",bs,"fecha");
            txt_customer_id.DataBindings.Add("text", bs, "customer_id");
            txt_customer_name.DataBindings.Add("text", bs, "customer_name");
            txt_customer_direc.DataBindings.Add("text", bs, "customer_dir");
            txt_contact_person.DataBindings.Add("text", bs, "person_contact");
            txt_numero_conduce.DataBindings.Add("text",bs,"conduce");
            txt_vendor_id.DataBindings.Add("text", bs, "vendor_id");
            txt_vendor_name.DataBindings.Add("text", bs, "vendor_name");
            txt_transport_id.DataBindings.Add("text", bs, "transport_id");
            txt_transport_name.DataBindings.Add("text", bs, "transport_name");
            txt_chofer_id.DataBindings.Add("text", bs, "chofer_id");
            txt_chofer_name.DataBindings.Add("text",bs,"chofer_name");
            txt_placas.DataBindings.Add("text", bs, "placas_id");
            txt_camion.DataBindings.Add("text",bs,"camion_name");
            txt_tipo_embalaje.DataBindings.Add("text",bs,"packing");
            txt_ocompra.DataBindings.Add("text", bs, "orden_compra");
            txt_otrabajo.DataBindings.Add("text",bs,"orden_trabajo");
            txt_ocorte.DataBindings.Add("text",bs,"orden_corte");
            txt_subtotal.DataBindings.Add("text",bs,"subtotal");
            txt_monto_itbis.DataBindings.Add("text",bs,"itbis");
            txt_total_despacho.DataBindings.Add("text",bs,"total$rd");
            txt_porc_itbis.DataBindings.Add("text", bs, "porc_itbis");
            bsitem.DataSource = bs;
            bsitem.DataMember = "FK_MASTER_DETAILS";
            grid_items.DataSource = bsitem;
        }
        private void AplicarEstilosGrid()
        {
            grid_items.AutoGenerateColumns = false;
            AGREGAR_COLUMN_GRID("product_id",80,"Product Id.","product_id");
            AGREGAR_COLUMN_GRID("product_name", 200, "Nombre del Producto", "product_name");
            AGREGAR_COLUMN_GRID("cant", 60, "Cant.", "cant");
            AGREGAR_COLUMN_GRID("unid", 60, "Unidad", "unid_id");
            AGREGAR_COLUMN_GRID("ancho", 60, "Ancho (inch)", "width");
            AGREGAR_COLUMN_GRID("msi", 60, "Msi.", "msi");
            AGREGAR_COLUMN_GRID("ratio", 60, "Ratio", "ratio");
            AGREGAR_COLUMN_GRID("kilo_rollo", 60, "kilo rollo", "kilo_rollo");
            AGREGAR_COLUMN_GRID("precio", 60, "precio", "precio");
            AGREGAR_COLUMN_GRID("total_renglon", 60, "Ventas", "total_renglon");
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
            grid_items.Columns.Add(col);
        }
        private void BOT_IMPRIMIR_Click(object sender, EventArgs e)
        {
            FrmReportViewCrystal frmReportView = new FrmReportViewCrystal();
            ReportDocument reporte = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            string PathReport = @"C:\Users\Npino\Desktop\RITRAMA\RitramaAPP\RitramaAPP\RitramaAPP\Reports\Format_Despacho.rpt";
            reporte.Load(PathReport);
            //reporte.SetParameterValue("NUMERO", "");
            frmReportView.crystalReportViewer.ReportSource = reporte;
            frmReportView.Text = "Formato de Facturacion";
            frmReportView.Width = 860;
            frmReportView.Height = 700;
            frmReportView.Show();
        }

        private void bot_nuevo_Click(object sender, EventArgs e)
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
            txt_numero_despacho.Focus();
            ContadorRegistros();
            OptionsMenu(0);
            OptionsForm(0);
            EditMode = 1;
        }
        private void ContadorRegistros() 
        {
        
        }
        private void OptionsMenu(int state) 
        {
        
        }
        private void OptionsForm(int state) 
        {
        
        }


    }
}
