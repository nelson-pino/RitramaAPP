using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace RitramaAPP.Clases
{
    public class RecepcionManager
    {
        readonly Conexion micomm = new Conexion();
        readonly SqlDataAdapter darecepcion = new SqlDataAdapter();
        readonly SqlDataAdapter daproducto = new SqlDataAdapter();
        readonly SqlDataAdapter daprovider = new SqlDataAdapter();
        readonly DataTable dtrecepcion = new DataTable();
        readonly DataTable dtproducto = new DataTable();
        readonly DataTable dtprovider = new DataTable();
        public DataSet ds = new DataSet();
        readonly string db = "RITRAMA";
        readonly string sql2 = "SELECT OrderPurchase,Part_Number,Width,Lenght,Roll_Id,Proveedor_Id,Splice,Core,Ubicacion,anulado,fecha_reg,hora_reg,fecha_pro,master,resma,graphics,embarque,palet_num,palet_cant,palet_pag FROM OrdenRecepcion";
        readonly string sql3 = "SELECT Product_ID,Product_Name FROM producto";
        readonly string sql4 = "SELECT Proveedor_ID,Proveedor_Name,Preveedor_phone,Preveedor_Dir,Preveedor_email,anulado FROM provider";
        readonly string sql5 = "SELECT count(*) FROM OrdenRecepcion WHERE OrderPurchase=@p1";
        readonly string sql6 = "SELECT unidad_master_2 FROM provider WHERE Proveedor_ID=@p1";
        readonly string sql7 = "SELECT MasterRolls,Resmas,Graphics FROM producto WHERE product_id=@p1";
        readonly string sql8 = "UPDATE OrdenRecepcion SET fecha_pro=@p2,embarque=@p3,Roll_Id=@p4,anulado=@p5,ubicacion=@p6,Proveedor_Id=@p7,width=@p8,lenght=@p9,splice=@p10,core=@p11 WHERE OrderPurchase=@p1";
        readonly string sql9 = "SELECT product_name FROM producto WHERE product_id=@p1";
        public DataTable Dtproducto => dtproducto;

        public RecepcionManager()
        {
            LoadRecepciones();
            LoadProducts();
            LoadProviders();
            RelacionesDS();
        }
        public Boolean RelacionesDS()
        {
            try
            {
                //Relacion Documento Recepcion-Producto.
                DataColumn ParentCol1 = ds.Tables["dtproducto"].Columns["Product_ID"];
                DataColumn ChildCol1 = ds.Tables["dtrecepcion"].Columns["Part_Number"];
                DataRelation recep_cliente = new DataRelation("FK_RECEPCION_PRODUCTO", ParentCol1, ChildCol1);
                ds.Relations.Add(recep_cliente);
                ds.Tables["dtrecepcion"].Columns.Add("product_name",
                Type.GetType("System.String"), "parent(FK_RECEPCION_PRODUCTO).Product_Name");
                //Relacion Documento recepcion-Vendedor.
                DataColumn ParentCol2 = ds.Tables["dtprovider"].Columns["Proveedor_ID"];
                DataColumn ChildCol2 = ds.Tables["dtrecepcion"].Columns["Proveedor_Id"];
                DataRelation recep_suplidor = new DataRelation("FK_RECEPCION_SUPLIDOR", ParentCol2, ChildCol2);
                ds.Relations.Add(recep_suplidor);
                ds.Tables["dtrecepcion"].Columns.Add("suplidor_des",
                Type.GetType("System.String"), "parent(FK_RECEPCION_SUPLIDOR).Proveedor_Name");
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al tratar de establecer las relaciones entre tablas. Error Code:" + ex);
                return false;
            }
        }
        public Boolean Add(ClassRecepcion recepcion)
        {
            try
            {
                micomm.Conectar(R.SQL.DATABASE.NAME);
                SqlCommand comando = new SqlCommand
                {
                    Connection = micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = R.SQL.QUERY_SQL.RECEPCIONES.SQL_QUERY_INSERT_DOCS_RECEPCIONES
                };
                SqlParameter p1 = new SqlParameter("@p1", recepcion.Orden);
                SqlParameter p2 = new SqlParameter("@p2", recepcion.Part_Number);
                SqlParameter p3 = new SqlParameter("@p3", recepcion.Width);
                SqlParameter p4 = new SqlParameter("@p4", recepcion.Lenght);
                SqlParameter p5 = new SqlParameter("@p5", recepcion.Roll_ID);
                SqlParameter p6 = new SqlParameter("@p6", recepcion.Supply_Id);
                SqlParameter p7 = new SqlParameter("@p7", recepcion.Ubicacion);
                SqlParameter p8 = new SqlParameter("@p8", recepcion.Core);
                SqlParameter p9 = new SqlParameter("@p9", recepcion.Splice);
                SqlParameter p10 = new SqlParameter("@p10", recepcion.Anulado);
                SqlParameter p11 = new SqlParameter("@p11", recepcion.Fecha_reg);
                SqlParameter p12 = new SqlParameter("@p12", recepcion.Hora_reg);
                SqlParameter p13 = new SqlParameter("@p13", recepcion.fecha_produccion);
                SqlParameter p14 = new SqlParameter("@p14", recepcion.master);
                SqlParameter p15 = new SqlParameter("@p15", recepcion.Resma);
                SqlParameter p16 = new SqlParameter("@p16", recepcion.Graphics);
                SqlParameter p17 = new SqlParameter("@p17", recepcion.Embarque);
                SqlParameter p18 = new SqlParameter("@p18", recepcion.Palet_number);
                SqlParameter p19 = new SqlParameter("@p19", recepcion.palet_cant);
                SqlParameter p20 = new SqlParameter("@p20", recepcion.Palet_paginas);
                comando.Parameters.Add(p1);
                comando.Parameters.Add(p2);
                comando.Parameters.Add(p3);
                comando.Parameters.Add(p4);
                comando.Parameters.Add(p5);
                comando.Parameters.Add(p6);
                comando.Parameters.Add(p7);
                comando.Parameters.Add(p8);
                comando.Parameters.Add(p9);
                comando.Parameters.Add(p10);
                comando.Parameters.Add(p11);
                comando.Parameters.Add(p12);
                comando.Parameters.Add(p13);
                comando.Parameters.Add(p14);
                comando.Parameters.Add(p15);
                comando.Parameters.Add(p16);
                comando.Parameters.Add(p17);
                comando.Parameters.Add(p18);
                comando.Parameters.Add(p19);
                comando.Parameters.Add(p20);
                comando.ExecuteNonQuery();
                comando.Dispose();
                micomm.Desconectar();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show( R.MESSAGES_TEXT_SYSTEM_MODULES.MODULO_RECEPCIONES.MESSAGE_TEXT_RECEPCIONES_ERROR_ADD_DOCUMENTS + ex);
                return false;
            }
        }
        public Boolean Update(ClassRecepcion recepcion)
        {
            try
            {
                micomm.Conectar(db);
                SqlCommand comando = new SqlCommand
                {
                    Connection = micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = sql8

                };
                SqlParameter p1 = new SqlParameter("@p1", recepcion.Orden);
                SqlParameter p2 = new SqlParameter("@p2", recepcion.fecha_produccion);
                SqlParameter p3 = new SqlParameter("@p3", recepcion.Embarque);
                SqlParameter p4 = new SqlParameter("@p4", recepcion.Roll_ID);
                SqlParameter p5 = new SqlParameter("@p5", recepcion.Anulado);
                SqlParameter p6 = new SqlParameter("@p6", recepcion.Ubicacion);
                SqlParameter p7 = new SqlParameter("@p7", recepcion.Supply_Id);
                SqlParameter p8 = new SqlParameter("@p8", recepcion.Width);
                SqlParameter p9 = new SqlParameter("@p9", recepcion.Lenght);
                SqlParameter p10 = new SqlParameter("@p10", recepcion.Splice);
                SqlParameter p11 = new SqlParameter("@p11", recepcion.Core);
                comando.Parameters.Add(p1);
                comando.Parameters.Add(p2);
                comando.Parameters.Add(p3);
                comando.Parameters.Add(p4);
                comando.Parameters.Add(p5);
                comando.Parameters.Add(p6);
                comando.Parameters.Add(p7);
                comando.Parameters.Add(p8);
                comando.Parameters.Add(p9);
                comando.Parameters.Add(p10);
                comando.Parameters.Add(p11);
                comando.ExecuteNonQuery();
                comando.Dispose();
                micomm.Desconectar();
                MessageBox.Show("Se actualizaron los datos con exito...");
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al modificar recepciones de materia prima...Error Code:" + ex);
                return false;

            }
        }
        public Boolean LoadRecepciones()
        {
            try
            {
                micomm.Conectar(db);
                SqlCommand comando = new SqlCommand
                {
                    Connection = micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = sql2
                };
                comando.ExecuteNonQuery();
                darecepcion.SelectCommand = comando;
                darecepcion.Fill(ds, "dtrecepcion");
                comando.Dispose();
                micomm.Desconectar();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("error al traer las ordenes de recepcion...error code:" + ex);
                return false;
            }
        }
        public Boolean LoadProducts()
        {
            try
            {
                micomm.Conectar(db);
                SqlCommand comando = new SqlCommand
                {
                    Connection = micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = sql3
                };
                comando.ExecuteNonQuery();
                daproducto.SelectCommand = comando;
                daproducto.Fill(ds, "dtproducto");
                comando.Dispose();
                micomm.Desconectar();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("error al cargar la tabla de productos...error code:" + ex);
                return false;
            }
        }
        public Boolean LoadProviders()
        {
            try
            {
                micomm.Conectar(db);
                SqlCommand comando = new SqlCommand
                {
                    Connection = micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = sql4
                };
                comando.ExecuteNonQuery();
                daprovider.SelectCommand = comando;
                daprovider.Fill(ds, "dtprovider");
                comando.Dispose();
                micomm.Desconectar();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("error al cargar la tabla de providers...error code:" + ex);
                return false;
            }
        }
        public List<ClassRecepcion> DownloadDataMateriaPrimaTxtMovil()
        {
            CultureInfo cultures = new CultureInfo("en-US");
            string path = R.PATH_FILES.FILE_TXT_MATERIA_PRIMA;
            List<ClassRecepcion> lista = new List<ClassRecepcion>();
            if (File.Exists(path))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        while (sr.Peek() >= 0)
                        {
                            string str;
                            string[] strArray;
                            str = sr.ReadLine();
                            strArray = str.Split(',');
                            string strWidth = strArray[2];
                            string strLenght = strArray[3];
                            int lenWidth = strWidth.Length;
                            int lenLenght = strLenght.Length;
                            strWidth = strWidth.Substring(1, lenWidth - 1);
                            strLenght = strLenght.Substring(1, lenLenght - 1);
                            decimal WidthValue = Math.Round(Convert.ToDecimal(strWidth, cultures),
                            2, MidpointRounding.AwayFromZero);
                            decimal LenghtValue = Math.Round(Convert.ToDecimal(strLenght, cultures),
                            2, MidpointRounding.AwayFromZero);
                            ClassRecepcion recepcion = new ClassRecepcion
                            {
                                Orden = strArray[0],
                                Part_Number = strArray[1],
                                ProductName = SearchProductName(strArray[1]),
                                Width = WidthValue,
                                Lenght = LenghtValue,
                                Roll_ID = (strArray[4])
                            };
                            lista.Add(recepcion);
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al descargar data del dispositivo movil...Error Code:" + ex);
                    lista = null;
                    return lista;
                }
            }
            else
            {
                MessageBox.Show("el archivo txt no existe...");
            }
            return lista;
        }
        public string SearchProductName(string product_id)
        {
            string result;
            micomm.Conectar(db);
            SqlCommand comando = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = sql9,
                Connection = micomm.cnn
            };
            SqlParameter p1 = new SqlParameter("@p1", product_id);
            comando.Parameters.Add(p1);
            result = Convert.ToString(comando.ExecuteScalar());
            micomm.Desconectar();
            comando.Dispose();
            return result;
        }
        public Boolean OrderExiste(string codigo)
        {
            int result;
            micomm.Conectar(db);
            SqlCommand comando = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = sql5,
                Connection = micomm.cnn
            };
            SqlParameter p1 = new SqlParameter("@p1", codigo);
            comando.Parameters.Add(p1);
            result = Convert.ToInt16(comando.ExecuteScalar());
            micomm.Desconectar();
            comando.Dispose();
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean VericarMasterollMetros(string codigo_prv)
        {
            Boolean providerMeters;
            micomm.Conectar(db);
            SqlCommand comando = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = sql6,
                Connection = micomm.cnn
            };
            SqlParameter p1 = new SqlParameter("@p1", codigo_prv);
            comando.Parameters.Add(p1);
            providerMeters = Convert.ToBoolean(comando.ExecuteScalar());
            micomm.Desconectar();
            comando.Dispose();
            return providerMeters;
        }
        public int VerifarProductType(string codigo_pro)
        {
            int result = 0;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            micomm.Conectar(db);
            SqlCommand comando = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = sql7,
                Connection = micomm.cnn
            };
            SqlParameter p1 = new SqlParameter("@p1", codigo_pro);
            comando.Parameters.Add(p1);
            comando.ExecuteNonQuery();
            da.SelectCommand = comando;
            da.Fill(dt);
            micomm.Desconectar();
            comando.Dispose();
            if (Convert.ToBoolean(dt.Rows[0]["MasterRolls"]))
            {
                result = 1;
            }
            
            else if (Convert.ToBoolean(dt.Rows[0]["Resmas"]))
            {
                result = 2;
            }
            else if (Convert.ToBoolean(dt.Rows[0]["Graphics"]))
            {
                result = 3;
            }
            return result;
        }
    }
}
