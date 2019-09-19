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
        Conexion micomm = new Conexion();
        public DataSet ds = new DataSet();
        DataTable dtsupply = new DataTable();
        SqlDataAdapter dasupply = new SqlDataAdapter();
        string db = "RITRAMA";
        string sql1 = "SELECT Proveedor_ID,Proveedor_Name,Preveedor_phone,Preveedor_Dir,Preveedor_email,anulado,unidad_master_1,unidad_master_2 FROM provider";
        string sql2 = "INSERT INTO provider (Proveedor_ID,Proveedor_Name,Preveedor_Dir,Preveedor_phone,Preveedor_email,anulado,unidad_master_1,unidad_master_2) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)";
        string sql3 = "UPDATE provider SET Proveedor_Name=@p2,Preveedor_Dir=@p3,Preveedor_phone=@p4,Preveedor_email=@p5,anulado=@p6,unidad_master_1=@p7,unidad_master_2=@p8 WHERE Proveedor_ID=@p1";
        string sql5 = "SELECT count(*) FROM provider WHERE proveedor_id=@p1";
        public Boolean ProveedorExiste(string codigo)
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
        public Boolean ToList()
        {
            try
            {
                micomm.Conectar(db);
                SqlCommand comando = new SqlCommand
                {
                    Connection = micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = sql1

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
                micomm.Conectar(db);
                SqlCommand comando = new SqlCommand
                {
                    Connection = micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = sql2
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
                micomm.Conectar(db);
                SqlCommand comando = new SqlCommand
                {
                    Connection = micomm.cnn,
                    CommandType = CommandType.Text,
                    CommandText = sql3

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
