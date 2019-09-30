using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RitramaAPP.Clases
{
    public class OrdenCorteManager
    {
        readonly Conexion Micomm = new Conexion();
        public DataSet ds = new DataSet();
        
        readonly SqlDataAdapter daordenes = new SqlDataAdapter();
        readonly SqlDataAdapter darenglones = new SqlDataAdapter();
        readonly SqlDataAdapter daproducts = new SqlDataAdapter();
        readonly DataTable dtordenes = new DataTable();
        readonly DataTable dtrenglones = new DataTable();
        readonly DataTable dtproducts = new DataTable();
        public DataTable Dtrenglones => dtrenglones;
        public DataTable Dtproducts => dtproducts;
        public DataTable Dtordenes => dtordenes;

        //readonly SqlDataAdapter darollid = new SqlDataAdapter();
        //readonly DataTable dtrolls = new DataTable();
        //readonly DataTable dtrollid = new DataTable();


        public OrdenCorteManager()
        {
            CargarProducts();
            CargarOrdenes();
            //CargarRollsId();
            RelacionesDS();
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
        public Boolean CargarOrdenes()
        {
            // encabeza de la orden de corte
            CommandSqlGenericUpdateDs(R.SQL.DATABASE.NAME,R.SQL.QUERY_SQL.PRODUCCION.SQL_SELECT_ORDEN_CORTE,
            daordenes,"dtordenes",R.MESSAGES_TEXT_SYSTEM_MODULES.PRODUCCION.MESSAGE_ADD_ORDEN_ERROR_FAIL_HEADER);

            //detalle de la orden de corte.
            CommandSqlGenericUpdateDs(R.SQL.DATABASE.NAME,
            R.SQL.QUERY_SQL.PRODUCCION.SQL_QUERY_SELECT_ROLLOS_CORTADOS, darenglones, "dtrenglones",
            R.MESSAGES_TEXT_SYSTEM_MODULES.PRODUCCION.MESSAGE_LOAD_ROLLOS_CORTADOS_ERROR_FAIL);
            
            return true;
            
        }

        public void CargarProducts() 
        {
            CommandSqlGenericUpdateDs(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.PRODUCTS.SQL_QUERY_SELECT_PRODUCT_ALL,
                    daproducts, "dtproducts", R.MESSAGES_TEXT_SYSTEM_MODULES.MODULO_PRODUCTOS.MESSAGE_SELECT_LOADPRODUCTOS_FAIL);
        }
        public void CargarRollsId() 
        {
            
        }
        public void Add(Orden datos,Boolean ismessage) 
        {
            //ADD HEADER DE ORDEN DE PRODUCCION A LA BASE DE DATOS.
            CommandSqlGeneric(R.SQL.DATABASE.NAME,  
            R.SQL.QUERY_SQL.PRODUCCION.SQL_QUERY_INSERT_MASTER_OC,SetParametersAddHeaderOrden(datos),
            ismessage,R.MESSAGES_TEXT_SYSTEM_MODULES.PRODUCCION.MESSAGE_ADD_ORDEN_ERROR_FAIL_HEADER);
            //ADD ITEMS-DETAILS DE ORDEN DE PRODUCCION A LA BASE DE DATOS.
            foreach (Roll_Details item in datos.rollos) 
            {
                CommandSqlGeneric(R.SQL.DATABASE.NAME, R.SQL.QUERY_SQL.PRODUCCION.SQL_QUERY_INSERT_DETAILS_OC,
                SetParametersAddOrdenDetails(item), ismessage,
                R.MESSAGES_TEXT_SYSTEM_MODULES.PRODUCCION.MESSAGE_ADD_ORDEN_ERROR_FAIL_DETAILS);
            }
        }
        public Boolean AddX(Orden orden)
        {
            SqlTransaction transac = null;
            try
            {
                using (Micomm.cnn)
                {
                    //sql del encabezado de la orden de corte.
                    Micomm.Conectar(R.SQL.DATABASE.NAME);
                    transac = Micomm.cnn.BeginTransaction();
                    using (SqlCommand comando = new SqlCommand
                    {
                        Transaction = transac,
                        CommandType = CommandType.Text,
                        CommandText = R.SQL.QUERY_SQL.PRODUCCION.SQL_QUERY_INSERT_MASTER_OC,
                        Connection = Micomm.cnn
                    })
                    {
                        // aqui va todos los datos del encabezado de la orden de corte.
                        SqlParameter p1 = new SqlParameter("@p1", orden.Numero);
                        SqlParameter p2 = new SqlParameter("@p2", orden.Fecha);
                        //SqlParameter p3 = new SqlParameter("@p3", orden.Pedido);
                        //SqlParameter p4 = new SqlParameter("@p4", orden.Customer_id);
                        //SqlParameter p5 = new SqlParameter("@p5", orden.Roll_id);
                        //SqlParameter p6 = new SqlParameter("@p6", orden.Total_rolls);
                        SqlParameter p7 = new SqlParameter("@p7", orden.Anulada);
                        SqlParameter p8 = new SqlParameter("@p8", orden.Status);
                        comando.Parameters.Add(p1);
                        comando.Parameters.Add(p2);
                        //comando.Parameters.Add(p3);
                        //comando.Parameters.Add(p4);
                        //comando.Parameters.Add(p5);
                        //comando.Parameters.Add(p6);
                        comando.Parameters.Add(p7);
                        comando.Parameters.Add(p8);
                        comando.ExecuteNonQuery();
                    }
                    //sql del detalle de factura.
                    using (SqlCommand comando1 = new SqlCommand
                    {
                        Transaction = transac,
                        CommandType = CommandType.Text,
                        CommandText = R.SQL.QUERY_SQL.PRODUCCION.SQL_QUERY_INSERT_DETAILS_OC,
                        Connection = Micomm.cnn
                    })
                    {
                        SqlParameter r1 = new SqlParameter
                        {
                            ParameterName = "@r1"
                        };
                        SqlParameter r2 = new SqlParameter
                        {
                            ParameterName = "@r2"
                        };
                        SqlParameter r3 = new SqlParameter
                        {
                            ParameterName = "@r3"
                        };
                        SqlParameter r4 = new SqlParameter
                        {
                            ParameterName = "@r4"
                        };
                        SqlParameter r5 = new SqlParameter
                        {
                            ParameterName = "@r5"
                        };
                        SqlParameter r6 = new SqlParameter
                        {
                            ParameterName = "@r6"
                        };
                        SqlParameter r7 = new SqlParameter
                        {
                            ParameterName = "@r7"
                        };
                        SqlParameter r8 = new SqlParameter
                        {
                            ParameterName = "@r8"
                        };
                        comando1.Parameters.Add(r1);
                        comando1.Parameters.Add(r2);
                        comando1.Parameters.Add(r3);
                        comando1.Parameters.Add(r4);
                        comando1.Parameters.Add(r5);
                        comando1.Parameters.Add(r6);
                        comando1.Parameters.Add(r7);
                        comando1.Parameters.Add(r8);
                        //foreach (Orden_Items item in orden.items)
                        //{
                        //    r1.Value = item.renglon;
                        //    r2.Value = item.numero;
                        //    r3.Value = item.Product_id;
                        //    r4.Value = item.Cantidad;
                        //    r5.Value = item.Unidad;
                        //    r6.Value = item.Width;
                        //    r7.Value = item.Large;
                        //    r8.Value = item.Msi;
                        //    comando1.ExecuteNonQuery();
                        //}
                    }
                    //Ejecucion del Commit
                    transac.Commit();
                    return true;
                }
            }
            catch (SqlException ex)
            {
                transac.Rollback();
                MessageBox.Show("Error al grabar la orden de corte...error->code: " + ex);
                return false;
            }
        }

        //public Boolean CargarRollIdTableX()
        //{
        //    try
        //    {
        //        Micomm.Conectar(R.SQL.DATABASE.NAME);
        //        SqlCommand comando = new SqlCommand
        //        {
        //            Connection = Micomm.cnn,
        //            CommandType = CommandType.Text,
        //            CommandText = R.SQL.QUERY_SQL.PRODUCCION.SQL_QUERY_SELECT_ROLLID

        //        };
        //        comando.ExecuteNonQuery();
        //        darollid.SelectCommand = comando;
        //        darollid.Fill(ds, "dtrollid");
        //        comando.Dispose();
        //        Micomm.Desconectar();
        //        return true;
        //    }
        //    catch (SqlException ex)
        //    {
        //        MessageBox.Show("" + ex);
        //        return false;
        //    }
        //}
        //public Boolean CargarCustomersX()
        //{
        //    try
        //    {
        //        Micomm.Conectar(R.SQL.DATABASE.NAME);
        //        SqlCommand comando = new SqlCommand
        //        {
        //            Connection = Micomm.cnn,
        //            CommandType = CommandType.Text,
        //            CommandText = R.SQL.QUERY_SQL.CUSTOMERS.SQL_SELECT_CUSTOMERS

        //        };
        //        comando.ExecuteNonQuery();
        //        dacustomer.SelectCommand = comando;
        //        dacustomer.Fill(ds, "dtcustomer");
        //        comando.Dispose();
        //        Micomm.Desconectar();
        //        return true;
        //    }
        //    catch (SqlException ex)
        //    {
        //        MessageBox.Show("" + ex);
        //        return false;
        //    }
        //}
        //public Boolean CargarProductsX()
        //{
        //    try
        //    {
        //        Micomm.Conectar(R.SQL.DATABASE.NAME);
        //        SqlCommand comando = new SqlCommand
        //        {
        //            Connection = Micomm.cnn,
        //            CommandType = CommandType.Text,
        //            CommandText = R.SQL.QUERY_SQL.PRODUCTS.SQL_QUERY_SELECT_PRODUCT_ALL
        //        };
        //        comando.ExecuteNonQuery();
        //        daproducts.SelectCommand = comando;
        //        daproducts.Fill(ds, "dtproducts");
        //        comando.Dispose();
        //        Micomm.Desconectar();
        //        return true;
        //    }
        //    catch (SqlException ex)
        //    {
        //        MessageBox.Show("Error al cargar la lista de productos para armar la orden de corte. error code:" + ex);
        //        return false;
        //    }
        //}
        //public Boolean UpdateDetailRollsNumberRollid(string numero,string product_id,string roll_id)
        //{
        //    try
        //    {
        //        Micomm.Conectar(R.SQL.DATABASE.NAME);
        //        SqlCommand comando = new SqlCommand
        //        {
        //            Connection = Micomm.cnn,
        //            CommandType = CommandType.Text,
        //            CommandText = R.SQL.QUERY_SQL.PRODUCCION.SQL_QUERY_UPDATE_ROLLID

        //        };
        //        dacustomer.SelectCommand = comando;
        //        SqlParameter p1 = new SqlParameter("@p1", numero);
        //        SqlParameter p2 = new SqlParameter("@p2", product_id);
        //        SqlParameter p3 = new SqlParameter("@p3", roll_id);
        //        comando.Parameters.Add(@p1);
        //        comando.Parameters.Add(@p2);
        //        comando.Parameters.Add(@p3);
        //        comando.ExecuteNonQuery();
        //        comando.Dispose();
        //        Micomm.Desconectar();
        //        MessageBox.Show("Guardado con Exito");
        //        return true;
        //    }
        //    catch (SqlException ex)
        //    {
        //        MessageBox.Show("error al grabar el numero id . error code:" + ex);
        //        return false;
        //    }
        //}
        //public bool DeleteNumberRollIdtoTable(string orden, string roll_id)
        //{
        //    try
        //    {
        //        Micomm.Conectar(R.SQL.DATABASE.NAME);
        //        SqlCommand comando = new SqlCommand
        //        {
        //            Connection = Micomm.cnn,
        //            CommandType = CommandType.Text,
        //            CommandText = R.SQL.QUERY_SQL.PRODUCCION.SQL_QUERY_DELETE_ROLLID
        //        };
        //        dacustomer.SelectCommand = comando;
        //        SqlParameter p1 = new SqlParameter("@p1", orden);
        //        SqlParameter p2 = new SqlParameter("@p2", roll_id);
        //        comando.Parameters.Add(@p1);
        //        comando.Parameters.Add(@p2);
        //        comando.ExecuteNonQuery();
        //        comando.Dispose();
        //        Micomm.Desconectar();
        //        MessageBox.Show("Guardado con Exito");
        //        return true;
        //    }
        //    catch (SqlException ex)
        //    {
        //        MessageBox.Show("error al borrar el numero id . error code:" + ex);
        //        return false;
        //    }
        //}
        //public Boolean AddNumberRollIdtoTable(string orden,string roll_id)
        //{
        //    try
        //    {
        //        Micomm.Conectar(R.SQL.DATABASE.NAME);
        //        SqlCommand comando = new SqlCommand
        //        {
        //            Connection = Micomm.cnn,
        //            CommandType = CommandType.Text,
        //            CommandText = R.SQL.QUERY_SQL.PRODUCCION.SQL_QUERY_INSERT_ROLLID

        //        };
        //        dacustomer.SelectCommand = comando;
        //        SqlParameter p1 = new SqlParameter("@p1",orden);
        //        SqlParameter p2 = new SqlParameter("@p2", roll_id);
        //        comando.Parameters.Add(@p1);
        //        comando.Parameters.Add(@p2);
        //        comando.ExecuteNonQuery();
        //        comando.Dispose();
        //        Micomm.Desconectar();
        //        MessageBox.Show("Guardado con Exito");
        //        return true;
        //    }
        //    catch (SqlException ex)
        //    {
        //        MessageBox.Show("error al grabar el numero id . error code:" + ex);
        //        return false;
        //    }
        //}
        public Boolean SaveDataDetailsRolls(List<Roll_Details> rollos)
        {
            SqlTransaction transac = null;
            try
            {
                using (Micomm.cnn)
                {
                    Micomm.Conectar(R.SQL.DATABASE.NAME);
                    transac = Micomm.cnn.BeginTransaction();
                    using (SqlCommand comando = new SqlCommand
                    {
                        Transaction = transac,
                        CommandType = CommandType.Text,
                        CommandText = R.SQL.QUERY_SQL.PRODUCCION.SQL_QUERY_INSERT_ROLLID,
                        Connection = Micomm.cnn
                    })
                    {
                        SqlParameter r1 = new SqlParameter
                        {
                            ParameterName = "@r1"
                        };
                        SqlParameter r2 = new SqlParameter
                        {
                            ParameterName = "@r2"
                        };
                        SqlParameter r3 = new SqlParameter
                        {
                            ParameterName = "@r3"
                        };
                        SqlParameter r4 = new SqlParameter
                        {
                            ParameterName = "@r4"
                        };
                        SqlParameter r5 = new SqlParameter
                        {
                            ParameterName = "@r5"
                        };
                        SqlParameter r6 = new SqlParameter
                        {
                            ParameterName = "@r6"
                        };
                        SqlParameter r7 = new SqlParameter
                        {
                            ParameterName = "@r7"
                        };
                        SqlParameter r8 = new SqlParameter
                        {
                            ParameterName = "@r8"
                        };
                        SqlParameter r9 = new SqlParameter
                        {
                            ParameterName = "@r9"
                        };
                        SqlParameter r10 = new SqlParameter
                        {
                            ParameterName = "@r10"
                        };
                        SqlParameter r11 = new SqlParameter
                        {
                            ParameterName = "@r11"
                        };
                        SqlParameter r12 = new SqlParameter
                        {
                            ParameterName = "@r12"
                        };
                        comando.Parameters.Add(r1);
                        comando.Parameters.Add(r2);
                        comando.Parameters.Add(r3);
                        comando.Parameters.Add(r4);
                        comando.Parameters.Add(r5);
                        comando.Parameters.Add(r6);
                        comando.Parameters.Add(r7);
                        comando.Parameters.Add(r8);
                        comando.Parameters.Add(r9);
                        comando.Parameters.Add(r10);
                        comando.Parameters.Add(r11);
                        comando.Parameters.Add(r12);
                        foreach (Roll_Details item in rollos)
                        {
                            r1.Value = item.Fecha;
                            r2.Value = item.Numero_Orden;
                            r3.Value = item.Roll_number;
                            r4.Value = item.Product_id;
                            r5.Value = item.Product_name;
                            r6.Value = item.Roll_id;
                            r7.Value = item.Width;
                            r8.Value = item.Large;
                            r9.Value = item.Msi;
                            r10.Value = item.Splice;
                            r11.Value = item.Code_Person;
                            r12.Value = item.Code_Unique;
                            comando.ExecuteNonQuery();
                        }
                    }
                    //Ejecucion del Commit
                    transac.Commit();
                    MessageBox.Show("Se guardaron los datos correctamente de la orden de corte.");
                    return true;
                }
            }
            catch (SqlException ex)
            {
                transac.Rollback();
                MessageBox.Show("Error al grabar el detalle de los rollos cortados...error->code: " + ex);
                return false;
            }
        }
        //public DataTable GetRollDetails(string numero_orden,string product_id)
        //{
        //    using (DataTable dt = new DataTable())
        //    {
        //        try
        //        {
        //            Micomm.Conectar(R.SQL.DATABASE.NAME);
        //            SqlCommand comando = new SqlCommand
        //            {
        //                Connection = Micomm.cnn,
        //                CommandType = CommandType.Text,
        //                CommandText = R.SQL.QUERY_SQL.PRODUCCION.SQL_UPDATE_ROLLS_DETAILS

        //            };
        //            darolls.SelectCommand = comando;
        //            SqlParameter p1 = new SqlParameter("@p1", numero_orden);
        //            SqlParameter p2 = new SqlParameter("@p2", product_id);
        //            comando.Parameters.Add(p1);
        //            comando.Parameters.Add(p2);
        //            comando.ExecuteNonQuery();
        //            darolls.Fill(dt);
        //            comando.Dispose();
        //            Micomm.Desconectar();
        //            return dt;
        //        }
        //        catch (SqlException ex)
        //        {
        //            MessageBox.Show("Error al cargar la lista de productos para armar la orden de corte. error code:" + ex);
        //            return dt;
        //        }
        //    }
        //}
        
        public Boolean RelacionesDS()
        {
            try
            {
                //Relacion Maestro-producto.
                DataColumn ParentCol1 = ds.Tables["dtproducts"].Columns["product_id"];
                DataColumn ChildCol1 = ds.Tables["dtordenes"].Columns["product_id"];
                DataRelation orden_products = new DataRelation("FK_ORDENES_PRODUCTO", ParentCol1, ChildCol1);
                ds.Relations.Add(orden_products);
                ds.Tables["dtordenes"].Columns.Add("product_name",
                Type.GetType("System.String"), "parent(FK_ORDENES_PRODUCTO).product_name");
                //Relacion MASTER-DETAILS.
                DataColumn ParentCol2 = ds.Tables["dtordenes"].Columns["numero"];  
                DataColumn ChildCol2 = ds.Tables["dtrenglones"].Columns["numero"];
                DataRelation orden_details = new DataRelation("FK_ORDEN_DETAILS", ParentCol2, ChildCol2);
                ds.Relations.Add(orden_details);




                ////Relacion detalle-productos.
                //DataColumn ParentCol3 = ds.Tables["dtproducts"].Columns["product_id"];
                //DataColumn ChildCol3 = ds.Tables["dtrenglones"].Columns["product_id"];
                //DataRelation deta_producto = new DataRelation("FK_DETALLE_PRODUCTO", ParentCol3, ChildCol3);
                //ds.Relations.Add(deta_producto);
                //ds.Tables["dtrenglones"].Columns.Add("product_name",
                //Type.GetType("System.String"), "parent(FK_DETALLE_PRODUCTO).product_name");
                // relaciones ordenes roll_id con key composite.
                //DataColumn ParentCol4 = ds.Tables["dtordenes"].Columns["numero"];  
                //DataColumn ChildCol4 = ds.Tables["dtrollid"].Columns["numero"];
                //DataRelation ord_roll_id = new DataRelation("FK_ORDEN_ROLL_ID", ParentCol4, ChildCol4);
                //ds.Relations.Add(ord_roll_id);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al tratar de establecer las relaciones entre tablas. Error Code:" + ex);
                return false;
            }
        }
        public List<SqlParameter> SetParametersAddHeaderOrden(Orden datos)
        {
            List<SqlParameter> sp = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@p1", SqlDbType = SqlDbType.NVarChar, Value = datos.Numero},
                new SqlParameter() {ParameterName = "@p2", SqlDbType = SqlDbType.DateTime, Value = datos.Fecha},
                new SqlParameter() {ParameterName = "@p3", SqlDbType = SqlDbType.DateTime, Value = datos.Fecha_produccion},
                new SqlParameter() {ParameterName = "@p4", SqlDbType = SqlDbType.NVarChar, Value = datos.Product_id},
                new SqlParameter() {ParameterName = "@p5", SqlDbType = SqlDbType.NVarChar, Value = datos.Rollid_1},
                new SqlParameter() {ParameterName = "@p6", SqlDbType = SqlDbType.Decimal, Value = datos.Width_1},
                new SqlParameter() {ParameterName = "@p7", SqlDbType = SqlDbType.Decimal, Value = datos.Lenght_1},
                new SqlParameter() {ParameterName = "@p8", SqlDbType = SqlDbType.NVarChar, Value = datos.Rollid_2},
                new SqlParameter() {ParameterName = "@p9", SqlDbType = SqlDbType.Decimal, Value = datos.Width_2},
                new SqlParameter() {ParameterName = "@p10", SqlDbType = SqlDbType.Decimal, Value = datos.Lenght_2},
                new SqlParameter() {ParameterName = "@p11", SqlDbType = SqlDbType.Decimal, Value = datos.Cant_cortados},
                new SqlParameter() {ParameterName = "@p12", SqlDbType = SqlDbType.Decimal, Value = datos.Widht_cortados},
                new SqlParameter() {ParameterName = "@p13", SqlDbType = SqlDbType.Decimal, Value = datos.Lenght_cortados},
                new SqlParameter() {ParameterName = "@p14", SqlDbType = SqlDbType.Decimal, Value = datos.msi_cortados},
                new SqlParameter() {ParameterName = "@p15", SqlDbType = SqlDbType.Bit, Value = datos.Anulada},
                new SqlParameter() {ParameterName = "@p16", SqlDbType = SqlDbType.Bit, Value = datos.Procesado}
            };
            return sp;
        }
        public List<SqlParameter> SetParametersAddOrdenDetails(Roll_Details datos)
        {
            List<SqlParameter> sp = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@p1", SqlDbType = SqlDbType.NVarChar, Value = datos.Numero_Orden},
                new SqlParameter() {ParameterName = "@p2", SqlDbType = SqlDbType.NVarChar, Value = datos.Product_id},
                new SqlParameter() {ParameterName = "@p3", SqlDbType = SqlDbType.NVarChar, Value = datos.Product_name},
                new SqlParameter() {ParameterName = "@p4", SqlDbType = SqlDbType.NVarChar, Value = datos.Roll_number},
                new SqlParameter() {ParameterName = "@p5", SqlDbType = SqlDbType.NVarChar, Value = datos.Code_Unique},
                new SqlParameter() {ParameterName = "@p6", SqlDbType = SqlDbType.Int, Value = datos.Splice},
                new SqlParameter() {ParameterName = "@p7", SqlDbType = SqlDbType.Decimal, Value = datos.Width},
                new SqlParameter() {ParameterName = "@p8", SqlDbType = SqlDbType.Decimal, Value = datos.Large},
                new SqlParameter() {ParameterName = "@p9", SqlDbType = SqlDbType.Decimal, Value = datos.Msi},
                new SqlParameter() {ParameterName = "@p10", SqlDbType = SqlDbType.NVarChar, Value = datos.Roll_id},
                new SqlParameter() {ParameterName = "@p11", SqlDbType = SqlDbType.NVarChar, Value = datos.Code_Person},
                new SqlParameter() {ParameterName = "@p12", SqlDbType = SqlDbType.NVarChar, Value = datos.status},
            };
            return sp;
        }
    }
}
