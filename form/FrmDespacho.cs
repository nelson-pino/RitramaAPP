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
        DespachosManager manager = new DespachosManager();
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
        BindingSource bsitem = new BindingSource();

        private void FrmDespacho_Load(object sender, EventArgs e)
        {
            AplicarEstilosGrid();
            ds = manager.ds;
            grid_items.DataSource = ds.Tables["dtdespachos"];
            bs.DataSource = ds;
            bs.DataMember = "dtdespachos";
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
            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn
            {
                Name = "product_id",
                Width = 80,
                HeaderText = "Product Id",
                DataPropertyName = "product_id"
            };
            grid_items.Columns.Add(col1);
            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn
            {
                Name = "product_name",
                Width = 200,
                HeaderText = "Nombre del Producto",
                DataPropertyName = "product_name"
            };
            grid_items.Columns.Add(col2);
            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn
            {
                Name = "cant",
                Width = 60,
                HeaderText = "Cant",
                DataPropertyName = "cant"
            };
            grid_items.Columns.Add(col3);
            DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn
            {
                Name = "unid",
                Width = 60,
                HeaderText = "Unidad",
                DataPropertyName = "unid_id"
            };
            grid_items.Columns.Add(col4);
            DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn
            {
                Name = "ancho",
                Width = 60,
                HeaderText = "Ancho (inch)",
                DataPropertyName = "width"
            };
            grid_items.Columns.Add(col5);
            DataGridViewTextBoxColumn col6 = new DataGridViewTextBoxColumn
            {
                Name = "largo",
                Width = 60,
                HeaderText = "Largo (pies)",
                DataPropertyName = "lenght"
            };
            grid_items.Columns.Add(col6);
            DataGridViewTextBoxColumn col7 = new DataGridViewTextBoxColumn
            {
                Name = "msi",
                Width = 60,
                HeaderText = "Msi.",
                DataPropertyName = "msi"
            };
            grid_items.Columns.Add(col7);
            DataGridViewTextBoxColumn col8 = new DataGridViewTextBoxColumn
            {
                Name = "ratio",
                Width = 60,
                HeaderText = "Ratio",
                DataPropertyName = "ratio"
            };
            grid_items.Columns.Add(col8);
            DataGridViewTextBoxColumn col9 = new DataGridViewTextBoxColumn
            {
                Name = "kilo_rollo",
                Width = 60,
                HeaderText = "Kilo Rollo",
                DataPropertyName = "kilo_rollo"
            };
            grid_items.Columns.Add(col9);
            DataGridViewTextBoxColumn col10 = new DataGridViewTextBoxColumn
            {
                Name = "kilo_total",
                Width = 60,
                HeaderText = "Kilo Total",
                DataPropertyName = "kilo_total"
            };
            grid_items.Columns.Add(col10);
            DataGridViewTextBoxColumn col11 = new DataGridViewTextBoxColumn
            {
                Name = "precio",
                Width = 60,
                HeaderText = "Precio",
                DataPropertyName = "precio"
            };
            grid_items.Columns.Add(col11);
            DataGridViewTextBoxColumn col12 = new DataGridViewTextBoxColumn
            {
                Name = "total_renglon",
                Width = 60,
                HeaderText = "Venta",
                DataPropertyName = "total_renglon"
            };
            grid_items.Columns.Add(col12);
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
    }
}
