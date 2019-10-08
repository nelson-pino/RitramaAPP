﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RitramaAPP.Clases;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace RitramaAPP.Clases
{
    
    public class DespachosManager
    {
        Conexion Micomm = new Conexion();
        SqlDataAdapter dadespachos = new SqlDataAdapter();
        SqlDataAdapter dacustomer = new SqlDataAdapter();
        SqlDataAdapter davendor = new SqlDataAdapter();
        SqlDataAdapter datransporte = new SqlDataAdapter();
        SqlDataAdapter dachofer = new SqlDataAdapter();
        SqlDataAdapter dacamion = new SqlDataAdapter();
        SqlDataAdapter daitems = new SqlDataAdapter();
        SqlDataAdapter daproducto = new SqlDataAdapter();
        DataTable dtdespachos = new DataTable();
        DataTable dtcustomer = new DataTable();
        DataTable dtvendor = new DataTable();
        DataTable dttransporte = new DataTable();
        DataTable dtchofer = new DataTable();
        DataTable dtcamion = new DataTable();
        DataTable dtitems = new DataTable();
        DataTable dtproducto = new DataTable();
        public DataSet ds = new DataSet();
       
        string sql2 = "SELECT numero,product_id,cant,unid_id,width,lenght,msi,ratio,kilo_rollo,kilo_total,precio,total_renglon FROM item_despacho";
        string sql3 = "SELECT Customer_ID,Customer_Name,Customer_Category,Customer_Dir,Customer_Email,Anulado  FROM customer";
        string sql4 = "SELECT vendor_id,vendor_name FROM vendedor";
        string sql5 = "SELECT transport_id,transport_name FROM transporte";
        string sql6 = "SELECT chofer_id,chofer_name FROM chofer";
        string sql7 = "SELECT placas_id,camion_name FROM camion";
        string sql8 = "SELECT product_id,product_name FROM producto";

        public DespachosManager()
        {
            GetProducto();
            GetDespachos();
            GetCustomers();
            GetVendedores();
            GetTransporte();
            Getchofer();
            GetCamion();
            RelacionesDS();
        }
        public Boolean RelacionesDS()
        {
            try
            {
                //Relacion Maestro-detalle.
                DataColumn ParentCol0 = ds.Tables["dtdespacho"].Columns["numero"];
                DataColumn ChildCol0 = ds.Tables["dtitems"].Columns["numero"];
                DataRelation master_details = new DataRelation("FK_MASTER_DETAILS", ParentCol0, ChildCol0);
                ds.Relations.Add(master_details);
                //Relacion Despacho-Cliente.
                DataColumn ParentCol1 = ds.Tables["dtcustomer"].Columns["Customer_ID"];
                DataColumn ChildCol1 = ds.Tables["dtdespacho"].Columns["customer_id"];
                DataRelation despachos_cliente = new DataRelation("FK_DESPACHO_CLIENTE", ParentCol1, ChildCol1);
                ds.Relations.Add(despachos_cliente);
                ds.Tables["dtdespacho"].Columns.Add("customer_name",
                Type.GetType("System.String"), "parent(FK_DESPACHO_CLIENTE).customer_name");
                ds.Tables["dtdespacho"].Columns.Add("customer_dir",
               Type.GetType("System.String"), "parent(FK_DESPACHO_CLIENTE).customer_dir");
                //Relacion Despacho-Vendedor.
                DataColumn ParentCol2 = ds.Tables["dtvendor"].Columns["VENDOR_ID"];
                DataColumn ChildCol2 = ds.Tables["dtdespacho"].Columns["vendor_id"];
                DataRelation despachos_vendedor = new DataRelation("FK_DESPACHO_VENDEDOR", ParentCol2, ChildCol2);
                ds.Relations.Add(despachos_vendedor);
                ds.Tables["dtdespacho"].Columns.Add("vendor_name",
                Type.GetType("System.String"), "parent(FK_DESPACHO_VENDEDOR).vendor_name");
                //Relacion Despacho-transporte.
                DataColumn ParentCol3 = ds.Tables["dttransporte"].Columns["TRANSPORT_ID"];
                DataColumn ChildCol3 = ds.Tables["dtdespacho"].Columns["transport_id"];
                DataRelation despachos_transporte = new DataRelation("FK_DESPACHO_TRANSPORTE", ParentCol3, ChildCol3);
                ds.Relations.Add(despachos_transporte);
                ds.Tables["dtdespacho"].Columns.Add("transport_name",
                Type.GetType("System.String"), "parent(FK_DESPACHO_TRANSPORTE).transport_name");
                //Relacion Despacho-chofer.
                DataColumn ParentCol4 = ds.Tables["dtchofer"].Columns["CHOFER_ID"];
                DataColumn ChildCol4 = ds.Tables["dtdespacho"].Columns["CHOFER_ID"];
                DataRelation despachos_chofer = new DataRelation("FK_DESPACHO_CHOFER", ParentCol4, ChildCol4);
                ds.Relations.Add(despachos_chofer);
                ds.Tables["dtdespacho"].Columns.Add("chofer_name",
                Type.GetType("System.String"), "parent(FK_DESPACHO_CHOFER).chofer_name");
                //Relacion Despacho-camion.
                DataColumn ParentCol5 = ds.Tables["dtcamion"].Columns["PLACAS_ID"];
                DataColumn ChildCol5 = ds.Tables["dtdespacho"].Columns["PLACAS_ID"];
                DataRelation despachos_camion = new DataRelation("FK_DESPACHO_CAMION", ParentCol5, ChildCol5);
                ds.Relations.Add(despachos_camion);
                ds.Tables["dtdespacho"].Columns.Add("camion_name",
                Type.GetType("System.String"), "parent(FK_DESPACHO_CAMION).camion_name");
                //Relacion Detalle-productos.
                DataColumn ParentCol6 = ds.Tables["dtproducto"].Columns["PRODUCT_ID"];
                DataColumn ChildCol6 = ds.Tables["dtitems"].Columns["PRODUCT_ID"];
                DataRelation ITEMS_PRODUCTS = new DataRelation("FK_ITEMS_PRODUCTS", ParentCol6, ChildCol6);
                ds.Relations.Add(ITEMS_PRODUCTS);
                ds.Tables["dtitems"].Columns.Add("product_name",
                Type.GetType("System.String"), "parent(FK_ITEMS_PRODUCTS).product_name");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("error al establecer las relaciones. error code:" + ex);
                return false;
            }
        }
        public Boolean CommandSqlGeneric(string db, string query, List<SqlParameter> spc, Boolean msg, string messagerror)
        {
            // Ejecuta comando sql query y no devuleve ni valor ni datos.
            try
            {
                Micomm.Conectar(db);
                SqlCommand comando = new SqlCommand
                {
                    Connection = Micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = query
                };
                if (spc.Count > 0)
                {
                    foreach (SqlParameter item in spc)
                    {
                        comando.Parameters.Add(item);
                    }
                }
                comando.ExecuteNonQuery();
                comando.Dispose();
                Micomm.Desconectar();
                if (msg)
                {
                    MessageBox.Show("proceso realizado con exito...");
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(messagerror + ex);
                return false;
            }
        }
        public Boolean CommandSqlGenericUpdateDs(string db, string query, SqlDataAdapter da, string dt, string messagefail)
        {
            try
            {
                Micomm.Conectar(db);
                SqlCommand comando = new SqlCommand
                {
                    Connection = Micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = query
                };
                comando.ExecuteNonQuery();
                da.SelectCommand = comando;
                da.Fill(ds, dt);
                comando.Dispose();
                Micomm.Desconectar();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(messagefail + ex);
                return false;
            }
        }
        public void GetProducto()
        {
            CommandSqlGenericUpdateDs(R.SQL.DATABASE.NAME,R.SQL.QUERY_SQL.DESPACHOS.SQL_SELECT_PRODUCTOS,
            daproducto,"dtproducto",R.MESSAGES_TEXT_SYSTEM_MODULES.DESPACHOS.MESSAGE_SELECT_ERROR_LOAD_PRODUCTS);
        }
        public void Getchofer() 
        {
            CommandSqlGenericUpdateDs(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.DESPACHOS.SQL_SELECT_CHEFERES,
            dachofer, "dtchofer", R.MESSAGES_TEXT_SYSTEM_MODULES.DESPACHOS.MESSAGE_SELECT_ERROR_LOAD_CHOFERES);
        }
        private void GetCamion() 
        {
            CommandSqlGenericUpdateDs(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.DESPACHOS.SQL_SELECT_CAMION,
            dacamion, "dtcamion", R.MESSAGES_TEXT_SYSTEM_MODULES.DESPACHOS.MESSAGE_SELECT_ERROR_LOAD_CAMIONES);
        }
        private void GetTransporte() 
        {
            CommandSqlGenericUpdateDs(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.DESPACHOS.SQL_SELECT_TRANSPORTE,
            datransporte, "dttransporte", R.MESSAGES_TEXT_SYSTEM_MODULES.DESPACHOS.MESSAGE_SELECT_ERROR_LOAD_TRANSPORTE);
        }
        private void GetVendedores() 
        {
            CommandSqlGenericUpdateDs(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.DESPACHOS.SQL_SELECT_VENDEDORES,
            davendor, "dtvendor", R.MESSAGES_TEXT_SYSTEM_MODULES.DESPACHOS.MESSAGE_SELECT_ERROR_LOAD_VENDEDOR);
        }

        
        public Boolean GetCustomers()
        {
            try
            {
                Micomm.Conectar(R.SQL.DATABASE.NAME);
                SqlCommand comando = new SqlCommand
                {
                    Connection = Micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = sql3

                };
                comando.ExecuteNonQuery();
                dacustomer.SelectCommand = comando;
                dacustomer.Fill(ds, "dtcustomer");
                comando.Dispose();
                Micomm.Desconectar();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al cargar la lista de los clientes. error code:" + ex);
                return false;
            }
        }
        public Boolean GetDespachos()
        {
            try
            {
                // encabeza de la orden de corte
                Micomm.Conectar(R.SQL.DATABASE.NAME);
                SqlCommand comando = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    CommandText = R.SQL.QUERY_SQL.DESPACHOS.SQL_SELECT_DESPACHOS_HEADER,
                    Connection = Micomm.cnn
                };
                comando.ExecuteNonQuery();
                dadespachos.SelectCommand = comando;
                dadespachos.Fill(ds, "dtdespacho");
                //detalle de la orden de corte.
                SqlCommand comando1 = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    CommandText = R.SQL.QUERY_SQL.DESPACHOS.SQL_SELECT_DESPACHOS_DETAILS,
                    Connection = Micomm.cnn
                };
                comando1.ExecuteNonQuery();
                daitems.SelectCommand = comando1;
                daitems.Fill(ds, "dtitems");
                Micomm.Desconectar();
                comando.Dispose();
                comando1.Dispose();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al cargar los despachos del sistema...Error Code: " + ex);
                return false;
            }
        }
    }
}
