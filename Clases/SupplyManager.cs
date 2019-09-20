using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
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
        public Boolean Add(ClassSupply proveedor)
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
