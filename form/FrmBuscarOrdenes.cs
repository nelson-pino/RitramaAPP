using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RitramaAPP.form
{
    public partial class FrmBuscarOrdenes : Form
    {
        public DataTable dtordenes { get; set; }
        public string orden { get; set; }
        DataView dv = new DataView();
        public FrmBuscarOrdenes()
        {
            InitializeComponent();
        }
        private void FrmBuscarOrdenes_Load(object sender, EventArgs e)
        {
            dv = dtordenes.DefaultView;
            dv.RowFilter = "";
            DarEstilosGrid();
            grid_ordenes.DataSource = dv;
            CONTADOR_REGISTRO.Text = "Numero de Registros: " + Convert.ToString(dv.Count);
        }
        private void DarEstilosGrid()
        {
            grid_ordenes.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.Name = "orden";
            col1.Width = 70;
            col1.HeaderText = "Numero OC";
            col1.DataPropertyName = "numero";
            grid_ordenes.Columns.Add(col1);
            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.Name = "fecha";
            col2.Width = 90;
            col2.HeaderText = "Fecha";
            col2.DataPropertyName = "fecha";
            grid_ordenes.Columns.Add(col2);
            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.Name = "Id. Cust.";
            col3.Width = 80;
            col3.HeaderText = "Id. Cliente";
            col3.DataPropertyName = "customer_id";
            grid_ordenes.Columns.Add(col3);
            DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
            col4.Name = "customer_name";
            col4.Width = 200;
            col4.HeaderText = "Nombre del Cliente";
            col4.DataPropertyName = "customer_name";
            grid_ordenes.Columns.Add(col4);
            DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn();
            col5.Name = "rollos";
            col5.Width = 60;
            col5.HeaderText = "Total Rollos";
            col5.DataPropertyName = "total_rollos";
            grid_ordenes.Columns.Add(col5);
        }

        private void Txt_buscar_TextChanged(object sender, EventArgs e)
        {
            if (rad_orden.Checked)
            {
                dv.RowFilter = "numero LIKE '%" + this.txt_buscar.Text + "%'";
            }
            if (rad_customer_name.Checked)
            {
                dv.RowFilter = "customer_name LIKE '%" + this.txt_buscar.Text + "%'";
            }
            if (rad_id_customer.Checked)
            {
                dv.RowFilter = "customer_id LIKE '%" + this.txt_buscar.Text + "%'";
            }
            CONTADOR_REGISTRO.Text = "Numero de Registros: " + Convert.ToString(dv.Count);
        }

        private void Bot_buscar_Click(object sender, EventArgs e)
        {
            string fdesde = Convert.ToString(Convert.ToDateTime(txt_fecha_desde.Text).Month) +
            "/" + Convert.ToString(Convert.ToDateTime(txt_fecha_desde.Text).Day) + "/" +
            Convert.ToString(Convert.ToDateTime(txt_fecha_desde.Text).Year);
            string fhasta = Convert.ToString(Convert.ToDateTime(txt_fecha_hasta.Text).Month) +
            "/" + Convert.ToString(Convert.ToDateTime(txt_fecha_hasta.Text).Day) + "/" +
            Convert.ToString(Convert.ToDateTime(txt_fecha_hasta.Text).Year);

            if (rad_fecha.Checked)
            {
                dv.RowFilter = "fecha >= #" + fdesde + "# AND  fecha <= #" + fhasta + "#";
            }
            CONTADOR_REGISTRO.Text = "Numero de Registros: " + Convert.ToString(dv.Count);
        }

        private void Grid_ordenes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            orden = (grid_ordenes.Rows[e.RowIndex].Cells[0].Value.ToString());
            this.Close();
        }

        private void Rad_fecha_CheckedChanged(object sender, EventArgs e)
        {
            if (rad_fecha.Checked)
            {
                txt_fecha_desde.Enabled = true;
                txt_fecha_hasta.Enabled = true;
            }
            else
            {
                txt_fecha_desde.Enabled = false;
                txt_fecha_hasta.Enabled = false;
            }
        }
    }
}
