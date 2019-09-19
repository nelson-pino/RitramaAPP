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
    public partial class SeleccionCustomers : Form
    {
        public SeleccionCustomers()
        {
            InitializeComponent();
        }
        public DataTable dtcustomer { get; set; }
        public string itemSelected { get; set; }
        public string GetCustomerId { get; set; }
        public string GetCustomerName { get; set; }

        DataView dv = new DataView();
        private void SeleccionCustomers_Load(object sender, EventArgs e)
        {
            dv = dtcustomer.DefaultView;
            grid_customers.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.Name = "customer_id";
            col1.Width = 60;
            col1.HeaderText = "Codigo";
            col1.DataPropertyName = "Customer_ID";
            grid_customers.Columns.Add(col1);
            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.Name = "customer_name";
            col2.Width = 390;
            col2.HeaderText = "Customer Name";
            col2.DataPropertyName = "Customer_Name";
            grid_customers.Columns.Add(col2);
            dv.RowFilter = "";
            grid_customers.DataSource = dv;
            lbl_contador_registros.Text = Convert.ToString(dv.Count) + " registros encontrados.";
        }
        private void Txt_buscar_TextChanged(object sender, EventArgs e)
        {
            if (rad_codigo.Checked)
            {
                dv.RowFilter = "Customer_ID LIKE '%" + this.txt_buscar.Text + "%'";
            }
            if (rad_name.Checked)
            {
                dv.RowFilter = "Customer_Name LIKE '%" + this.txt_buscar.Text + "%'";
            }
            lbl_contador_registros.Text = Convert.ToString(dv.Count) + " registros encontrados.";
        }

        private void Grid_customers_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            itemSelected = grid_customers.Rows[e.RowIndex].Cells[0].Value.ToString();
            GetCustomerId = grid_customers.Rows[e.RowIndex].Cells[0].Value.ToString();
            GetCustomerName = grid_customers.Rows[e.RowIndex].Cells[1].Value.ToString();
            this.Close();
        }
    }
}
