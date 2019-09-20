using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RitramaAPP.Clases
{
    public class SupplyManager
    {
        // Codigo para administrar todos los procesos de Preveedores   

        Conexion micomm = new Conexion();
        public DataSet ds = new DataSet();
        DataTable dtsupply = new DataTable();
        SqlDataAdapter dasupply = new SqlDataAdapter();

        public Boolean CommandSqlGeneric(string db, string query, List<SqlParameter> spc)
        {
            try
            {
                micomm.Conectar(db);
                SqlCommand comando = new SqlCommand
                {
                    Connection = micomm.cnn,
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
                micomm.Desconectar();
                MessageBox.Show("proceso realizado con exito...");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar nuevo registro de proveedor...Error Code:" + ex);
                return false;
            }
        }

        public Boolean VerificarExisteOrden(string orden)
        {
            int result;
            micomm.Conectar(R.SQL.DATABASE.NAME);
            SqlCommand comando = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = R.SQL.QUERY_SQL.RECEPCIONES.SQL_QUERY_VERIFY_ORDEN_REPEAT,
                Connection = micomm.cnn
            };
            SqlParameter p1 = new SqlParameter("@p1", orden);
            comando.Parameters.Add(p1);
            result = Convert.ToInt16(comando.ExecuteScalar());
            micomm.Desconectar();
            comando.Dispose();
            if (result == 1)
            {
                // La orden de Recepcion ya existe en la base de datos
                return true;
            }
            else
            {
                // no existe.
                return false;
            }
        }

        public Boolean ProveedorExiste(string codigo)
        {
            int result;
            micomm.Conectar(R.SQL.DATABASE.NAME);
            SqlCommand comando = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = R.SQL.QUERY_SQL.RECEPCIONES.SQL_QUERY_COUNT_PROVEEDORES,
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
        public Boolean ToList()
        {
            try
            {
                micomm.Conectar(R.SQL.DATABASE.NAME);
                SqlCommand comando = new SqlCommand
                {
                    Connection = micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = R.SQL.QUERY_SQL.RECEPCIONES.SQL_QUERY_SELECT_PROVEEDORES
                };
                comando.ExecuteNonQuery();
                dasupply.SelectCommand = comando;
                dasupply.Fill(ds, "dtsupply");
                comando.Dispose();
                micomm.Desconectar();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al cargar la lista de los proveedores. error code:" + ex);
                return false;
            }
        }
        public void Add(ClassSupply datos)
        {
            //lleno la coleccion de parametros.
            List<SqlParameter> sp = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@p1", SqlDbType = SqlDbType.NVarChar, Value = datos.Supply_ID},
                new SqlParameter() {ParameterName = "@p2", SqlDbType = SqlDbType.NVarChar, Value = datos.Supply_Name},
                new SqlParameter() {ParameterName = "@p3", SqlDbType = SqlDbType.NVarChar, Value = datos.Supply_Direcc},
                new SqlParameter() {ParameterName = "@p4", SqlDbType = SqlDbType.NVarChar, Value = datos.Supply_Phone},
                new SqlParameter() {ParameterName = "@p5", SqlDbType = SqlDbType.NVarChar, Value = datos.Supply_Email},
                new SqlParameter() {ParameterName = "@p6", SqlDbType = SqlDbType.Bit, Value = datos.Anulado},
                new SqlParameter() {ParameterName = "@p7", SqlDbType = SqlDbType.Bit, Value = datos.unid_master_1},
                new SqlParameter() {ParameterName = "@p8", SqlDbType = SqlDbType.Bit, Value = datos.unid_master_2}
            };
            //llamo al comando sql generico.
            CommandSqlGeneric(R.SQL.DATABASE.NAME,
                R.SQL.QUERY_SQL.RECEPCIONES.SQL_QUERY_INSERT_PROVEEDORES, sp);
        }
        public Boolean AddOld(ClassSupply proveedor)
        {
            try
            {
                micomm.Conectar(R.SQL.DATABASE.NAME);
                SqlCommand comando = new SqlCommand
                {
                    Connection = micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = R.SQL.QUERY_SQL.RECEPCIONES.SQL_QUERY_INSERT_PROVEEDORES
                };
                SqlParameter p1 = new SqlParameter("@p1", proveedor.Supply_ID);
                SqlParameter p2 = new SqlParameter("@p2", proveedor.Supply_Name);
                SqlParameter p3 = new SqlParameter("@p3", proveedor.Supply_Direcc);
                SqlParameter p4 = new SqlParameter("@p4", proveedor.Supply_Phone);
                SqlParameter p5 = new SqlParameter("@p5", proveedor.Supply_Email);
                SqlParameter p6 = new SqlParameter("@p6", proveedor.Anulado);
                SqlParameter p7 = new SqlParameter("@p7", proveedor.unid_master_1);
                SqlParameter p8 = new SqlParameter("@p8", proveedor.unid_master_2);
                comando.Parameters.Add(p1);
                comando.Parameters.Add(p2);
                comando.Parameters.Add(p3);
                comando.Parameters.Add(p4);
                comando.Parameters.Add(p5);
                comando.Parameters.Add(p6);
                comando.Parameters.Add(p7);
                comando.Parameters.Add(p8);
                comando.ExecuteNonQuery();
                comando.Dispose();
                micomm.Desconectar();
                MessageBox.Show("proceso realizado con exito...");
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al insertar nuevo registro de proveedor...Error Code:" + ex);
                return false;
            }
        }
        public Boolean Update(ClassSupply proveedor)
        {
            try
            {
                micomm.Conectar(R.SQL.DATABASE.NAME);
                SqlCommand comando = new SqlCommand
                {
                    Connection = micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = R.SQL.QUERY_SQL.RECEPCIONES.SQL_QUERY_UPDATE_PROVEEDORES

                };
                SqlParameter p1 = new SqlParameter("@p1", proveedor.Supply_ID);
                SqlParameter p2 = new SqlParameter("@p2", proveedor.Supply_Name);
                SqlParameter p3 = new SqlParameter("@p3", proveedor.Supply_Direcc);
                SqlParameter p4 = new SqlParameter("@p4", proveedor.Supply_Phone);
                SqlParameter p5 = new SqlParameter("@p5", proveedor.Supply_Email);
                SqlParameter p6 = new SqlParameter("@p6", proveedor.Anulado);
                SqlParameter p7 = new SqlParameter("@p7", proveedor.unid_master_1);
                SqlParameter p8 = new SqlParameter("@p8", proveedor.unid_master_2);
                comando.Parameters.Add(p1);
                comando.Parameters.Add(p2);
                comando.Parameters.Add(p3);
                comando.Parameters.Add(p4);
                comando.Parameters.Add(p5);
                comando.Parameters.Add(p6);
                comando.Parameters.Add(p7);
                comando.Parameters.Add(p8);
                comando.ExecuteNonQuery();
                comando.Dispose();
                micomm.Desconectar();
                MessageBox.Show("Se actualizaron los datos con exito...");
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al modificar proveedor...Error Code:" + ex);
                return false;
            }
        }
    }
}
