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
        string db = "RITRAMA";
        string sql1 = "SELECT numero,fecha,customer_id,person_contact,conduce,vendor_id,transport_id,chofer_id,placas_id,packing,orden_trabajo,orden_corte,orden_compra,subtotal,porc_itbis,itbis,total$rd FROM despachos";
        string sql2 = "SELECT numero,product_id,cant,unid_id,width,lenght,msi,ratio,kilo_rollo,kilo_total,precio,total_renglon FROM detalle_despachos";
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
                DataColumn ParentCol0 = ds.Tables["dtdespachos"].Columns["numero"];
                DataColumn ChildCol0 = ds.Tables["dtitems"].Columns["numero"];
                DataRelation master_details = new DataRelation("FK_MASTER_DETAILS", ParentCol0, ChildCol0);
                ds.Relations.Add(master_details);
                //Relacion Despacho-Cliente.
                DataColumn ParentCol1 = ds.Tables["dtcustomer"].Columns["Customer_ID"];
                DataColumn ChildCol1 = ds.Tables["dtdespachos"].Columns["customer_id"];
                DataRelation despachos_cliente = new DataRelation("FK_DESPACHO_CLIENTE", ParentCol1, ChildCol1);
                ds.Relations.Add(despachos_cliente);
                ds.Tables["dtdespachos"].Columns.Add("customer_name",
                Type.GetType("System.String"), "parent(FK_DESPACHO_CLIENTE).customer_name");
                ds.Tables["dtdespachos"].Columns.Add("customer_dir",
               Type.GetType("System.String"), "parent(FK_DESPACHO_CLIENTE).customer_dir");
                //Relacion Despacho-Vendedor.
                DataColumn ParentCol2 = ds.Tables["dtvendor"].Columns["VENDOR_ID"];
                DataColumn ChildCol2 = ds.Tables["dtdespachos"].Columns["vendor_id"];
                DataRelation despachos_vendedor = new DataRelation("FK_DESPACHO_VENDEDOR", ParentCol2, ChildCol2);
                ds.Relations.Add(despachos_vendedor);
                ds.Tables["dtdespachos"].Columns.Add("vendor_name",
                Type.GetType("System.String"), "parent(FK_DESPACHO_VENDEDOR).vendor_name");
                //Relacion Despacho-transporte.
                DataColumn ParentCol3 = ds.Tables["dttransporte"].Columns["TRANSPORT_ID"];
                DataColumn ChildCol3 = ds.Tables["dtdespachos"].Columns["transport_id"];
                DataRelation despachos_transporte = new DataRelation("FK_DESPACHO_TRANSPORTE", ParentCol3, ChildCol3);
                ds.Relations.Add(despachos_transporte);
                ds.Tables["dtdespachos"].Columns.Add("transport_name",
                Type.GetType("System.String"), "parent(FK_DESPACHO_TRANSPORTE).transport_name");
                //Relacion Despacho-chofer.
                DataColumn ParentCol4 = ds.Tables["dtchofer"].Columns["CHOFER_ID"];
                DataColumn ChildCol4 = ds.Tables["dtdespachos"].Columns["CHOFER_ID"];
                DataRelation despachos_chofer = new DataRelation("FK_DESPACHO_CHOFER", ParentCol4, ChildCol4);
                ds.Relations.Add(despachos_chofer);
                ds.Tables["dtdespachos"].Columns.Add("chofer_name",
                Type.GetType("System.String"), "parent(FK_DESPACHO_CHOFER).chofer_name");
                //Relacion Despacho-camion.
                DataColumn ParentCol5 = ds.Tables["dtcamion"].Columns["PLACAS_ID"];
                DataColumn ChildCol5 = ds.Tables["dtdespachos"].Columns["PLACAS_ID"];
                DataRelation despachos_camion = new DataRelation("FK_DESPACHO_CAMION", ParentCol5, ChildCol5);
                ds.Relations.Add(despachos_camion);
                ds.Tables["dtdespachos"].Columns.Add("camion_name",
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
        public Boolean GetProducto()
        {
            try
            {
                Micomm.Conectar(db);
                SqlCommand comando = new SqlCommand
                {
                    Connection = Micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = sql8

                };
                comando.ExecuteNonQuery();
                daproducto.SelectCommand = comando;
                daproducto.Fill(ds, "dtproducto");
                comando.Dispose();
                Micomm.Desconectar();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al cargar los productos. error code:" + ex);
                return false;
            }
        }
        public Boolean Getchofer()
        {
            try
            {
                Micomm.Conectar(db);
                SqlCommand comando = new SqlCommand
                {
                    Connection = Micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = sql6

                };
                comando.ExecuteNonQuery();
                dachofer.SelectCommand = comando;
                dachofer.Fill(ds, "dtchofer");
                comando.Dispose();
                Micomm.Desconectar();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al cargar la lista de los chofer. error code:" + ex);
                return false;
            }
        }
        public Boolean GetCamion()
        {
            try
            {
                Micomm.Conectar(db);
                SqlCommand comando = new SqlCommand
                {
                    Connection = Micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = sql7

                };
                comando.ExecuteNonQuery();
                dacamion.SelectCommand = comando;
                dacamion.Fill(ds, "dtcamion");
                comando.Dispose();
                Micomm.Desconectar();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al cargar la lista de los camiones. error code:" + ex);
                return false;
            }

        }
        public Boolean GetTransporte()
        {
            try
            {
                Micomm.Conectar(db);
                SqlCommand comando = new SqlCommand
                {
                    Connection = Micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = sql5

                };
                comando.ExecuteNonQuery();
                datransporte.SelectCommand = comando;
                datransporte.Fill(ds, "dttransporte");
                comando.Dispose();
                Micomm.Desconectar();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al cargar la lista de los transportistas. error code:" + ex);
                return false;
            }
        }
        public Boolean GetVendedores() 
        {
            try
            {
                Micomm.Conectar(db);
                SqlCommand comando = new SqlCommand
                {
                    Connection = Micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = sql4

                };
                comando.ExecuteNonQuery();
                davendor.SelectCommand = comando;
                davendor.Fill(ds, "dtvendor");
                comando.Dispose();
                Micomm.Desconectar();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al cargar la lista de los vendodores. error code:" + ex);
                return false;
            }
        }
        public Boolean GetCustomers()
        {
            try
            {
                Micomm.Conectar(db);
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
                Micomm.Conectar(db);
                SqlCommand comando = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    CommandText = sql1,
                    Connection = Micomm.cnn
                };
                comando.ExecuteNonQuery();
                dadespachos.SelectCommand = comando;
                dadespachos.Fill(ds, "dtdespachos");
                //detalle de la orden de corte.
                SqlCommand comando1 = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    CommandText = sql2,
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
